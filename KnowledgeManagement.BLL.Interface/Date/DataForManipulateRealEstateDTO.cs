using System.Collections.Generic;

namespace KnowledgeManagement.BLL.Interface.Date
{
    public class DataForManipulateRealEstateDTO
    {
        public List<CityDistrictDTO> Districts;
        public List<RoomNumberDTO> RoomNumbers;
        public List<StreetDTO> Streets;
        public int? ChoosenDistrict;
        public int ChoosenRoomNumber;
        public int? ChoosenStreet;
    }
}
