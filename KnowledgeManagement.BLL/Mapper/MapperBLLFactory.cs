using System.Diagnostics;
using AutoMapper;
using KnowledgeManagement.BLL.Interface;
using KnowledgeManagement.BLL.Interface.Date;
using KnowledgeManagement.DAL.Interface.Date;

namespace KnowledgeManagement.BLL.Mapper
{

    public class MapperFactory : IMapperFactory
    {
        private IMapper _mapper { get; set; }
        public MapperFactory()
        {
            var config = new MapperConfiguration(cfg =>
            {
                Debug.WriteLine("Mapper KnowledgeManagement");
                cfg.CreateMap<Skill, SkillDTO>();
                cfg.CreateMap<SkillDTO, Skill>();
                cfg.CreateMap<SubSkill, SubSkillDTO>();
                cfg.CreateMap<SubSkillDTO, SubSkill>();
            });
            _mapper = config.CreateMapper();
        }

        public IMapper CreateMapper()
        {
            return _mapper;
        }
    }
}



