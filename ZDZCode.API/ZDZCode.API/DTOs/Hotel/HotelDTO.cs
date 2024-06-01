
using ZDZCode.API.Entities;

namespace ZDZCode.API.DTOs
{
    public class HotelDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ImgsUrl { get; set; }



        public HotelDTO(Entities.Hotel entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Description = entity.Description;
            this.ImgsUrl = entity.ImgsUrl;
        }

    }
}
