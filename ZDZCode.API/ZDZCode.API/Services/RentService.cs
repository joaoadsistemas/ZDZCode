using ZDZCode.API.DTOs.Rent;
using ZDZCode.API.Repositories.Interfaces;
using ZDZCode.API.Services.Interfaces;

namespace ZDZCode.API.Services
{
    public class RentService : IRentService
    {

        private readonly IRentRepository _rentRepository;

        public RentService(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public async Task<bool> AddRent(RentInsertDTO dto)
        {
            var result = await _rentRepository.AddRent(dto);
            return result;
        }
    }
}
