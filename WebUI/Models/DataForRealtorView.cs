using System.Collections.Generic;
using WebUI.Models.Realtor;

namespace WebUI.Models
{
    public class DataForRealtorView
    {
        public ChoosenSearchParametrsForRealtorView ChoosenSearchParametersForRealtor;
        public DataForSearchParametersRealtorView SearchParameters;
        public List<RealEstateForRealtorView> RealEstates;
    }
}