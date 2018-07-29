
namespace KnowledgeManagement.BLL.Interface.Date
{
    public class ChoosenSearchParametersForRealtorDTO
    {
        public int? DistrictId = null;
        public int? RoomNumber = null;
        public SortOrder SortOrder;

        public int? AreaFrom;
        public int? AreaTo;

        public decimal? PriceFrom;
        public decimal? PriceTo;

        public int? FloorFrom;
        public int? FloorTo;

        public int? HeightFrom;
        public int? HeightTo;
        public bool ShowOnlyMyOwn = false;
    }
}
