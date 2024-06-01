using ZDZCode.API.DTOs;
using ZDZCode.API.DTOs.Rent;
using ZDZCode.API.Entities;

namespace ZDZCode.API.Services.Interfaces
{
    public interface IRentService
    {
        Task<bool> AddRent(RentInsertDTO dto);
    }
}
