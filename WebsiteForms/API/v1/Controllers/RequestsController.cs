using Microsoft.AspNetCore.Mvc;
using WebsiteForms.API.v1.Models.Requests;
using WebsiteForms.Authorization;
using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories.RequestRepository;
using WebsiteForms.Repositories.RequestTypesRepository;
using WebsiteForms.Services.PolicyService;
using WebsiteForms.Services.RequestService;

namespace WebsiteForms.API.v1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [JwtAuthorize]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestTypeRepository _requestTypeRepository;
        private readonly IRequestService _requestService;

        public RequestsController(IRequestTypeRepository requestTypeRepository, IRequestService requestService)
        {
            _requestTypeRepository = requestTypeRepository;
            _requestService = requestService;
        }

        [HttpGet]
        [Route("types")]
        public IActionResult GetTypes()
        {
            var requestTypes = _requestTypeRepository.GetAll();
            return Ok(requestTypes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] RequestRequest req)
        {
            var newRequest = new Request()
            {
                FullName = req.FullName,
                Identifier = req.Identifier,
                PhoneNumber = req.PhoneNumber,
                Email = req.Email,
                Credit = req.Credit,
                ModificationType = req.ModificationType,
                Term = req.Term,
                NewPaymentDate = req.NewPaymentDate,
                LossOccuranceType = req.LossOccuranceType,
                VehicleChanges = req.VehicleChanges,
                LicensePlate = req.LicensePlate,
                PaymentDate = req.PaymentDate,
                ProcedureType = req.ProcedureType,
                PQRType = req.PQRType,
                PQRComment = req.PQRComment,
                RequestTypeId = req.RequestTypeId,
            };
            await _requestService.Create(newRequest, req.Policy);

            return NoContent();
        }
    }
}
