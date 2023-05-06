using Microsoft.AspNetCore.Mvc;
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
    }
}
