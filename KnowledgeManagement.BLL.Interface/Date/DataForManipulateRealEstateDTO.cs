using System.Collections.Generic;

namespace KnowledgeManagement.BLL.Interface.Date
{
    public class DataForManipulateRealEstateDTO
    {
        public List<CityDistrictDropDownItemDTO> Districts;
        public List<RoomNumberDownItemDTO> RoomNumbers;
        public List<StreetDropDownItemDTO> Streets;
        public int? ChoosenDistrict;
        public int ChoosenRoomNumber;
        public int? ChoosenStreet;
    }
}
