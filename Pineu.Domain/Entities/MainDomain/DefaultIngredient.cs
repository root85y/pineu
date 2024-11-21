namespace Pineu.Domain.Entities.MainDomain;
public class DefaultIngredient : Entity<int> {
    public string EnglishLabel { get; private set; }
    public string FarsiLabel { get; private set; }
    public IngredientCategory Category { get; private set; }

    public ICollection<NutritionStatus> NutritionStatuses { get; private set; }

    private DefaultIngredient(int id) : base(id) { }
    private DefaultIngredient(int id, string englishLabel, string farsiLabel) : this(id) {
        EnglishLabel = englishLabel;
        FarsiLabel = farsiLabel;
    }
}
