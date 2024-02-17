using System.Linq.Expressions;

namespace Core.Specifications
{
    // We use this when we work with Generic interfaces.
    public interface ISpecification<T>
    {
        // This expression takes a function and this function takes a type
        // and returns a boolean. The Criteria could be if the Product has a type Id of 1 etc.
        Expression<Func<T, bool>> Criteria { get; }
        // We return an object here. It is the most generic thing in C#.
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}