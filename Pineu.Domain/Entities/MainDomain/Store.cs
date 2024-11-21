namespace Pineu.Domain.Entities.MainDomain;
public class Store : Entity<Guid> {
    public string Title { get; private set; }
    public Guid? ImageId { get; private set; }
    public string Address { get; private set; }
    public string PhoneNumber { get; private set; }

    public ICollection<Discount> Discounts { get; private set; }
    private Store(Guid id) : base(id) { }
    private Store(Guid id, string title, Guid? imageId, string address, string phoneNumber) : this(id) {
        Title = title;
        ImageId = imageId;
        Address = address;
        PhoneNumber = phoneNumber;
    }
    public static Store Create(Guid id, string title, Guid? imageId, string address, string phoneNumber) =>
        new(id, title, imageId, address, phoneNumber);
    public void Update(string title, Guid? imageId, string address, string phoneNumber) {
        Title = title;
        ImageId = imageId;
        Address = address;
        PhoneNumber = phoneNumber;
    }
}
