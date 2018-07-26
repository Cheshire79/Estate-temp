using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class RealEstateToSaveView
    {
        public int Width { set; get; }
        public string Building { get; set; }
        [RegularExpression(@"^\d*")]
        public string Appartment { get; set; }
        public Int16 Floor { get; set; }
        public Int16 Height { get; set; }
        public float Area { get; set; }
        public Decimal Price { get; set; }
        public byte RoomNumber { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        [RegularExpression(@"^\d*")]
        public int StreetId { get; set; }
        public int DistrictId { get; set; }
    }
}