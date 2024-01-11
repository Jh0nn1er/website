using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebsiteForms.Auth.Models;
using WebsiteForms.Models.ViewModels;
using WebsiteForms.Services.InformationGroupService;

namespace WebsiteForms.API.v1.Controllers
{
    [ApiController]
    [Route("api/v1/informationGroups")]
#if !DEBUG
    [Authorize(AuthenticationSchemes = ApiKeyAuthenticationOptions.DefaultScheme)]
#endif
    public class InformationGroupsController : ControllerBase
    {
        private readonly IInformationGroupService _informationGroupService;

        public InformationGroupsController(IInformationGroupService informationGroupService)
        {
            _informationGroupService = informationGroupService;
        }

        [HttpGet("documents")]
        public ActionResult<InformationGroupVm> GetDocuments()
        {
             var informationGroups = _informationGroupService.GetAll();
            return Ok(informationGroups);
        }

        [HttpGet("main")]
        public ActionResult<List<InformationGroupMainVm>> GetMainGroups()
            => Ok(_informationGroupService.GetMainGroups());

        [HttpGet("subgroups/{parentId}")]
        public ActionResult<List<InformationGroupVm>> GetbyParentId(int parentId)
            => Ok(_informationGroupService.GetByParentId(parentId));
    }
}
