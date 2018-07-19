using System;

namespace KnowledgeManagement.BLL.Interface.Date
{
    public class RealEstateDTO
    {
        public int Id { get; set; }
        public string Building { get; set; }
        public string Appartment { get; set; }
        public Int16 Floor { get; set; }
        public Int16 Height { get; set; }
        public float Area { get; set; }
        public Decimal Price { get; set; }
        public byte RoomNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public bool IsSold { get; set; }
        public int StreetId { get; set; }
        public string RealtorId { get; set; }
    }
}
