using System;
using System.Threading.Tasks;
using KnowledgeManagement.DAL.Interface.Date;

namespace KnowledgeManagement.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Skill> Skills { get; }
        IRepository<SubSkill> SubSkills { get; }
        IReadOnlyRepository<Level> Levels { get; }
        IRepository<SpecifyingSkill> SpecifyingSkills { get; }

        IRepository<RealEstate> RealEstates { get; }
        IReadOnlyRepository<City> Cities { get; }
        IReadOnlyRepository<CityDistrict> CityDistricts { get; }
        IReadOnlyRepository<Street> Streets { get; }

        Task SaveAsync();
    }
}
