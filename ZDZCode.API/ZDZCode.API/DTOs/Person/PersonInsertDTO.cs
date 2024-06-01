using System.ComponentModel.DataAnnotations;

namespace ZDZCode.API.DTOs.Person
{
    public class PersonInsertDTO
    {
        [MinLength(2)]
        public string Name { get; set; }
        [MinLength(3)]
        public string LastName { get; set; }
        [MinLength(11), MaxLength(11)]
        public string Phone { get; set; }
        [MinLength(11), MaxLength(11)]
        public string CPF { get; set; }
        [MinLength(6)]
        public string Email { get; set; }
    }
}
