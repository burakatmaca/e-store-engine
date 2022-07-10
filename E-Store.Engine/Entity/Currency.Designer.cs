using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Currency> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Currency");

                entity.Property(p => p.Code).HasMaxLength(5);
                entity.Property(p => p.Name).HasMaxLength(50);
                entity.Property(p => p.Symbol).HasMaxLength(5);
                entity.Property(p => p.CurrentRateId).HasField("Current_Rate_Id");

                entity.HasIndex(p => p.Code).IsUnique();
                entity.HasIndex(p => p.CurrentRateId);

                entity.HasData(new Entity.Designer.Currency
                {
                    Id = Guid.Parse("2C700258-2BB0-4E4E-9C58-9234F960B8C1"),
                    Code = "TRY",
                    IsBase = true,
                    Name = "Türk Lirası",
                    Symbol = "₺",
                    CreatedById = Guid.Empty,
                    CreatedDate = DateTime.Parse("2021-09-28 00:00:00")
                });
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Currency : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public Guid? CurrentRateId { get; set; }
        public bool IsBase { get; set; }

        [ForeignKey(nameof(CurrentRateId))]
        public virtual Designer.Currency.Rate CurrentRate { get; set; }

        public virtual ICollection<Designer.Product> Products { get; set; }
        public virtual ICollection<Designer.Currency.Rate> Rates { get; set; }

        public Currency()
        {
            this.Rates = new HashSet<Designer.Currency.Rate>();
        }
    }
}