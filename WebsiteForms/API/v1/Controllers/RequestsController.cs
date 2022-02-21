using Microsoft.AspNetCore.Mvc;
using WebsiteForms.Authorization;
using WebsiteForms.Repositories.RequestTypesRepository;

namespace WebsiteForms.API.v1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [JwtAuthorize]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestTypeRepository _requestTypeRepository;

        public RequestsController(IRequestTypeRepository requestTypeRepository)
        {
            _requestTypeRepository = requestTypeRepository;
        }

        [HttpGet]
        [Route("types")]
        public IActionResult GetTypes()
        {
            var requestTypes = _requestTypeRepository.GetAll();
            return Ok(requestTypes);
        }

        [HttpPost]
        public IActionResult Create(IFormCollection data, IFormFile? pdfFile = null)
        {
            return Ok(data);
        }
    }
}
