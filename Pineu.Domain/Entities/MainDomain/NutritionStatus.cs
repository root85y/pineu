namespace Pineu.Domain.Entities.MainDomain;
public class NutritionStatus : Entity<Guid> {
    //public List<string> Value { get; private set; }
    //public List<string> Grains { get; private set; }
    //public List<string> SugarAndFat { get; private set; }
    //public List<string> Protein { get; private set; }
    //public List<string> Vegetables { get; private set; }
    //public List<string> Fruits { get; private set; }
    //public List<string> Dairy { get; private set; }
    //public List<string> Beverages { get; private set; }
    public ICollection<DefaultIngredient> Ingredients { get; private set; }
    public ICollection<UserIngredient> UserIngredients { get; private set; }
    public DateOnly Date { get; private set; }
    public Guid UserId { get; private set; }
    private NutritionStatus(Guid id) : base(id) { }
    private NutritionStatus(Guid id, IEnumerable<DefaultIngredient> ingredients, IEnumerable<UserIngredient> userIngredients,
        DateOnly date, Guid userId) : this(id) {
        Date = date;
        UserId = userId;
        Ingredients = ingredients.ToList();
        UserIngredients = userIngredients.ToList();
    }
    public static NutritionStatus Create(Guid id, IEnumerable<DefaultIngredient> ingredients, IEnumerable<UserIngredient> userIngredients,
        DateOnly date, Guid userId) =>
        new(id, ingredients, userIngredients, date, userId);
    public void Update(IEnumerable<DefaultIngredient> ingredients, IEnumerable<UserIngredient> userIngredients) {
        Ingredients = ingredients.ToList();
        UserIngredients = userIngredients.ToList();
    }
}
