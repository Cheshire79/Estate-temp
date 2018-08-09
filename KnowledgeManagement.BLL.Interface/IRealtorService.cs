using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeManagement.BLL.Interface.Date;

namespace KnowledgeManagement.BLL.Interface
{
    public interface IRealtorService : IDisposable
    {
        Task SetInitialData(string realtorId);
        IQueryable<RealEstateDTO> GetRealEstates();
        IQueryable<RealEstateDTO> GetRealEstates(ChoosenSearchParametersForRealtorDTO parameters);
        IQueryable<CityDistrictDTO> GetKievDistricts();
        IQueryable<StreetDTO> GetStreets();
        Task<List<StreetDropDownItemDTO>> GetStreetsForDropDownByDistrctId(int districtId);
        Task Create(RealEstateDTO realEstateDTO,string realtorId);
        Task Save(RealEstateDTO realEstateDTO);
        IQueryable<RealEstateForRealtor> GetRealEstates(string userId, ChoosenSearchParametersForRealtorDTO parameters);
        Task<EditRealEstateDTO> GetRealEstateForEdit(int id, string userId);
        Task<DataForSearchParametersDTO> InitiateSearchParameters();
        Task<DataForManipulateRealEstateDTO> InitiateDataForRealEstateCreation(int? specifiedDistrictId = null, int? specifiedStreetId = null);
		Task MarkRealEstateAsSold(int realEstateId);
		Task DeleteRealEstate(int realEstateId);
	}
}
