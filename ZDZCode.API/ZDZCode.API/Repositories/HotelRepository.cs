using Microsoft.EntityFrameworkCore;
using ZDZCode.API.Context;
using ZDZCode.API.Entities;
using ZDZCode.API.Repositories.Interfaces;

namespace ZDZCode.API.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly SystemDbContext _dbContext;

        public HotelRepository(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Hotel>> FindHotels()
        {

            var hotels = await _dbContext.Hotels
                .ToListAsync();

            return hotels;

        }

        public async Task<List<Hotel>> FindHotelsWithPersonsAndRentById(Guid id)
        {
            var hotels = await _dbContext.Hotels.Include(h => h.Rents)
                .ThenInclude(r => r.Person)
                .Where(h => h.Id == id)
                .ToListAsync();

            return hotels;
        }
    }
}
