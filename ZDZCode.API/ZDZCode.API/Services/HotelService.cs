using ZDZCode.API.DTOs;
using ZDZCode.API.DTOs.Hotel;
using ZDZCode.API.Repositories.Interfaces;
using ZDZCode.API.Services.Interfaces;

namespace ZDZCode.API.Services
{
    public class HotelService : IHotelService
    {

        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<List<HotelDTO>> FindHotels()
        {
            var result = await _hotelRepository.FindHotels();
            return result.Select(r => new HotelDTO(r)).ToList();
        }

        public async Task<List<HotelAllInfoDTO>> FindHotelsWithPersonsAndRentById(Guid id)
        {
            var result = await _hotelRepository.FindHotelsWithPersonsAndRentById(id);
            return result.Select(h => new HotelAllInfoDTO(h)).ToList();
        }
    }
}
