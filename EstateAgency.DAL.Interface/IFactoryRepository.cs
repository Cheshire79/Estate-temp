using EstateAgencyt.DAL.Interface.Date;

namespace EstateAgencyt.DAL.Interface
{
    public interface IFactoryRepository
    {
        IRepository<SubSkill> CreateSubSkillRepository(IDataContext dataContext);
        IRepository<Skill> CreateSkillRepository(IDataContext dataContext);
        IReadOnlyRepository<Level> CreateLevelRepository(IDataContext dataContext);
        IRepository<SpecifyingSkill> CreateSpecifyingSkillRepository(IDataContext dataContext);

        IRepository<RealEstate> CreateRealEstateRepository(IDataContext dataContext);
        IReadOnlyRepository<City> CreateCityRepository(IDataContext dataContext);
        IReadOnlyRepository<CityDistrict> CreateCityDistrictRepository(IDataContext dataContext);
        IReadOnlyRepository<Street> CreateStreetRepository(IDataContext dataContext);
    }
}
