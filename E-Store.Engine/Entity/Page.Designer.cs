using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Page> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Page");
                entity.Property(p => p.Title).HasMaxLength(100);
                entity.Property(p => p.Url).HasMaxLength(250);
                entity.Property(p => p.Title).HasMaxLength(100);

                entity.HasIndex(p => p.IsActive);
                entity.HasIndex(p => p.Url).IsUnique();
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Page : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public PagePositionTypes PositionType { get; set; }
        public bool IsActive { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
    }

    enum PagePositionTypes
    {
        [Display(Name = "Hiçbiri")]
        None = 0,

        [Display(Name = "Alt Bilgi")]
        Footer = 1,

        [Display(Name = "Üst Bilgi")]
        Header = 2
    }
}