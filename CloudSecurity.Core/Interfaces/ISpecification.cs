using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CloudSecurity.Core.Interfaces
{
    public interface ISpecification<TEntity>
    {
        Expression<Func<TEntity,bool>> Criteria { get; }
        List<Expression<Func<TEntity, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        void AddInclude(Expression<Func<TEntity, object>> includeExpression);
    }
}
