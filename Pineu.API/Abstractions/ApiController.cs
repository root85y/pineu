using Microsoft.AspNetCore.RateLimiting;
using System.Text.Json.Serialization;

namespace Pineu.API.Abstractions {
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public abstract class ApiController : ControllerBase {
        protected readonly ISender Sender;

        protected ApiController(ISender sender) {
            Sender = sender;
        }

        protected ActionResult HandleFailure(Result result) =>
            result switch {
                { IsSuccess: true } => throw new InvalidOperationException(),
                IValidationResult validationResult =>
                    BadRequest(
                        CreateProblemDetails(
                            "Validation Error", StatusCodes.Status400BadRequest,
                            //result.Error,
                            validationResult.Errors.First().Message)),
                _ =>
                    BadRequest(
                        CreateProblemDetails(
                            "Bad Request",
                            StatusCodes.Status400BadRequest,
                            result.Error.Message))
            };


        protected ActionResult SuccessResponse(object? data = null) =>
            Ok(new {
                Message = ResponseMessages.Success,
                data
            });

        private static OverrideProblemDetails CreateProblemDetails(string title, int status, string error, Error[]? errors = null) =>
            new() {
                //Title = title,
                Message = error,
                //Status = status,
                Extensions = { { nameof(errors), errors } }
            };
    }


    class OverrideProblemDetails : ProblemDetails {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyOrder(-2)]
        public string? Message { get; set; }
    }
}
