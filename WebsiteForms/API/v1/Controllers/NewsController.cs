using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebsiteForms.API.v1.Models.News;
using WebsiteForms.Auth.Models;
using WebsiteForms.Database.Entities;
using WebsiteForms.Services.NewService;

namespace WebsiteForms.API.v1.Controllers
{
    [ApiController]
    [Route("/api/v1/news")]
#if !DEBUG
    [Authorize(AuthenticationSchemes = ApiKeyAuthenticationOptions.DefaultScheme)]
#endif

    public class NewsController : ControllerBase
    {
        private readonly INewService _newService;

        public NewsController(INewService newService)
        {
            _newService = newService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<New>>> GetNews()
        {
            var news = _newService.GetAsync(n => n.State == true);
            if(news == null)
                return NotFound();

            return Ok(news);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<New>> CreateNew([FromBody] PostNewReq req)
        {
            var newAdd = new New()
            {
                Title = req.Title,
                Description = req.Description,
                Url = req.Url,
                State = true,
                CreatedAt = DateTime.Now,
            };
            _newService.Add(newAdd);
            return Ok(new { id = newAdd.Id });
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateNew([FromBody] PutNewReq req)
        {
            if (req == null)
                return BadRequest(new { msg = "Debe enviar un request" });

            var @new = _newService.GetById(req.Id);
            if (@new == null)
                return NotFound(new { msg = "No existe registros de noticias con este Id " });

            var newUpdate = new New()
            {
                Id = req.Id,
                Title = req.Title,
                Description = req.Description,
                Url = req.Url,
                State = req.State,
                CreatedAt = @new.CreatedAt
            };
            var result = _newService.Update(newUpdate);
            if (result == 0)
                return StatusCode(500);
            
            return Ok(newUpdate);
        }

        [HttpGet("{newId}")]
        public ActionResult<New> GetNew(int newId)
        {
            var @new = _newService.GetById(newId);
            if(@new == null)
                return NotFound();

            return Ok(@new);
        }
    }
}
