using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TeamBuying.ORM.DBModels
{
    public partial class ContextModel : DbContext
    {
        public ContextModel()
            : base("name=DefaultConnectionString")
        {
        }

        public virtual DbSet<AccountInfo> AccountInfos { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<TeamBuyingDetail> TeamBuyingDetails { get; set; }
        public virtual DbSet<TeamBuying> TeamBuyings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountInfo>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<AccountInfo>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.UserAccount)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasOptional(e => e.AccountInfo)
                .WithRequired(e => e.Account);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.TeamBuyings)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Store>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.TeamBuyings)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TeamBuying>()
                .HasMany(e => e.TeamBuyingDetails)
                .WithRequired(e => e.TeamBuying)
                .WillCascadeOnDelete(false);
        }
    }
}
