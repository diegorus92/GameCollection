using GameCollectionAPI_BL.DTOs;
using GameCollectionAPI_BL.Services;
using GameCollectionAPI_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameCollectionAPI_AL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopmentCompanyController : ControllerBase
    {
        private readonly IDevelopmentCompanyService _developmentCompanyService;

        public DevelopmentCompanyController(IDevelopmentCompanyService developmentCompanyService)
        {
            _developmentCompanyService = developmentCompanyService;
        }



        [HttpPost]
        public ActionResult<string> AddCompany([FromForm] DevelopmentCompanyDTO companyDto)
        {
            return Ok(_developmentCompanyService.AddCompany(companyDto));
        }

        [HttpGet]
        public async Task<IEnumerable<DevelopmentCompany>> GetCompanies()
        {
            return await _developmentCompanyService.GetCompanies();
        }
    }
}
