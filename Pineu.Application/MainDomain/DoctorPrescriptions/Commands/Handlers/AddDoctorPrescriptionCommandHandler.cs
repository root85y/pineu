namespace Pineu.Application.MainDomain.DoctorPrescriptions.Commands.Handlers;
internal class AddDoctorPrescriptionCommandHandler(IDoctorPrescriptionRepository repository) : ICommandHandler<AddDoctorPrescriptionCommand, Guid> {
    public async Task<Result<Guid>> Handle(AddDoctorPrescriptionCommand request, CancellationToken cancellationToken) {
        var doctorP = DoctorPrescription.Create(Guid.NewGuid(), request.DoctorName, request.VisitContent, request.VisitedAt, request.UserId);

        await repository.AddAsync(doctorP, cancellationToken);
        return doctorP.Id;
    }
}
