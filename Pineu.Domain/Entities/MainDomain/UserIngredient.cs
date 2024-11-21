namespace Pineu.Domain.Entities.MainDomain {
    public class UserIngredient : Entity<Guid> {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public IngredientCategory Category { get; private set; }

        public ICollection<NutritionStatus> NutritionStatuses { get; private set; }

        private UserIngredient(Guid id) : base(id) { }
        private UserIngredient(Guid id, Guid userId, string name, IngredientCategory category) : this(id) {
            UserId = userId;
            Name = name;
            Category = category;
        }

        public static UserIngredient Create(Guid userId, string name, IngredientCategory category) =>
            new(Guid.NewGuid(), userId, name, category);

        public void Update(string name, IngredientCategory category) {
            Name = name;
            Category = category;
        }
    }
}
