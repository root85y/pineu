using Pineu.Application.MainDomain.DefaultMedicines.Queries;
using Pineu.Application.MainDomain.DefaultMedicines.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain
{
    public class DefaultMedicineController(ISender sender) : ApiController(sender)
    {
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<GetDefaultMedicineResponse>>> GetAll(
            [FromQuery] IEnumerable<MedicineType>? types, [FromQuery] string? search,
            CancellationToken cancellationToken) {
            var query = new GetAllDefaultMedicinesQuery(types, search);
            var res = await Sender.Send(query, cancellationToken);
            return res.IsFailure ? HandleFailure(res) : SuccessResponse(res.Value);
        }
    }
}
