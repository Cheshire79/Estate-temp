using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class SearchParametersForRealtorSave
    {
        public int DistrictId { get; set; }
        public int RoomNumber { get; set; }

        [StringLength(70, MinimumLength = 0)]
        [RegularExpression(@"^\d*")]
        public string AreaFrom { get; set; }

        [StringLength(70, MinimumLength = 0)]
        [RegularExpression(@"^\d*")]
        public string AreaTo { get; set; }

        [StringLength(70, MinimumLength = 0)]
        [RegularExpression(@"\d*\.?\d*")]
        public string PriceFrom { get; set; }

        [StringLength(70, MinimumLength = 0)]
        [RegularExpression(@"\d*\.?\d*")]
        public string PriceTo { get; set; }

        [StringLength(70, MinimumLength = 0)]
        [RegularExpression(@"^\d*")]
        public string FloorFrom { get; set; }

        [StringLength(70, MinimumLength = 0)]
        [RegularExpression(@"^\d*")]
        public string FloorTo { get; set; }

        [StringLength(70, MinimumLength = 0)]
        [RegularExpression(@"^\d*")]
        public string HeightFrom { get; set; }

        [StringLength(70, MinimumLength = 0)]
        [RegularExpression(@"^\d*")]
        public string HeightTo { get; set; }
        public bool ShowOnlyMyOwn { get; set; }
    }
}