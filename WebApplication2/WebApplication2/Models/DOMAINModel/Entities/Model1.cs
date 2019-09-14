namespace WebApplication2.Models.DOMAINModel.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FyzrukShopEntities : DbContext
    {
        public FyzrukShopEntities()
            : base("name=Fyzruk")
        {
        }

        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .Property(e => e.Price)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Item>()
                .HasOptional(e => e.Image)
                .WithRequired(e => e.Item);
        }
    }
}
