namespace Pineu.Domain.Entities.MainDomain;
public class Profile : Entity<Guid>
{
    public string? FullName { get; private set; }
    public Gender? Gender { get; private set; }
    public DateTime? Birthdate { get; private set; }
    public MaritalStatus? MaritalStatus { get; private set; }
    public string Mobile { get; private set; }
    public int Score { get; private set; }
    public Guid? DoctorId { get; private set; }
    public string Status { get; private set; }
    public Guid UserId { get; private set; }

    private Profile(Guid id) : base(id) { }
    private Profile(Guid id, string? fullName, Gender? gender, DateTime? birthdate, MaritalStatus? maritalStatus, string mobile, Guid? doctorId, string status, Guid userId) : this(id)
    {
        FullName = fullName;
        Gender = gender;
        Birthdate = birthdate;
        MaritalStatus = maritalStatus;
        Score = 0;
        UserId = userId;
        DoctorId = doctorId;
        Status = status;
        Mobile = mobile;
    }

    public static Profile Create(Guid id, string? fullName, Gender? gender, DateTime? birthdate, MaritalStatus? maritalStatus, string Mobile, Guid? doctorId, string status, Guid userId) =>
        new(id, fullName, gender, birthdate, maritalStatus, Mobile,doctorId, status, userId);

    public void Update(string? fullName, Gender? gender, DateTime? birthdate, MaritalStatus? maritalStatus, Guid? doctorId, string? status)
    {
        FullName = fullName;
        Gender = gender;
        Birthdate = birthdate;
        MaritalStatus = maritalStatus;
        DoctorId = doctorId;
        Status = status;
    }

    public void UpdateScore(int score) => Score += score;
}
