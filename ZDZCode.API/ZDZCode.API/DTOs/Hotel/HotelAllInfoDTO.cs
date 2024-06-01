namespace ZDZCode.API.DTOs.Hotel
{
    public class HotelAllInfoDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ImgsUrl { get; set; }
        public List<RentDTO> Rents { get; set; }

        public HotelAllInfoDTO(Entities.Hotel entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Description = entity.Description;
            this.ImgsUrl = entity.ImgsUrl;
            this.Rents = entity.Rents != null ? entity.Rents.Select(r => new RentDTO(r)).ToList() : null;
        }
    }
}
