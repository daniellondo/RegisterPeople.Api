namespace Api.Controllers
{
    using Domain.Dtos;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;

    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PeopleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("RegisterPerson")]
        public async Task<IActionResult> Post([FromBody] RegisterPersonCommand request)
        {
            var result = await _mediator.Send(request);

            return result.Error is null ? Ok(result) : StatusCode((int)result.Error, result);

        }

        [HttpGet()]
        [Route("GetPeople")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetPeopleQuery());

            return result.Error is null ? Ok(result) : StatusCode((int)result.Error, result);
        }
    }
}
