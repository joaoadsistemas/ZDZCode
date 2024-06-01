using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZDZCode.API.DTOs;
using ZDZCode.API.DTOs.Hotel;
using ZDZCode.API.Services.Interfaces;

namespace ZDZCode.API.Controllers
{
    [Route("hotels")]
    [ApiController]
    public class HotelController : ControllerBase
    {

        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HotelDTO>>> FindHotels()
        {
            return Ok(await _hotelService.FindHotels());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<HotelAllInfoDTO>>> FindHotelsWithPersonsAndRentById(Guid id)
        {
            return Ok(await _hotelService.FindHotelsWithPersonsAndRentById(id));
        }

    }
}
