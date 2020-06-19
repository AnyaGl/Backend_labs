using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BLL.Services
{
    public class BikeService : IBikeService
    {
        private readonly DBContext _context;
        private readonly IHostEnvironment _environment;

        public BikeService(DBContext context, IHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public void CreateBike(CreateBikeDTO bike) 
        {
            var photo = GetPhoto(bike.File);
            var brand = GetBrand(bike.Brand);
            var person = GetPerson(bike.PersonId);
            var type = GetType(bike.Type);

            var newBike = new Bike()
            {
                Name = bike.Name,
                Diameter = bike.Diameter,
                Price = bike.Price,
                Description = bike.Description,
                Brand = brand,
                Person = person,
                Type = type,
                Photo = photo
            };
            _context.Bikes.Add(newBike);
            _context.SaveChanges();
        }
        private Photo GetPhoto(IFormFile file)
        {
            var fileName = CreateFile(file);
            var newPhoto = new Photo()
            {
                Path = fileName
            };
            return newPhoto;
        }
        private string CreateFile(IFormFile file)
        {
            try
            {
                var fileName = Guid.NewGuid().ToString() + "." + file.FileName.Split('.').Last();
                var pathToServer = _environment.ContentRootPath;
                var pathToFolder = Path.Combine(pathToServer, "images");
                var pathToImages = Path.Combine(pathToFolder, fileName);

                using (var fileStream = new FileStream(pathToImages, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return fileName;
            }
            catch (Exception)
            {
                throw new Exception("Не удалось сохранить файл");
            }
        }
        private Brand GetBrand(string brand)
        {
            CreateNonexistentBrand(brand);
            return _context.Brands.FirstOrDefault(x => x.Name == brand);
        }
        private void CreateNonexistentBrand(string brand)
        {
            if (_context.Brands.FirstOrDefault(x => x.Name == brand) == null)
            {
                var newBrand = new Brand()
                {
                    Name = brand
                };
                _context.Brands.Add(newBrand);
                _context.SaveChanges();
            }
        }
        private Person GetPerson(int personId)
        {
            var person = _context.People.FirstOrDefault(x => x.Id == personId);
            if (person == null)
            {
                throw new Exception("Неверный id человека, для которого предназначен велосипед");
            }
            return person;
        }
        private DAL.Entities.Type GetType(string type)
        {
            CreateNonexistentType(type);
            return _context.Types.FirstOrDefault(x => x.Name == type);
        }
        private void CreateNonexistentType(string type)
        {
            if (_context.Types.FirstOrDefault(x => x.Name == type) == null)
            {
                var newType = new DAL.Entities.Type()
                {
                    Name = type
                };
                _context.Types.Add(newType);
                _context.SaveChanges();
            }
        }
        public List<BikeResultDTO> GetBikes() 
        {
            var result = new List<BikeResultDTO>();
            var bikes = _context.Bikes.Include(x => x.Brand).Include(x => x.Person).Include(x => x.Type).Include(x => x.Photo);
            foreach (var bike in bikes)
            {
                result.Add(GetBikeResult(bike));
            }
            return result;
        }
        public List<BikeResultDTO> GetBikesByFilter(int minPrice, int maxPrice, int personId, int minDiameter, int maxDiameter, int brandId, int typeId)
        {
            var result = new List<BikeResultDTO>();
            var bikes = _context.Bikes.Include(x => x.Brand).Include(x => x.Person).Include(x => x.Type).Include(x => x.Photo).ToList();

            bikes = bikes.Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToList();
            bikes = bikes.Where(x => x.Person.Id == personId || personId == -1).ToList();
            bikes = bikes.Where(x => x.Diameter >= minDiameter && x.Diameter <= maxDiameter).ToList();
            bikes = bikes.Where(x => x.Brand.Id == brandId || brandId == -1).ToList();
            bikes = bikes.Where(x => x.Type.id == typeId || typeId == -1).ToList();

            foreach (var bike in bikes)
            {
                result.Add(GetBikeResult(bike));
            }
            return result;
        }
        public BikeResultDTO GetBikeById(int id) 
        {
            var bike = _context.Bikes.Include(x => x.Brand).Include(x => x.Person).Include(x => x.Type).Include(x => x.Photo).FirstOrDefault(x => x.Id == id);
            if (bike == null)
            {
                throw new Exception("Не удалось найти велосипед по id");
            }
            return GetBikeResult(bike);
        }
        private BikeResultDTO GetBikeResult(Bike bike)
        {
            return new BikeResultDTO()
            {
                Id = bike.Id,
                Name = bike.Name,
                Diameter = bike.Diameter,
                Price = bike.Price,
                Description = bike.Description,
                Person = bike.Person.Type,
                Brand = bike.Brand.Name,
                Type = bike.Type.Name,
                Photo = bike.Photo.Path,
            };
        }
    }
}
