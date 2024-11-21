using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Pineu.API.Configurations {
    public class ApiVersionPrefixConvention : IApplicationModelConvention {
        public void Apply(ApplicationModel application) {
            foreach (var controller in application.Controllers) {
                foreach (var selector in controller.Selectors) {
                    var routeModel = selector.AttributeRouteModel;
                    if (routeModel != null) {
                        if (routeModel.Template.Contains("welcome"))
                            routeModel.Template = "api/v{version:apiVersion}/welcome/[controller]";
                        else
                            routeModel.Template = "api/v{version:apiVersion}/[controller]";
                    }
                }
            }
        }
    }
}
