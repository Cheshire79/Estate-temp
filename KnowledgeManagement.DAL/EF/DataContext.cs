using System.Data.Entity;
using System.Linq;
using KnowledgeManagement.DAL.Interface;
using KnowledgeManagement.DAL.Interface.Date;

namespace KnowledgeManagement.DAL.EF
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(string connection)
            : base(connection)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityDistrict> CityDistricts { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }

        public DbSet<SubSkill> SubSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<SpecifyingSkill> SpecifyingSkills { get; set; }
        static DataContext()
        {
            Database.SetInitializer<DataContext>(new StoreDbInitializer());
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext db)
        {

            db.Cities.Add(new City() { Name = "Киев" });
            db.Cities.Add(new City() { Name = "Черкассы" });

            var city1 = db.Cities.FirstOrDefault(x => x.Name == "Киев");
            if (city1 != null)
            {
                db.CityDistricts.Add(new CityDistrict()
                {
                    CityId = city1.Id,
                    Name = "Троещина"
                });
                db.CityDistricts.Add(new CityDistrict()
                {
                    CityId = city1.Id,
                    Name = "Шевченковский р-н"
                });
            }
            var сityDistrict1 = db.CityDistricts.FirstOrDefault(x => x.Name == "Шевченковский р-н");
            if (сityDistrict1 != null)
            {
                db.Streets.Add(new Street()
                {
                    CityDistrictId = сityDistrict1.Id,
                    Name = "Чорновола"
                });
                db.Streets.Add(new Street()
                {
                    CityDistrictId = сityDistrict1.Id,
                    Name = "Саксаганского"
                });

            }
            var city2 = db.Cities.FirstOrDefault(x => x.Name == "Черкассы");
            if (city2 != null)
            {
                db.CityDistricts.Add(new CityDistrict()
                {
                    CityId = city2.Id,
                    Name = "Приднепровский"
                });
                db.CityDistricts.Add(new CityDistrict()
                {
                    CityId = city2.Id,
                    Name = "Сосновский"
                });
            }
            db.Skills.Add(new Skill() { Name = "Nokia Lumia 630" });

            db.Skills.Add(new Skill() { Name = "Nokia Lumia 630" });

            db.Levels.Add(new Level() { Name = "None", Order = 0 });
            db.Levels.Add(new Level() { Name = "Novice", Order = 1 });
            db.Levels.Add(new Level() { Name = "Intermediate", Order = 2 });
            db.Levels.Add(new Level() { Name = "Advanced", Order = 3 });
            db.Levels.Add(new Level() { Name = "Expert", Order = 4 });

            db.Skills.Add(new Skill() { Name = "Programming languages" });
            db.Skills.Add(new Skill() { Name = "Databases" });
            db.SaveChanges();
            var skill1 = db.Skills.FirstOrDefault(x => x.Name == "Programming languages");
            if (skill1 != null)
            {
                db.SubSkills.Add(new SubSkill()
                {
                    SkillId = skill1.Id,
                    Name = "C/C++"
                });
                db.SubSkills.Add(new SubSkill()
                {
                    SkillId = skill1.Id,
                    Name = "JavaScript / HTML / CSS"
                });
                db.SubSkills.Add(new SubSkill()
                {
                    SkillId = skill1.Id,
                    Name = "Delphi"
                });
            }
            var skill2 = db.Skills.FirstOrDefault(x => x.Name == "Databases");
            if (skill2 != null)
            {
                db.SubSkills.Add(new SubSkill()
                {
                    SkillId = skill2.Id,
                    Name = "Microsoft SQL Server"
                });
                db.SubSkills.Add(new SubSkill()
                {
                    SkillId = skill2.Id,
                    Name = "Oracle"
                });
            }
            db.SaveChanges();
        }
    }


}