using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pineu.API.DTOs.MainDomain.Patient;
using Pineu.Application.MainDomain.Profiles.Commands;
using Pineu.Application.MainDomain.Profiles.Queries;

namespace Pineu.API.Controllers.MainDomain {
    public class AdminPanelController(ISender sender) : ApiController(sender) {

        [HttpPost, Route("PatientRegistration")]
        public async Task<IActionResult> Patient([FromBody] PatientRegistrationRequest request, CancellationToken cancellationToken) {

            var PatientCount = 0;
            //var 
            return Accepted(new {
                request.PhoneNumber
            });

        }
    }
}