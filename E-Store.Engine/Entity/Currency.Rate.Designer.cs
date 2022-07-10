using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Currency.Rate> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Currency_Rate");
                entity.Property(p => p.CurrencyId).HasField("Currency_Id");

                entity.HasOne(p => p.Currency).WithMany(p => p.Rates).OnDelete(DeleteBehavior.Cascade);

                entity.HasData(new Entity.Designer.Currency.Rate
                {
                    Id = Guid.Parse("8D14F03E-5A81-45C2-BDCB-5D63EE0A86C6"),
                    CurrencyId = Guid.Parse("2C700258-2BB0-4E4E-9C58-9234F960B8C1"),
                    Amount = 1,
                    Date = DateTime.Parse("2021-09-28 00:00:00"),
                    CreatedById = Guid.Empty,
                    CreatedDate = DateTime.Parse("2021-09-28 00:00:00")
                });
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Currency
    {
        internal partial class Rate : BaseEntity
        {
            public Guid CurrencyId { get; set; }
            public DateTime Date { get; set; }
            public double Amount { get; set; }

            [ForeignKey(nameof(CurrencyId))]
            public virtual Designer.Currency Currency { get; set; }

            public virtual ICollection<Designer.Order.Product> Orders { get; set; }
        }
    }
}