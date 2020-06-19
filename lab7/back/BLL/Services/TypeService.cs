using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BLL.Services
{
    public class TypeService : ITypeService
    {
        private readonly DBContext _context;
        public TypeService(DBContext context)
        {
            _context = context;
        }
        public List<TypeDTO> GetTypes()
        {
            var result = new List<TypeDTO>();
            var types = _context.Types;
            foreach (var type in types)
            {
                result.Add(GetType(type));
            }
            return result;
        }
        private TypeDTO GetType(Type type)
        {
            return new TypeDTO()
            {
                Id = type.id,
                Name = type.Name
            };
        }
    }
}
