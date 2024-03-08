using HieuVeBan.Abstraction.Interfaces;
using System.Linq.Expressions;

namespace HieuVeBan.Abstraction.EFCore.Configuration
{
    public abstract class BaseEntityConfiguration<T> : BaseConfiguration<T> where T : class, IEntity { }

    public abstract class BaseEntityConfiguration<T, TId> : BaseEntityConfiguration<T> where T : class, IEntity<TId>
    {
        public override Expression<Func<T, object>> KeyExpression => x => x.Id!;
    }
}
