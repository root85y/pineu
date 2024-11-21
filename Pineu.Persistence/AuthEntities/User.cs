namespace Pineu.Persistence.AuthEntities;

public class User : IdentityUser<Guid> {
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    //public string? Layout { get; set; }
    //public string? RefreshToken { get; set; }
    //public DateTime RefreshTokenExpire { get; set; }
    public bool IsActive { get; set; }

    //public bool IsRemoved { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? RemovedAt { get; set; }
}