namespace ZDZCode.API.Entities
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ImgsUrl { get; set; }

        public IEnumerable<Rent>? Rents { get; set; }
    }
}
