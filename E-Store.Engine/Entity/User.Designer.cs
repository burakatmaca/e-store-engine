using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.User> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("User");
                entity.Property(p => p.Email).HasMaxLength(100);
                entity.Property(p => p.Name).HasMaxLength(75);
                entity.Property(p => p.Password).HasMaxLength(50);

                entity.HasIndex(p => p.IsActive);
                entity.HasIndex(p => p.Email).IsUnique();
                entity.HasIndex(p => new { p.Email, p.Password, p.IsActive });

                entity.HasData(new Entity.Designer.User
                {
                    Id = Guid.Parse("F27A97E7-2A3D-4E36-8FCF-FF81423CAA4C"),
                    Password = "ef703472436a2f40273a8a2bd15d4b81",
                    Email = "admin@aparatcii.com",
                    IsActive = true,
                    Name = "Admin",
                    CreatedById = Guid.Empty,
                    CreatedDate = DateTime.Parse("2021-09-28 00:00:00")
                });
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class User : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool PasswordChangeRequired { get; set; }
    }
}