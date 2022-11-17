using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using WebsiteForms.API.v1.Models.Requests;
using WebsiteForms.Authorization;
using WebsiteForms.Database.Entities;
using WebsiteForms.Models.Services.Email;
using WebsiteForms.Services.EmailService;
using WebsiteForms.Services.RequestService;
using WebsiteForms.Services.RequestTypeService;

namespace WebsiteForms.API.v1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
#if !DEBUG
[Authorization]
#endif
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IRequestTypeService _requestTypeService;
        private readonly IEmailService _emailService;

        public RequestsController(IRequestService requestService, IRequestTypeService requestTypeService, IEmailService emailService)
        {
            _requestService = requestService;
            _requestTypeService = requestTypeService;
            _emailService = emailService;
        }

        [HttpGet]
        [Route("types")]
        public IActionResult GetTypes()
        {
            var requestTypes = _requestTypeService.GetAll();
            return Ok(requestTypes);
        }

        [AllowAnonymous]
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
            if(req.RequestTypeId == null)
            {
                Dictionary<string, string[]> Errors = new();
                Errors.Add("RequestTypeId", new string[] {
                    "The RequestTypeId field cannot be null"
                });

                return BadRequest(new { Errors });
            }
            var requestType = _requestTypeService.GetById((int)req.RequestTypeId);
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
                DocumentType = req.DocumentType,
                EconomicActivity = req.EconomicActivity,
                SQRType = req.SQRType,
            };


            int? insertedId;

            if(req.File != null) insertedId = await _requestService.AddWithFile(newRequest, req.File);
            else insertedId = _requestService.Add(newRequest);

            if(req.RequestTypeId == 17){
                var habeasData = new HabeasData
                {
                    LandLine = req.LandLine,
                    DeleteOfComercialBases = req.DeleteOfComercialBases,
                    DeleteOfCampaignBases = req.DeleteOfCampaignBases,
                    DeleteOfEventBases = req.DeleteOfEventBases,
                    Reason = req.Reason,
                    EmailNotification = req.EmailNotification,
                    AddressNotification = req.AddressNotification,
                    CellPhoneNotification = req.CellPhoneNotification,
                    Request = newRequest,
                };

                _requestService.AddWithHabeasData(habeasData);
                var emailData = new EmailData
                {
                    Key = "f6e59593-5a14-44f8-a79d-41bfa8c4ece0",
                    MailTo = newRequest.Email,
                    Params = new string[] { $"{insertedId}" }
                };
                await _emailService.SendEmailAsync(emailData);
            }

            if(req.RequestTypeId == 13)
            {
                var emailData = new EmailData
                {
                    Key = "a68bdd89-623f-499b-be3b-bf6f3c741322",
                    MailTo = newRequest.Email,
                    Params = new string[] { $"{insertedId}" }
                };
                await _emailService.SendEmailAsync(emailData);
            }

            string uri = $"{Request.Scheme}://{Request.Host.Value}{Request.Path.Value}/{insertedId}";
            if (insertedId != null) return Created(uri, new { id = insertedId });

            return StatusCode(500);
        }
    }
}
