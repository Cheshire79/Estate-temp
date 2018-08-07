using System.Collections.Generic;

namespace WebUI.Models.Realtor
{
    public class DataForManipulateRealEstateView
    {
        public List<CityDistrictDropItemView> Districts;
        public List<RoomNumberDropItemView> RoomNumbers;
        public List<StreetDropItemView> Streets;
        public int ChoosenDistrict;
        public int ChoosenRoomNumber;
        public int ChoosenStreet;
    }
}