namespace Nameless.Bookshelf.Contracts.Common {
    public record Pagination<T>(T[] Items, int Count)
        where T : class;
}
