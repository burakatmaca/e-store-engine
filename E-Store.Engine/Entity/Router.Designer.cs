using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Router> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Router");
                entity.Property(p => p.Source).HasMaxLength(250);
                entity.Property(p => p.Destination).HasMaxLength(250);

                entity.HasIndex(p => p.Source).IsUnique();
                entity.HasIndex(p => p.Destination);
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Router : BaseEntity
    {
        public string Source { get; set; }
        public string Destination { get; set; }
    }
}