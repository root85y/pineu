namespace Pineu.Domain.Entities.MainDomain;
public class Banner : Entity<Guid> {
    public string Title { get; private set; }
    public string Link { get; private set; }
    public Guid ImageId { get; private set; }
    public bool IsActive { get; private set; }
    private Banner(Guid id) : base(id) { }
    private Banner(Guid id, string title, string link, Guid imageId) : this(id) {
        Title = title;
        Link = link;
        ImageId = imageId;
        IsActive = false;
    }
    public static Banner Create(Guid id, string title, string link, Guid imageId) =>
        new(id, title, link, imageId);
    public void Update(string title, string link, Guid imageId) {
        Title = title;
        Link = link;
        ImageId = imageId;
    }
    public void ToggleActivation() => IsActive = !IsActive;
}
