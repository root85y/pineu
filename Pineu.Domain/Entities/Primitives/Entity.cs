namespace Pineu.Domain.Entities.Primitives;

public abstract class Entity<T> : IEquatable<Entity<T>> {
    protected Entity(T id) {
        Id = id;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    protected Entity() {
    }

    public T Id { get; private init; }
    public DateTime CreatedAt { get; private init; } = DateTime.Now;
    public DateTime UpdatedAt { get; private init; } = DateTime.Now;
    public DateTime? DeletedAt { get; private set; }
    //public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();
    //private readonly List<IDomainEvent> _domainEvents = [];

    public static bool operator ==(Entity<T>? first, Entity<T>? second) {
        if (first is null && second is null) return true;
        else return first is not null && second is not null && first.Equals(second);
    }

    public static bool operator !=(Entity<T>? first, Entity<T>? second) => !(first == second);


    public bool Equals(Entity<T>? other) {
        if (other is null) {
            return false;
        }

        if (other.GetType() != GetType()) {
            return false;
        }

        if (other.Id?.GetType() != Id?.GetType())
            return false;

        return other.Id.Equals(Id);
    }

    public override bool Equals(object? obj) {
        if (obj is null) {
            return false;
        }

        if (obj.GetType() != GetType()) {
            return false;
        }

        if (obj is not Entity<T> entity) {
            return false;
        }

        if (entity.Id?.GetType() != Id?.GetType())
            return false;

        return entity.Id.Equals(Id);
    }

    public override int GetHashCode() => Id.GetHashCode() * 41;
    //public void ClearDomainEvents() => _domainEvents.Clear();
    //protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}