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
    }
}
