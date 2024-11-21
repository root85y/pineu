using Pineu.API.DTOs.MainDomain.UserIngredients;
using Pineu.Application.MainDomain.UserIngredients.Commands;
using Pineu.Application.MainDomain.UserIngredients.Queries;
using Pineu.Application.MainDomain.UserIngredients.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain {
    public class UserIngredientController(ISender sender) : ApiController(sender) {
        [HttpPost, Authorize]
        public async Task<IActionResult> Create([FromBody] AddUserIngredientRequest request, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var command = new AddUserIngredientCommand(Guid.Parse(userId), request.Name, request.Type);
            var res = await Sender.Send(command, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse();
        }
        [HttpPut, Authorize]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] AddUserIngredientRequest request, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new UpdateUserIngredientCommand(id, Guid.Parse(userId), request.Name, request.Type);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse();
        }

        [HttpGet, Route("All"), Authorize]
        public async Task<ActionResult<IEnumerable<GetUserIngredientResponse>>> GetAll([FromQuery]string? search,
            [FromQuery]IEnumerable<IngredientCategory>? categories, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetAllUserIngredientsQuery(Guid.Parse(userId), search, categories);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
    }
}
