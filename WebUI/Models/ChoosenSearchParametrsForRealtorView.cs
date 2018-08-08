using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ChoosenSearchParametrsForRealtorView
    {
        public int? DistrictId { get; set; } = null;
        public int? RoomNumber { get; set; } = null;
        public int SortOrder { get; set; } = 1;//todo


        [RegularExpression(@"^\d*")]
        public int? AreaFrom { get; set; }
        [RegularExpression(@"^\d*")]
        public string AreaTo { get; set; }

        [RegularExpression(@"^\d*\,?\d*")]
        public string PriceFrom { get; set; }

        [RegularExpression(@"^\d*\,?\d*")]
        public string PriceTo { get; set; }

        [RegularExpression(@"^\d*")]
        public string FloorFrom { get; set; }

        [RegularExpression(@"^\d*")]
        public string FloorTo { get; set; }

        [RegularExpression(@"^\d*")]
        public string HeightFrom { get; set; }

        [RegularExpression(@"^\d*")]
        public string HeightTo { get; set; }
        public bool ShowOnlyMyOwn { get; set; }
        public int Page { get; set; } = 1;
    }

}