using Pineu.API.DTOs.MainDomain.Seizures;
using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Seizures.Commands;
using Pineu.Application.MainDomain.Seizures.Queries;
using Pineu.Application.MainDomain.Seizures.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain {
    public class SeizureController(ISender sender) : ApiController(sender) {
        [HttpPost, Authorize]
        public async Task<IActionResult> Upsert([FromBody] AddSeizureRequest request, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var command = new AddSeizureCommand(
                UserId: Guid.Parse(userId),
                SeizureDateTime: request.SeizureDateTime,
                SeizureDuration: request.SeizureDuration,
                AttackTypeList: request.AttackTypeList,
                InjuryList: request.InjuryList,
                SeverityOfInjury: request.SeverityOfInjury,
                MentalStatusBeforeSeizure: request.MentalStatusBeforeSeizure,
                AmountOfPhysicalStatusBeforeSeizure: request.AmountOfPhysicalStatusBeforeSeizure,
                GeneralStatusBeforeSeizure: request.GeneralStatusBeforeSeizure,
                SleepQualityAtTheNightBeforeSeizure: request.SleepQualityAtTheNightBeforeSeizure,
                ActivityAtSeizureTime: request.ActivityAtSeizureTime,
                FoodBeforeSeizure: request.FoodBeforeSeizure,
                AmountOfFoodBeforeSeizure: request.AmountOfFoodBeforeSeizure,
                SmokingConsumption: request.SmokingConsumption,
                AlcoholConsumption: request.AlcoholConsumption,
                MentalStatusAfterSeizure: request.MentalStatusAfterSeizure,
                GeneralStatusAfterSeizure: request.GeneralStatusAfterSeizure);
            var res = await Sender.Send(command, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse();
        }
        [HttpGet, Route("All"), Authorize]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetAllSeizuresResponse>>>> GetAll([FromQuery] DateTime? from, DateTime? to,
            [FromQuery] PaginationRequest pagination, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetAllSeizuresQuery(Guid.Parse(userId), from, to, pagination.Page, pagination.PageSize);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("Chart"), Authorize]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetSeizuresChartResponse>>>> GetChart([FromQuery] DateTime? from, DateTime? to, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetSeizuresChartQuery(Guid.Parse(userId), from, to);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
    }
}
