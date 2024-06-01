using ZDZCode.API.DTOs.Rent;
using ZDZCode.API.Entities;

namespace ZDZCode.API.Repositories.Interfaces
{
    public interface IRentRepository
    {
        Task<bool> AddRent(RentInsertDTO dto);

    }
}
