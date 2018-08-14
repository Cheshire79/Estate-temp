using System.Collections.Generic;
using WebUI.Models.Realtor;

namespace WebUI.Models
{
    public class DataAboutRealEstatesForRealtorView
    {
        public ChoosenSearchParametrsForRealtorView ChoosenSearchParametersForRealtor;
        public DataForSearchParametersRealtorView SearchParameters;
        public List<RealEstateForRealtorView> RealEstates;
        public PagingInfo PagingInfo { get; set; }
    }
}