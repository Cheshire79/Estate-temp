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
        Task SaveAsync();
    }
}
