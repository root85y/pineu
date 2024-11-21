using Pineu.API.DTOs.SystemFiles;
using Pineu.Application.SystemFiles.Commands;
using Serilog;

namespace Pineu.API.Controllers.SystemFiles {
    public class SystemFileController(ISender sender, IWebHostEnvironment environment) : ApiController(sender) {
        [HttpPost, Authorize, DisableRequestSizeLimit, RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue,
        ValueLengthLimit = int.MaxValue)]
        public async Task<IActionResult> Create([FromForm] AddSystemFileRequest request, CancellationToken cancellationToken) {
            byte[] content;
            using (var memoryStream = new MemoryStream()) {
                await request.File.CopyToAsync(memoryStream, cancellationToken);
                content = memoryStream.ToArray();
            }

            var path = Path.Combine(environment.ContentRootPath, SystemFilesSettings.UploadPath);

            var res = await Sender.Send(new AddSystemFileCommand(content, path, Path.GetExtension(request.File.FileName)),
                cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            Log.Logger.Information("File \"{@object}\" created with Id {id}", request, res.Value);

            return SuccessResponse(res.Value);
        }
    }
}
