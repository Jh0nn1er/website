using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebsiteForms.API.v1.Models.News;
using WebsiteForms.Database.Entities;
using WebsiteForms.Services.NewService;

namespace WebsiteForms.API.v1.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [Authorize]

    public class NewsController : ControllerBase
    {
        private readonly INewService _newService;

        public NewsController(INewService newService)
        {
            _newService = newService;
        }

        [HttpGet("GetNews")]
        //[Authorize]
        public IActionResult GetNews(int? NewId)
        {
            if (NewId != null)
            {
                int Id = NewId.Value;
                var news = _newService.GetById(Id);
                if (news != null)
                {
                    return Ok(news);
                }
                else
                {
                    return BadRequest(new
                    {
                        msg = "No existe registros de noticias con este Id "
                    });

                }
            }
            else
            {
                var news = _newService.GetAll();
                return Ok(news);
            }

        }
        [HttpPost("AddNews")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        //[Authorize]

        public async Task<ActionResult> CreateNew([FromBody] PostNewReq req)
        {
            if (req != null)
            {
                var newAdd = new New()
                {
                    newTitle = req.newTitle,
                    newDescription = req.newDescription,
                    newUrl = req.newUrl,
                    newState = req.newState,
                    newDate = req.newDate,
                    CreatedAt = DateTime.Now,
                };
                _newService.Add(newAdd);
                return Ok(newAdd);
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpPut("UpNews")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        //[Authorize]

        public async Task<ActionResult> UpdateNew([FromBody] PutNewReq req)
        {
            if (req != null)
            {
                var verify = _newService.GetById(req.Id);
                if (verify != null)
                {
                    var newUpdate = new New()
                    {
                        Id = req.Id,
                        newTitle = req.newTitle,
                        newDescription = req.newDescription,
                        newUrl = req.newUrl,
                        newState = req.newState,
                        newDate = req.newDate,
                        CreatedAt = DateTime.Now,

                    };
                    _newService.Update(newUpdate);
                    return Ok(newUpdate);
                }
                else
                {
                    return BadRequest(new
                    {
                        msg = "No existe registros de noticias con este Id "
                    });
                }

            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
