namespace ZDZCode.API.Entities
{
    public class Person
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public Rent? Rent { get; set; }
    }
}
