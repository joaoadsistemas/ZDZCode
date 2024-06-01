using ZDZCode.API.DTOs;
using ZDZCode.API.DTOs.Hotel;
using ZDZCode.API.Entities;

namespace ZDZCode.API.Services.Interfaces
{
    public interface IHotelService
    {
        Task<List<HotelDTO>> FindHotels();
        Task<List<HotelAllInfoDTO>> FindHotelsWithPersonsAndRentById(Guid id);

    }
}
