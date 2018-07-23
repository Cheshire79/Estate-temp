using System.Collections.Generic;
using WebUI.Models.Realtor;

namespace WebUI.Models
{
    public class DataForRealtorView
    {
        public SearchParametersForRealtorSave SearchParametersForRealtorSave;
        public SearchParametersRealtorView SearchParameters;
        public IEnumerable<RealEstateForRealtorView> RealEstates;
    }
}