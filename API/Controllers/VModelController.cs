using application.BusinessLogic;
using application.BusinessLogic.Get;
using application.BusinessLogic.Post;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VModelCOntroller : ControllerBase
    {
        private readonly IMediator _imediatr;

        public VModelCOntroller(IMediator imediatr)
        {
            _imediatr = imediatr;
        }


        [HttpPost]
        public async Task<ActionResult<ModelResponse>> PostRequest([FromBody] PostVModelRequest request)
        {
            var res = await _imediatr.Send(request);

            return Ok(res);

        }

        [HttpGet]
        public async Task<ActionResult<List<ModelResponse>>> GetAll([FromQuery] GetVModelRequest request)
        {
            var response = await _imediatr.Send(request);

            return Ok(response);
        }

    }
}
