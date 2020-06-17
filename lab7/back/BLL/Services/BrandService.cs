using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BLL.Services
{
    public class BrandService : IBrandService
    {
        private readonly DBContext _context;
        public BrandService(DBContext context)
        {
            _context = context;
        }
        public List<BrandDTO> GetBrands()
        {
            var result = new List<BrandDTO>();
            var brands = _context.Brands.Include(x => x.Name);
            foreach (var brand in brands)
            {
                result.Add(GetBrand(brand));
            }
            return result;
        }
        private BrandDTO GetBrand(Brand brand)
        {
            return new BrandDTO()
            {
                Name = brand.Name
            };
        }
    }
}
