namespace Pineu.Domain.Entities.MainDomain;
public class Doctor : Entity<Guid>
{
    private Doctor(Guid id) : base(id)
    {
    }

    private Doctor(
        Guid DoctorId,
        string? firstName,
        string? lastName,
        string mobile,
        string nationalCode,
        string personnelCode,
        Gender? gender,
        Guid? coverId,
        DateOnly? birthday)
        : this(DoctorId)
    {
        FirstName = firstName;
        LastName = lastName;
        Mobile = mobile;
        NationalCode = nationalCode;
        PersonnelCode = personnelCode;
        Gender = gender;
        CoverId = coverId;
        Birthday = birthday;
    }

    /// <summary>
    /// Gets the first name of the Doctor member.
    /// </summary>
    public string? FirstName { get; private set; }

    /// <summary>
    /// Gets the last name of the Doctor member.
    /// </summary>
    public string? LastName { get; private set; }

    /// <summary>
    /// Gets the mobile number of the Doctor member.
    /// </summary>
    public string Mobile { get; private set; }

    /// <summary>
    /// Gets the national code of the Doctor member.
    /// </summary>
    public string NationalCode { get; private set; }

    /// <summary>
    /// Gets the personnel code of the Doctor member.
    /// </summary>
    public string PersonnelCode { get; private set; }

    /// <summary>
    /// Gets the gender of the Doctor member.
    /// </summary>
    public Gender? Gender { get; private set; }

    /// <summary>
    /// Gets the cover ID associated with the Doctor member.
    /// </summary>
    public Guid? CoverId { get; private set; }


    /// <summary>
    /// Gets the birthday of the Doctor member.
    /// </summary>
    public DateOnly? Birthday { get; private set; }

    /// <summary>
    /// Gets the career associated with the Doctor member.
    /// </summary>
    public static Doctor Create(
        Guid id,
        string? firstName,
        string? lastName,
        string mobile,
        string nationalCode,
        string personnelCode,
        Gender? gender,
        Guid? coverId,
        DateOnly? birthday
    )
    {
        var Doctor = new Doctor(
            id,
            firstName,
            lastName,
            mobile,
            nationalCode,
            personnelCode,
            gender,
            coverId,
            birthday
        );

        return Doctor;
    }

    /// <summary>
    /// Updates the properties of an existing Doctor member instance.
    /// </summary>
    public void Update(
    //Doctor Doctor,
        string? firstName,
        string? lastName,
        string mobile,
        string nationalCode,
        string personnelCode,
        Gender? gender,
        Guid? coverId,
        DateOnly? birthday
    )
    {
        FirstName = firstName;
        LastName = lastName;
        Mobile = mobile;
        NationalCode = nationalCode;
        PersonnelCode = personnelCode;
        Birthday = birthday;
        Gender = gender;
        CoverId = coverId;
    }
}
