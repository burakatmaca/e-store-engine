using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Project> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Project");
                entity.Property(p => p.Title).HasMaxLength(100);
                entity.Property(p => p.Url).HasMaxLength(250);
                entity.Property(p => p.MetaTitle).HasMaxLength(100);

                entity.HasIndex(p => p.Url).IsUnique();
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Project : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
    }
}