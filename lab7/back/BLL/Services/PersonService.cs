using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly DBContext _context;
        public PersonService(DBContext context)
        {
            _context = context;
        }
        public List<PersonDTO> GetPeople()
        {
            var result = new List<PersonDTO>();
            var people = _context.People.Include(x => x.Type);
            foreach (var person in people)
            {
                result.Add(GetPerson(person));
            }
            return result;
        }
        private PersonDTO GetPerson(Person person)
        {
            return new PersonDTO()
            {
                Type = person.Type
            };
        }
    }
}
