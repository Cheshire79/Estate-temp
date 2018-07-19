using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using KnowledgeManagement.BLL.Interface;
using KnowledgeManagement.BLL.Interface.Date;
using Microsoft.AspNet.Identity;
using WebUI.Mapper;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class RealtorController : Controller
    {
        private IRealtorService _realtorService;
        private IMapper _mapper;

        public RealtorController(IRealtorService realtorService, IMapperFactoryWEB mapperFactory)
        {
            _realtorService = realtorService;
            _mapper = mapperFactory.CreateMapperWEB();
            if (!_realtorService.GetRealEstates().Any())
            {
                _realtorService.SetInitialData(HttpContext.User.Identity.GetUserId());
            }
        }
        // GET: Realtor
        public async Task<ActionResult> Index()
        {
            DataForRealtorView dataForRealtorView = new DataForRealtorView();
            dataForRealtorView.Districts =

            _mapper.Map<IEnumerable<CityDistrictDTO>, IEnumerable<CityDistrictView>>
                (await _realtorService.GetKievDistricts().OrderBy(x => x.Name).ToListAsync());
            return View(dataForRealtorView);
        }
    }
}