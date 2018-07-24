using System.Linq;
using System.Threading.Tasks;
using KnowledgeManagement.BLL.Interface.Date;

namespace KnowledgeManagement.BLL.Interface
{
    public interface IRealtorService
    {
        Task SetInitialData(string realtorId);
        IQueryable<RealEstateDTO> GetRealEstates();
        IQueryable<RealEstateDTO> GetRealEstates(ChoosenSearchParametersForRealtorDTO parameters);
        IQueryable<CityDistrictDTO> GetKievDistricts();
        IQueryable<StreetDTO> GetStreets();
        Task Create(RealEstateDTO realEstateDTO);
        IQueryable<RealEstateForRealtor> GetRealEstates(string userId, ChoosenSearchParametersForRealtorDTO parameters);
        Task<DataForSearchParametersDTO> InitiateSearchParameters();
    }
}
