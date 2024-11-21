using Serilog.Context;

namespace Pineu.API.Middlewares {
    public class LogUserInfoMiddleware(RequestDelegate next) {
        private readonly RequestDelegate next = next;

        public Task Invoke(HttpContext context) {
            LogContext.PushProperty("UserName", context.User.Identity?.Name);

            return next(context);
        }
    }
}
