using System.Threading.Tasks;
using EstateAgencyt.DAL.Interface;
using EstateAgencyt.DAL.Interface.Date;

namespace EstateAgencyt.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDataContext _db;
        private IFactoryRepository _factoryRepository;

        public UnitOfWork(IFactoryRepository factoryRepository, IDataContext db)
        {
            // Debug.WriteLine("Create  UnitOfWork KM");
            _factoryRepository = factoryRepository;
            _db = db;
        }

        private IRepository<RealEstate> _realEstateRepository;
        private IReadOnlyRepository<City> _cityRepository;
        private IReadOnlyRepository<CityDistrict> _cityDistrictRepository;
        private IReadOnlyRepository<Street> _streetRepository;

        public IRepository<RealEstate> RealEstates
        {
            get { return _realEstateRepository ?? (_realEstateRepository = _factoryRepository.CreateRealEstateRepository(_db)); }
        }

        public IReadOnlyRepository<City> Cities
        {
            get { return _cityRepository ?? (_cityRepository = _factoryRepository.CreateCityRepository(_db)); }
        }
        public IReadOnlyRepository<CityDistrict> CityDistricts
        {
            get { return _cityDistrictRepository ?? (_cityDistrictRepository = _factoryRepository.CreateCityDistrictRepository(_db)); }
        }
        public IReadOnlyRepository<Street> Streets
        {
            get { return _streetRepository ?? (_streetRepository = _factoryRepository.CreateStreetRepository(_db)); }
        }

        private IRepository<Skill> _skillRepository;
        private IRepository<SubSkill> _subSkillRepository;
        public IRepository<Skill> Skills
        {
            get { return _skillRepository ?? (_skillRepository = _factoryRepository.CreateSkillRepository(_db)); }
        }

        public IRepository<SubSkill> SubSkills
        {
            get { return _subSkillRepository ?? (_subSkillRepository = _factoryRepository.CreateSubSkillRepository(_db)); }
        }

        private IReadOnlyRepository<Level> _levelRepository;
        private IRepository<SpecifyingSkill> _specifyingSkillRepository;

        public IReadOnlyRepository<Level> Levels
        {
            get { return _levelRepository ?? (_levelRepository = _factoryRepository.CreateLevelRepository(_db)); }
        }
        public IRepository<SpecifyingSkill> SpecifyingSkills
        {
            get { return _specifyingSkillRepository ?? (_specifyingSkillRepository = _factoryRepository.CreateSpecifyingSkillRepository(_db)); }
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            // Debug.WriteLine("dispose  UnitOfWork KM");
            _db.Dispose();
        }
    }
}
