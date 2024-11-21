using Pineu.Application.DbBackups.DatabaseBackups.Command;
using Pineu.Application.DbBackups.DatabaseBackups.Query;
using Serilog;

namespace Pineu.API.Controllers.DbBackups {
    public class DatabaseController(ISender sender, IWebHostEnvironment environment) : ApiController(sender) {
        [HttpPost, Authorize("3:7")]
        public async Task<IActionResult> GetBackup(CancellationToken cancellationToken) {
            var res = await Sender.Send(new MakeDatabaseBackupCommand(environment.ContentRootPath), cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            Log.Logger.Information("Backup created with Id {id}", res.Value);
            return SuccessResponse();
        }

        [HttpGet, Route("All"), Authorize(policy: "3:1")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationRequest pagination, CancellationToken cancellationToken) {
            var query = new GetAllDatabaseBackupsQuery(pagination.Page, pagination.PageSize);

            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }

        [HttpDelete, Authorize(policy: "3:5")]
        public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken cancellation) {
            var res = await Sender.Send(new DeleteDatabaseBackupCommand(id), cancellation);
            if (res.IsFailure) return HandleFailure(res);

            Log.Logger.Information("Backup deleted with Id {id}", id);
            return SuccessResponse();
        }
    }
}
