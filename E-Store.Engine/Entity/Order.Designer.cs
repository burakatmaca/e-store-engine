using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Order> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Order");
                entity.Property(p => p.Code).HasMaxLength(25);
                entity.Property(p => p.Title).HasMaxLength(150);
                entity.Property(p => p.RelatedPerson).HasMaxLength(150);
                entity.Property(p => p.CityTownId).HasField("City_Town_Id");
                entity.Property(p => p.CityId).HasField("City_Id");
                entity.Property(p => p.TaxOffice).HasMaxLength(100);
                entity.Property(p => p.TaxNumber).HasMaxLength(25);
                entity.Property(p => p.ShippingCityTownId).HasField("Shipping_City_Town_Id");
                entity.Property(p => p.ShippingCityId).HasField("Shipping_City_Id");
                entity.Property(p => p.ShippingTracking).HasMaxLength(150);
                entity.Property(p => p.CurrentStatusId).HasField("Current_Status_Id");

                entity.HasIndex(p => p.Code).IsUnique();
                entity.HasIndex(p => p.CurrentStatusId);

                entity.HasOne(p => p.City).WithMany(p => p.OrderInvoices).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.CityTown).WithMany(p => p.OrderInvoices).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.ShippingCity).WithMany(p => p.OrderShippings).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.ShippingCityTown).WithMany(p => p.OrderShippings).OnDelete(DeleteBehavior.Restrict);
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Order : BaseEntity
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string RelatedPerson { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Guid CityTownId { get; set; }
        public Guid CityId { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string ShippingAddress { get; set; }
        public Guid ShippingCityTownId { get; set; }
        public Guid ShippingCityId { get; set; }
        public double Total { get; set; }
        public double TaxTotal { get; set; }
        public double ShippingTotal { get; set; }
        public string ShippingTracking { get; set; }
        public PaymentTypes PaymentType { get; set; }
        public Guid? CurrentStatusId { get; set; }
        public string Note { get; set; }

        [ForeignKey(nameof(CurrentStatusId))]
        public virtual Designer.Order.Status CurrentStatus { get; set; }

        [ForeignKey(nameof(CityId))]
        public virtual Designer.City City { get; set; }

        [ForeignKey(nameof(CityTownId))]
        public virtual Designer.City.Town CityTown { get; set; }

        [ForeignKey(nameof(ShippingCityId))]
        public virtual Designer.City ShippingCity { get; set; }

        [ForeignKey(nameof(ShippingCityTownId))]
        public virtual Designer.City.Town ShippingCityTown { get; set; }

        public virtual ICollection<Designer.Order.Product> Products { get; set; }
        public virtual ICollection<Designer.Order.Status> Statuses { get; set; }

        public Order()
        {
            this.Products = new HashSet<Designer.Order.Product>();
            this.Statuses = new HashSet<Designer.Order.Status>();
        }
    }

    enum PaymentTypes
    {
        [Display(Name = "Havale / EFT ile Ödeme")]
        BankTransfer = 0,

        [Display(Name = "Kredi Kartı ile Ödeme")]
        CreditCard = 1
    }
}