using Pineu.API.DTOs.MainDomain.UserMedicines;
using Pineu.Application.MainDomain.UserMedicines.Commands;
using Pineu.Application.MainDomain.UserMedicines.Queries;
using Pineu.Application.MainDomain.UserMedicines.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain
{
    public class UserMedicineController(ISender sender) : ApiController(sender)
    {
        [HttpPost, Authorize]
        public async Task<IActionResult> Create([FromBody] AddUserMedicineRequest request, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var command = new AddUserMedicineCommand(request.Name, request.Type, Guid.Parse(userId));
            var res = await Sender.Send(command, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpPut, Authorize]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] AddUserMedicineRequest request, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new UpdateUserMedicineCommand(id, request.Name, request.Type);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse();
        }

        [HttpGet, Route("All"), Authorize]
        public async Task<ActionResult<IEnumerable<GetUserMedicineResponse>>> GetAll([FromQuery] string? search,
            [FromQuery] IEnumerable<MedicineType>? types, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetAllUserMedicinesQuery(Guid.Parse(userId), search, types);
            var res = await Sender.Send(query, cancellationToken);
            return res.IsFailure ? HandleFailure(res) : SuccessResponse(res.Value);
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<GetUserMedicineResponse>>> Get([FromQuery] Guid id,
            CancellationToken cancellationToken) {
            var query = new GetUserMedicineByIdQuery(id);
            var res = await Sender.Send(query, cancellationToken);
            return res.IsFailure ? HandleFailure(res) : SuccessResponse(res.Value);
        }
    }
}
