using System;
using System.Data.Entity;
using System.Threading.Tasks;
using KnowledgeManagement.DAL.Interface.Date;

namespace KnowledgeManagement.DAL.Interface
{
    public interface IDataContext : IDisposable
    {
        DbSet<City> Cities { get; set; }
        DbSet<CityDistrict> CityDistricts { get; set; }
        DbSet<Street> Streets { get; set; }
        DbSet<RealEstate> RealEstates { get; set; }

        DbSet<SubSkill> SubSkills { get; set; }
        DbSet<Skill> Skills { get; set; }
        DbSet<Level> Levels { get; set; }
        DbSet<SpecifyingSkill> SpecifyingSkills { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
