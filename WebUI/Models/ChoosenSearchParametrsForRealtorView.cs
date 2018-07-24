using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ChoosenSearchParametrsForRealtorView
    {
        public int DistrictId { get; set; } = -1;
        public int RoomNumber { get; set; } = -1;
        public int SortOrder { get; set; } = -1;


        [RegularExpression(@"^\s*\d*\s*")]
        public string AreaFrom { get; set; }
        [RegularExpression(@"^\s*\d*\s*")]
        public string AreaTo { get; set; }

        [RegularExpression(@"^\s*\d*\.?\d*\s*")]
        public string PriceFrom { get; set; }

        [RegularExpression(@"^\s*\d*\.?\d*\s*")]
        public string PriceTo { get; set; }

        [RegularExpression(@"^\s*\d*\s*")]
        public string FloorFrom { get; set; }

        [RegularExpression(@"^\s*\d*\s*")]
        public string FloorTo { get; set; }

        [RegularExpression(@"^\s*\d*\s*")]
        public string HeightFrom { get; set; }

        [RegularExpression(@"^\s*\d*\s*")]
        public string HeightTo { get; set; }
        public bool ShowOnlyMyOwn { get; set; }
    }

}