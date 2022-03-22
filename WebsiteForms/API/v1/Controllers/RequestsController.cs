using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using WebsiteForms.API.v1.Models.Requests;
using WebsiteForms.Authorization;
using WebsiteForms.Database.Entities;
using WebsiteForms.Services.RequestService;
using WebsiteForms.Services.RequestTypeService;

namespace WebsiteForms.API.v1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorization]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IRequestTypeService _requestTypeService;

        public RequestsController(IRequestService requestService, IRequestTypeService requestTypeService)
        {
            _requestService = requestService;
            _requestTypeService = requestTypeService;
        }

        [HttpGet]
        [Route("types")]
        public IActionResult GetTypes()
        {
            var requestTypes = _requestTypeService.GetAll();
            return Ok(requestTypes);
        }

        [HttpGet]
        [Route("{id:int}/file")]
        public IActionResult GetFile(int id)
        {
            var stream = _requestService.GetFileById(id);
            if(stream == null) return NotFound();

            new FileExtensionContentTypeProvider().TryGetContentType(stream.Name, out string? contentType);
            return new FileStreamResult(stream, contentType ?? "application/octet-stream");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] RequestRequest req)
        {
            var requestType = _requestTypeService.GetById(req.RequestTypeId);
            if (requestType == null)
            {
                Dictionary<string, string[]> Errors = new();
                Errors.Add("RequestTypeId", new string[] {
                    "The RequestTypeId field is not a valid ID"
                });

                return BadRequest(new { Errors });
            }

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
                Comment = req.Comment,
                CreatedAt = DateTime.Now,
                PersonalDataProcessingAuthorization = req.PersonalDataProcessingAuthorization,
                RequestType = requestType,
                Age = req.Age,
                Position = req.Position,
                LastAcademicLevel = req.LastAcademicLevel,
            };
            int? insertedId;

            if(req.File != null) insertedId = await _requestService.AddWithFile(newRequest, req.File);
            else insertedId = _requestService.Add(newRequest);

            string uri = $"{Request.Scheme}://{Request.Host.Value}{Request.Path.Value}/{insertedId}";
            if (insertedId != null) return Created(uri, null);

            return StatusCode(500);
        }
    }
}
