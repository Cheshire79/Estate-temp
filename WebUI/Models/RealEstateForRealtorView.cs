using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class RealEstateForRealtorView
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
        public string StreetName { get; set; }
        public int Districtid { get; set; }
        public string DistrictName { get; set; }
        public string RealtorId { get; set; }
        public string RealtorName { get; set; }
        public string RealtorEmail { get; set; }
        public bool IsOwner;
    }
}