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

    public class SubSkillService : ISubSkillService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public SubSkillService(IUnitOfWork unitOfWork, IMapperFactory mapperFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapperFactory.CreateMapper();
        }

        public IQueryable<SubSkillDTO> GetAll()
        {
            return _unitOfWork.SubSkills.GetAll().ProjectTo<SubSkillDTO>(_mapper.ConfigurationProvider);
        }

        public async Task<SubSkillDTO> GetByIdAsync(int id)
        {
            var subSkill = await _unitOfWork.SubSkills.GetByIdAsync(id);
            if (subSkill == null)
                throw new ArgumentException("There is no skill with id " + id);
            var skill = await _unitOfWork.Skills.GetByIdAsync(subSkill.SkillId);
            if (skill == null)
            {
                //todo   need to log Error
            }
            return _mapper.Map<SubSkill, SubSkillDTO>(subSkill);
        }

        public async Task Create(SubSkillDTO subSkillDTO)
        {
            var temp = await _unitOfWork.Skills.GetByIdAsync(subSkillDTO.SkillId);
            if (temp == null)
                throw new ArgumentException("There is no skill with Id =" + subSkillDTO.SkillId);
            var subSkill = _mapper.Map<SubSkillDTO, SubSkill>(subSkillDTO);
            subSkill.Id = new SubSkill().Id;
            _unitOfWork.SubSkills.Create(subSkill);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(SubSkillDTO subSkillDTO)
        {
             _unitOfWork.SubSkills.Update(_mapper.Map<SubSkillDTO, SubSkill>(subSkillDTO));
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(int id)
        {
              SubSkill subSkill = await _unitOfWork.SubSkills.GetByIdAsync(id);
              if (subSkill == null)
                  throw new ArgumentException("Subskill was not deleted. Cannot find subskill with indicated ID");

             _unitOfWork.SubSkills.Delete(subSkill);
            await _unitOfWork.SaveAsync();
        }
        public async Task<IQueryable<SubSkillDTO>> GetSubSkillBySkillsId(int id)
        {
            if (await _unitOfWork.Skills.GetByIdAsync(id) == null)
                throw new ArgumentException("There is no skill with id " + id);
            return _unitOfWork.SubSkills.GetAll()
                  .Where(x => x.SkillId == id).ProjectTo<SubSkillDTO>(_mapper.ConfigurationProvider);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
