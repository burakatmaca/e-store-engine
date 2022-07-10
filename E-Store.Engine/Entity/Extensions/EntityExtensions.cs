using System;

namespace E_Store.Engine.Entity
{
    static class EntityExtensions
    {
        internal static TObject Set<TObject, TValue>(this TObject target, System.Linq.Expressions.Expression<Func<TObject, TValue>> memberLamda, TValue value)
            where TObject : Designer.IBaseEntity
        {
            if (memberLamda.Body is System.Linq.Expressions.MemberExpression memberSelectorExpression)
            {
                if (memberSelectorExpression.Member is System.Reflection.PropertyInfo property)
                    property?.SetValue(target, value);
            }
            return target;
        }
        internal static void BaseEntityConfiguration<TEntity>(this Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TEntity> entityBuilder,
            Action<Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TEntity>> action = null) where TEntity : class, Designer.IBaseEntity
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.CreatedById).HasField("Created_By_Id");
            entityBuilder.Property(p => p.UpdatedById).HasField("Updated_By_Id");

            action?.Invoke(entityBuilder);
        }
    }
}
