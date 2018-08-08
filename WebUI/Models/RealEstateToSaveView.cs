using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class RealEstateToSaveView
    {
        [Required]
        [StringLength(7, MinimumLength = 1, ErrorMessage = "Building must be between 1 and 7 characters")]
        [RegularExpression(@"^[1-9]+\d*\w?(\/?[1-9]+\d*\w?)?", ErrorMessage = "Invalid Building value!")]
        public string Building { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 1, ErrorMessage= "Appartment must be between 1 and 4 characters")]
        [RegularExpression(@"^[1-9]+\d*",ErrorMessage= "Invalid Appartment value!")]
        public string Appartment { get; set; }

        [Required]
        [StringLength(4,  ErrorMessage = "Invalid Floor value!")]
        [RegularExpression(@"^[1-9]+\d*", ErrorMessage = "Invalid Floor value!")]
        public string Floor { get; set; }

        [Required]
        [RegularExpression(@"^[1-9]+\d*", ErrorMessage = "Invalid Height value!")]
        public string Height { get; set; }

        [Required]
        [RegularExpression(@"^[1-9]+\d*", ErrorMessage = "Invalid Area value!")]
        public string Area { get; set; }
        [Required]
        [RegularExpression(@"^\d*\,?\d*", ErrorMessage = "Invalid Price value!")]
        public string Price { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]+\d*", ErrorMessage = "Invalid Room Number value!")]
        public string RoomNumber { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        [RegularExpression(@"^[1-9]+\d*", ErrorMessage = "Streed need to be choosen!")]
        public int StreetId { get; set; }
        public int DistrictId { get; set; }
        public int Id { get; set; }
    }
}