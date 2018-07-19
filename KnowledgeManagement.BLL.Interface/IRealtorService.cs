using System.Linq;
using System.Threading.Tasks;
using KnowledgeManagement.BLL.Interface.Date;

namespace KnowledgeManagement.BLL.Interface
{
    public interface IRealtorService
    {
        Task SetInitialData(string realtorId);
        IQueryable<RealEstateDTO> GetRealEstates();
        IQueryable<CityDistrictDTO> GetKievDistricts();
    }
}
