namespace Pineu.Domain.Entities.MainDomain;
public class Discount : Entity<Guid> {
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int OffPercentage { get; private set; }
    public DateTime ExpiresAt { get; private set; }
    public int ScoreCost { get; private set; }
    public IEnumerable<UserDiscount> UserDiscounts { get; private set; }

    public Guid StoreId { get; private set; }
    public Store Store { get; private set; }

    private Discount(Guid id) : base(id) { }
    private Discount(Guid id, string title, string description, int offPercentage, DateTime expiresAt, int scoreCost, Guid storeId)
        : this(id) {
        Title = title;
        Description = description;
        OffPercentage = offPercentage;
        ExpiresAt = expiresAt;
        ScoreCost = scoreCost;
        StoreId = storeId;
    }

    public static Discount Create(Guid id, string title, string description, int offPercentage,
        DateTime expiresAt, int scoreCost, Guid storeId) =>
        new(id, title, description, offPercentage, expiresAt, scoreCost, storeId);

    public void Update(string title, string description, int offPercentage,
        DateTime expiresAt, int scoreCost, Guid storeId) {
        Title = title;
        Description = description;
        OffPercentage = offPercentage;
        ExpiresAt = expiresAt;
        ScoreCost = scoreCost;
        StoreId = storeId;
    }
}
