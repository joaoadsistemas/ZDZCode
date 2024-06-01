namespace ZDZCode.API.DTOs
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }


        public PersonDTO(Entities.Person entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.LastName = entity.LastName;
            this.Phone = entity.Phone;
            this.CPF = entity.CPF;
            this.Email = entity.Email;
        }
    }
}
