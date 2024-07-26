namespace Nameless.Bookshelf.Domain.Common {
    public abstract class EntityBase<TKey>
        where TKey : IComparable<TKey> {
        public required TKey ID { get; set; }
    }
}
