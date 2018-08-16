using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EstateAgency.BLL.Interface;
using EstateAgency.BLL.Interface.Date;
using EstateAgencyt.DAL.Interface;
using EstateAgencyt.DAL.Interface.Date;

namespace EstateAgency.BLL.Services
{

    public class SkillService : ISkillService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public SkillService(IUnitOfWork unitOfWork, IMapperFactory mapperFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapperFactory.CreateMapper();
        }
        public IQueryable<SkillDTO> GetAll()
        {
            return _unitOfWork.Skills.GetAll().ProjectTo<SkillDTO>(_mapper.ConfigurationProvider);
        }

        public async Task<SkillDTO> GetByIdAsync(int id) //todo map
        {
            var skill = await _unitOfWork.Skills.GetByIdAsync(id);
            if (skill != null)
                return _mapper.Map<Skill, SkillDTO>(skill);
            throw new ArgumentException("There is no skill with id " + id);
        }

        public async Task Create(SkillDTO skillDTO)
        {
            var skill = _mapper.Map<SkillDTO, Skill>(skillDTO);
            skill.Id = new Skill().Id;
            _unitOfWork.Skills.Create(skill); // do need to be async ?
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(SkillDTO skillDTO)
        {
             _unitOfWork.Skills.Update(_mapper.Map<SkillDTO, Skill>(skillDTO));
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(int id)
        {
             Skill skill = await _unitOfWork.Skills.GetByIdAsync(id);
            if (skill == null)
                throw new ArgumentException("Skill was not deleted. Cannot find skill with indicated ID");
            _unitOfWork.Skills.Delete(skill);
            await _unitOfWork.SaveAsync();
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
