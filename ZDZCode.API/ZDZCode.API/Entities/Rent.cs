namespace ZDZCode.API.Entities
{
    public class Rent
    {
        public Guid HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }


        public DateTimeOffset EntryDate { get; set; }
        public DateTimeOffset DepartureDate{ get; set;}

    }
}
