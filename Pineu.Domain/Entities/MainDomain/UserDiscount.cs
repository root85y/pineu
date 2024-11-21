namespace Pineu.Domain.Entities.MainDomain;
public class UserDiscount : Entity<Guid> {
    public string DiscountCode { get; private set; }
    public Guid DiscountId { get; private set; }
    public Discount Discount { get; private set; }

    public Guid UserId { get; private set; }

    private UserDiscount(Guid id) : base(id) { }
    private UserDiscount(Guid id, Guid discountId, Guid userId) : this(id) {
        DiscountCode = MakeDiscountCode();
        DiscountId = discountId;
        UserId = userId;
    }

    public static UserDiscount Create(Guid id, Guid discountId, Guid userId) =>
        new(id, discountId, userId);

    private static string MakeDiscountCode() {
        Random rnd = new();
        return rnd.Next(100000, 999999).ToString();
    }
}
