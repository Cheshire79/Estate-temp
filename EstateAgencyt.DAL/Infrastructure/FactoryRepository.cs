using EstateAgencyt.DAL.Interface;
using EstateAgencyt.DAL.Interface.Date;
using Ninject;
using Ninject.Parameters;

namespace EstateAgencyt.DAL.Infrastructure
{
    public class FactoryRepositor : IFactoryRepository
    {
        private readonly IKernel _kernel;

        public FactoryRepositor(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IRepository<SubSkill> CreateSubSkillRepository(IDataContext dataContext)
        {
            return _kernel.Get<IRepository<SubSkill>>(new IParameter[] { new ConstructorArgument("context", dataContext) });
        }
        public IRepository<Skill> CreateSkillRepository(IDataContext dataContext)
        {
            return _kernel.Get<IRepository<Skill>>(new IParameter[] { new ConstructorArgument("context", dataContext) });
        }

        public IReadOnlyRepository<Level> CreateLevelRepository(IDataContext dataContext)
        {
            return _kernel.Get<IReadOnlyRepository<Level>>(new IParameter[] { new ConstructorArgument("context", dataContext) });
        }
        public IRepository<SpecifyingSkill> CreateSpecifyingSkillRepository(IDataContext dataContext)
        {
            return _kernel.Get<IRepository<SpecifyingSkill>>(new IParameter[] { new ConstructorArgument("context", dataContext) });
        }



        public IRepository<RealEstate> CreateRealEstateRepository(IDataContext dataContext)
        {
            return _kernel.Get<IRepository<RealEstate>>(new IParameter[] { new ConstructorArgument("context", dataContext) });
        }

        public IReadOnlyRepository<City> CreateCityRepository(IDataContext dataContext)
        {
            return _kernel.Get<IReadOnlyRepository<City>>(new IParameter[] { new ConstructorArgument("context", dataContext) });
        }
        public IReadOnlyRepository<CityDistrict> CreateCityDistrictRepository(IDataContext dataContext)
        {
            return _kernel.Get<IReadOnlyRepository<CityDistrict>>(new IParameter[] { new ConstructorArgument("context", dataContext) });
        }
        public IReadOnlyRepository<Street> CreateStreetRepository(IDataContext dataContext)
        {
            return _kernel.Get<IReadOnlyRepository<Street>>(new IParameter[] { new ConstructorArgument("context", dataContext) });
        }



    }
}