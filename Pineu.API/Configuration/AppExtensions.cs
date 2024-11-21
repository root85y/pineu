using Microsoft.Extensions.FileProviders;
using Pineu.API.Middlewares;

namespace Pineu.API.Configuration {
    public static class AppExtensions {
        public static void AddUseStaticFiles(this WebApplication app) {
            app.UseStaticFiles(new StaticFileOptions {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "uploads")),
                RequestPath = "/api/uploads"
            });
        }

        public static void AddMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<LogUserInfoMiddleware>();
        }
    }
}
