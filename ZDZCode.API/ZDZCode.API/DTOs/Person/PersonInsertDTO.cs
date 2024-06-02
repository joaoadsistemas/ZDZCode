using System.ComponentModel.DataAnnotations;

namespace ZDZCode.API.DTOs.Person
{
    public class PersonInsertDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
}
