namespace Pineu.Application.MainDomain.Doctor.Queries.Handlers {
    internal class GetNameOfDoctorWithIdQueryHandler(IDoctorRepository repository)
        : IQueryHandler<GetNameOfDoctorWithIdQuery, string> {
        public async Task<Result<string>> Handle(GetNameOfDoctorWithIdQuery request, CancellationToken cancellationToken) {
            var Doctor = await repository.GetAsync(request.DoctorId, cancellationToken);
            var DoctorName = $"{Doctor.FirstName} {Doctor.LastName}";
            return DoctorName;
        }
    }
}
