

namespace ZDZCode.API.DTOs
{
    public class RentDTO
    {
        public DateTimeOffset EntryDate { get; set; }
        public DateTimeOffset DepartureDate { get; set; }

        public PersonDTO Person { get; set; }

        public RentDTO(Entities.Rent entity)
        {
            this.EntryDate = entity.EntryDate;
            this.DepartureDate = entity.DepartureDate;
            this.Person = new PersonDTO(entity.Person);
        }
    }
}
