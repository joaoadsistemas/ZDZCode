using ZDZCode.API.DTOs.Person;
using ZDZCode.API.Entities;

namespace ZDZCode.API.DTOs.Rent
{
    public class RentInsertDTO
    {
        public Guid HotelId { get; set; }

        public PersonInsertDTO Person { get; set; }

        public DateTimeOffset EntryDate { get; set; }
        public DateTimeOffset DepartureDate { get; set; }
    }
}
