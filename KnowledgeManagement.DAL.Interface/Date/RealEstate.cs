using System;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeManagement.DAL.Interface.Date
{
    public class RealEstate
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(7)]
        public string Building { get; set; }
        [Required]
        [MaxLength(4)]
        public string Appartment { get; set; }
        [Required]
        public Int16 Floor { get; set; }
        [Required]
        public Int16 Height { get; set; }
        [Required]
        public Int16 Area { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        public byte RoomNumber { get; set; }
        public DateTime CreationDate { get; set; }

        public string Description { get; set; }
        public byte[] Image { get; set; }
        [Required]
        public bool IsSold { get; set; }
        public int StreetId { get; set; }
        public string RealtorId { get; set; }
    }
}
