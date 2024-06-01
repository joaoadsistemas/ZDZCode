using ZDZCode.API.DTOs.Hotel;
using ZDZCode.API.Entities;

namespace ZDZCode.API.Repositories.Interfaces
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> FindHotels();
        Task<List<Hotel>> FindHotelsWithPersonsAndRentById(Guid id);

    }
}
