using HieuVeBan.Abstraction.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace HieuVeBan.Abstraction.EFCore.Configuration
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        public abstract Expression<Func<T, object>> KeyExpression { get; }
        public abstract string TableName { get; }
        public virtual string SchemaName => "dbo";

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(KeyExpression!);

            builder.ToTable(TableName, SchemaName);

            // Ignore all soft-deleted entities, use Set<T>().IgnoreQueryFilters() if we want
            // to include them in the query
            if (typeof(ISoftDeletable).IsAssignableFrom(typeof(T)))
            {
                builder.HasQueryFilter(p => !((ISoftDeletable)p).IsDeleted);
            }

            if (typeof(IConcurrencyCheck).IsAssignableFrom(typeof(T)))
            {
                builder.Property<byte[]>("row_version")
                    .IsConcurrencyToken();
            }

            if (typeof(ICreatedDateTime).IsAssignableFrom(typeof(T)))
            {
                builder.Property(p => ((ICreatedDateTime)p).CreatedDateTime)
                    .HasColumnName("created_datetime")
                    .ValueGeneratedOnAdd()
                    .HasValueGenerator<CreatedDateTimeValueGenerator>();
            }
            if (typeof(ICreatedUserId).IsAssignableFrom(typeof(T)))
            {
                builder.Property(p => ((ICreatedUserId)p).CreatedUserId)
                    .HasColumnName("created_userid")
                    .ValueGeneratedOnAdd()
                    .HasValueGenerator<CreatedUserIdValueGenerator>();
            }

            if (typeof(IModificationHistory).IsAssignableFrom(typeof(T)))
            {
                builder.Property(p => ((IModificationHistory)p).UpdatedDateTime)
                    .HasColumnName("updated_datetime")
                    .IsRequired(false);

                builder.Property(p => ((IModificationHistory)p).UpdatedUserId)
                    .HasColumnName("updated_userid")
                    .IsRequired(false);
            }
        }
    }
    public class CreatedDateTimeValueGenerator : ValueGenerator
    {
        public override bool GeneratesTemporaryValues => false;

        protected override object NextValue([NotNull] EntityEntry entry)
        {
            return DateTime.UtcNow;
        }
    }
    public class CreatedUserIdValueGenerator : ValueGenerator
    {
        public override bool GeneratesTemporaryValues => false;

        protected override object NextValue([NotNull] EntityEntry entry)
        {
            var userContext = entry.Context.GetService<IUserContext>();
            return userContext.GetUserId();
        }
    }
}
