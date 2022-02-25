﻿using Microsoft.AspNetCore.Mvc;
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
    [JwtAuthorize]
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

            return new FileStreamResult(stream, "application/pdf");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] RequestRequest req)
        {
            var requestType = _requestTypeService.GetById(req.RequestTypeId);
            if (requestType == null) return BadRequest();

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
                RequestType = requestType,
            };
            bool result;

            if(req.Policy != null) result = await _requestService.AddWithFile(newRequest, req.Policy);
            else result = _requestService.Add(newRequest);

            if (result) return Ok();

            return StatusCode(500);
        }
    }
}
