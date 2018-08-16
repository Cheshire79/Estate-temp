using EstateAgencyt.DAL.Interface.Date;

namespace EstateAgencyt.DAL.Interface
{
    public interface IFactoryRepository
    {

        IRepository<RealEstate> CreateRealEstateRepository(IDataContext dataContext);
        IReadOnlyRepository<City> CreateCityRepository(IDataContext dataContext);
        IReadOnlyRepository<CityDistrict> CreateCityDistrictRepository(IDataContext dataContext);
        IReadOnlyRepository<Street> CreateStreetRepository(IDataContext dataContext);
    }
}
