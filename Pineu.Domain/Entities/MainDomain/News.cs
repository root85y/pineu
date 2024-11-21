namespace Pineu.Domain.Entities.MainDomain;
public class News : Entity<Guid> {
    public string Title { get; private set; }
    public string Body { get; private set; }
    public string Link { get; private set; }
    public Guid ImageId { get; private set; }
    private News(Guid id) : base(id) { }
    private News(Guid id, string title, string body, string link, Guid imageId) : this(id) {
        Title = title;
        Body = body;
        Link = link;
        ImageId = imageId;
    }
    public static News Create(Guid id, string title, string body, string link, Guid imageId) =>
        new(id, title, body, link, imageId);
    public void Update(string title, string body, string link, Guid imageId) {
        Title = title;
        Body = body;
        Link = link;
        ImageId = imageId;
    }
}
