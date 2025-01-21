using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Seizures.Queries.DTOs;

namespace Pineu.Application.MainDomain.Seizures.Queries.Handlers {
    internal class GetTodeySeizuresQueryHandler(ISeizureRepository repository) : IQueryHandler<GetTodeySeizuresQuery , int> {
        public async Task<Result<int>> Handle(GetTodeySeizuresQuery request, CancellationToken cancellationToken) {
            int seizures = await repository.GetTodaySeizuresAsync(request.DoctorId, request.PatientData, cancellationToken);

            return (seizures);
        }
    }
}
