using Pineu.Application.MainDomain.DefaultIngredients.Queries;
using Pineu.Application.MainDomain.DefaultIngredients.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain
{
    public class DefaultIngredientController(ISender sender) : ApiController(sender)
    {
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<GetAllDefaultIngredientResponse>>> GetAll([FromQuery]string? search,
            [FromQuery]IEnumerable<IngredientCategory>? categories, CancellationToken cancellationToken) {
            var query = new GetAllDefaultIngredientQuery(search, categories);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
    }
}