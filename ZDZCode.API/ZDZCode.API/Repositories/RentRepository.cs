using Microsoft.EntityFrameworkCore;
using ZDZCode.API.Context;
using ZDZCode.API.DTOs.Rent;
using ZDZCode.API.Entities;
using ZDZCode.API.Repositories.Interfaces;

namespace ZDZCode.API.Repositories
{
    public class RentRepository : IRentRepository
    {

        private readonly SystemDbContext _dbContext;

        public RentRepository(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddRent(RentInsertDTO dto)
        {

            var Hotel = await _dbContext.Hotels.FirstOrDefaultAsync(h => h.Id == dto.HotelId);

            if (Hotel == null)
            {
                return false;
            }

            var person = new Person
            {
                Name = dto.Person.Name,
                LastName = dto.Person.LastName,
                CPF = dto.Person.CPF,
                Email = dto.Person.Email,
                Phone = dto.Person.Phone,
            };

            _dbContext.People.Add(person);

            if (string.IsNullOrEmpty(person.Id.ToString()))
            {
                return false;
            }

            var rent = new Rent
            {
                PersonId = person.Id,
                HotelId = Hotel.Id,
                EntryDate = dto.EntryDate,
                DepartureDate = dto.DepartureDate

            };

            _dbContext.Rents.Add(rent); 
            await _dbContext.SaveChangesAsync();

            return true;

        }
    }
}
