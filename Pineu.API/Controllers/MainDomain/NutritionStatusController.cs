using Pineu.API.DTOs.MainDomain.NutritionStatuses;
using Pineu.Application.MainDomain.NutritionStatuses.Commands;
using Pineu.Application.MainDomain.NutritionStatuses.Queries;
using Pineu.Application.MainDomain.NutritionStatuses.Queries.DTOs;
using Pineu.Application.MainDomain.Patient.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain {
    public class NutritionStatusController(ISender sender) : ApiController(sender) {
        [HttpPut, Authorize]
        public async Task<IActionResult> Upsert([FromBody] UpsertNutritionStatusRequest request, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var command = new UpsertNutritionStatusCommand(
                Guid.Parse(userId),
                request.DefaultIngredients,
                request.UserIngredients,
                request.Date);
            var res = await Sender.Send(command, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse();
        }
        [HttpGet, Authorize]
        public async Task<ActionResult<GetNutritionStatusResponse>> Get([FromQuery] DateTime? date, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetNutritionStatusByUserIdQuery(Guid.Parse(userId), date);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return SuccessResponse();

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("All"), Authorize]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetAllNutritionStatusesResponse>>>> GetAll([FromQuery] DateTime? from, DateTime? to,
            [FromQuery] PaginationRequest pagination, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetAllNutritionStatusesQuery(from, to, pagination.Page, pagination.PageSize, Guid.Parse(userId));
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("Chart"), Authorize]
        public async Task<ActionResult<GetNutritionStatusChartResponse>> GetChart([FromQuery] DateTime? from, DateTime? to, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetNutritionStatusesChartQuery(Guid.Parse(userId), from, to);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }

    }
}
