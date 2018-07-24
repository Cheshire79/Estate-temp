
namespace KnowledgeManagement.BLL.Interface.Date
{
    public class ChoosenSearchParametersForRealtorDTO
    {
        public int DistrictId = -1;
        public int RoomNumber = -1;
        public int SortOrder = -1;


        public int AreaFrom;
        public int AreaTo;
        public bool AreaFromIgnored = true;
        public bool AreaToIgnored = true;

        public decimal PriceFrom;
        public decimal PriceTo;
        public bool PriceFromIgnored = true;
        public bool PriceToIgnored = true;

        public int FloorFrom;
        public int FloorTo;
        public bool FloorFromIgnored = true;
        public bool FloorToIgnored = true;

        public int HeightFrom;
        public int HeightTo;
        public bool HeightFromIgnored = true;
        public bool HeightToIgnored = true;

        public bool ShowOnlyMyOwn = false;
    }
}
