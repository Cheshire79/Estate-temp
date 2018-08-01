using System.Collections.Generic;

namespace WebUI.Models.Realtor
{
    public class DataForCreateRealEstateView
    {
        public List<CityDistrictDropItemView> Districts;
        public List<RoomNumberDropItemView> RoomNumbers;
        public List<StreetDropItemView> Streets;
    }
}