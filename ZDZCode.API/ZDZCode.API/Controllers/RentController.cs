using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZDZCode.API.DTOs;
using ZDZCode.API.DTOs.Rent;
using ZDZCode.API.Services;
using ZDZCode.API.Services.Interfaces;

namespace ZDZCode.API.Controllers
{
    [Route("rents")]
    [ApiController]
    public class RentController : ControllerBase
    {

        private readonly IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }


        [HttpPost]
        public async Task<ActionResult<bool>> AddRent([FromBody] RentInsertDTO dto)
        {
            var result = await _rentService.AddRent(dto);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpPut("{personId}")]
        public async Task<ActionResult<bool>> UpdateRent([FromBody] RentInsertDTO dto, Guid personId)
        {
            var result = await _rentService.UpdateRent(dto, personId);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{personId}/{hotelId}")]
        public async Task<ActionResult<bool>> DeleteRent(Guid hotelId, Guid personId)
        {
            var result = await _rentService.DeleteRent(personId, hotelId);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
