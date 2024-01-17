using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodBoxClassLibrary.Data;

public partial class FoodBoxDB : IdentityDbContext
{
    public FoodBoxDB()
    {
    }

    public FoodBoxDB(DbContextOptions<FoodBoxDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<FavoriteItem> FavoriteItems { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseItem> PurchaseItems { get; set; }

    public virtual DbSet<PurchaseTransaction> PurchaseTransactions { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<RestaurantItem> RestaurantItems { get; set; }
    public virtual DbSet<CartItem> CartItems { get; set; }
    public virtual DbSet<Cart> Carts { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        /*modelBuilder
            .HasPostgresExtension("pg_catalog", "azure")
            .HasPostgresExtension("pg_catalog", "pgaadauth")
            .HasPostgresExtension("pg_cron");*/

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("coupon_pkey");

            entity.ToTable("coupon");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Discount)
                .HasComment("Dollars off, not percent")
                .HasColumnType("money")
                .HasColumnName("discount");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<FavoriteItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("favorite_item_pkey");

            entity.ToTable("favorite_item");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.FavoriteItems)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("favorite_item_customer_id_fkey");

            entity.HasOne(d => d.Item).WithMany(p => p.FavoriteItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("favorite_item_item_id_fkey");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("item_pkey");

            entity.ToTable("item");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Ingredients).HasColumnName("ingredients");
            entity.Property(e => e.Image)
                .HasMaxLength(60)
                .HasColumnName("image");
            entity.Property(e => e.ItemName)
                .HasMaxLength(50)
                .HasColumnName("item_name");
            entity.Property(e => e.SuggestedPrice)
                .HasColumnName("suggested_price")
                .HasColumnType("money");

        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("purchase_pkey");

            entity.ToTable("purchase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CouponId).HasColumnName("coupon_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");
            entity.Property(e => e.TaxRate)
                .HasPrecision(3, 3)
                .HasDefaultValueSql("0.073")
                .HasColumnName("tax_rate");

            entity.HasOne(d => d.Coupon).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.CouponId)
                .HasConstraintName("purchase_coupon_id_fkey");

            entity.HasOne(d => d.Customer).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("purchase_customer_id_fkey");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.RestaurantId)
                .HasConstraintName("purchase_restaurant_id_fkey");
        });

        modelBuilder.Entity<PurchaseItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("purchase_item_pkey");

            entity.ToTable("purchase_item");

            entity.Property(e => e.ActualPrice)
                .HasColumnName("actualprice")
                .HasColumnType("money");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Item).WithMany(p => p.PurchaseItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("purchase_item_item_id_fkey");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseItems)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("purchase_item_purchase_id_fkey");
        });

        modelBuilder.Entity<PurchaseTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("purchase_transaction_pkey");

            entity.ToTable("purchase_transaction");

            entity.Property(e => e.AmountPaid)
                .HasColumnName("amount_paid")
                .HasColumnType("money");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreditCardNumber)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("credit_card_number");
            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseTransactions)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("purchase_transaction_purchase_id_fkey");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("restaurant_pkey");

            entity.ToTable("restaurant");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.RestaurantName)
                .HasMaxLength(50)
                .HasColumnName("restaurant_name");
            entity.Property(e => e.Country)
                .HasMaxLength(60)
                .HasColumnName("country");
            entity.Property(e => e.State)
                .HasMaxLength(60)
                .HasColumnName("state");
            entity.Property(e => e.City)
                .HasMaxLength(60)
                .HasColumnName("city");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
        });

        modelBuilder.Entity<RestaurantItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("restaurant_item_pkey");

            entity.ToTable("restaurant_item");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

            entity.HasOne(d => d.Item).WithMany(p => p.RestaurantItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("restaurant_item_item_id_fkey");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.RestaurantItems)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("restaurant_item_restaurant_id_fkey");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cart_item_pkey");

            entity.ToTable("cart_item");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.CartId).HasColumnName("cart_id");

            entity.Property(e => e.ActualPrice)
                .HasColumnType("money")
                .HasColumnName("actual_price");

            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Item).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cart_item_item_id_fkey");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cart_item_cart_id_fkey");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cart_pkey");

            entity.ToTable("cart");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("cart_customer_id_fkey");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.Carts)
                .HasForeignKey(d => d.RestaurantId)
                .HasConstraintName("cart_restaurant_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
