using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VietRitual.Data.Entities;

namespace VietRitual.Data.Models;

public partial class VietRitualDBContext : IdentityDbContext<User, IdentityRole, string>
{
    public VietRitualDBContext(DbContextOptions<VietRitualDBContext> options) : base(options)
	{
    }

    public DbSet<CeremonyCategory> CeremonyCategories { get; set; }

    public DbSet<CulturalGuideline> CulturalGuidelines { get; set; }

    public DbSet<DeliveryFeeRule> DeliveryFeeRules { get; set; }

    public DbSet<Notification> Notifications { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    public DbSet<Package> Packages { get; set; }

    public DbSet<PackageVariant> PackageVariants { get; set; }

    public DbSet<Payment> Payments { get; set; }

    public DbSet<RefundRequest> RefundRequests { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<SystemConfig> SystemConfigs { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserProfile> UserProfiles { get; set; }

    public DbSet<Wallet> Wallets { get; set; }

    public DbSet<WithdrawalRequest> WithdrawalRequests { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<CeremonyCategory>(entity =>
        {
          entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<CulturalGuideline>(entity =>
        {
           entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.CulturalGuidelines)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DeliveryFeeRule>(entity =>
        {
            entity.Property(e => e.FeeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MaxDistanceKm).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.MinDistanceKm).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
           entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsRead).HasDefaultValue(false);
            entity.Property(e => e.Message)
                .IsRequired()
                .HasMaxLength(1000);
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CancelReason).HasMaxLength(255);
            entity.Property(e => e.CommissionRate)
                .HasDefaultValue(0.10m)
                .HasColumnType("decimal(5, 4)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeliveryAddress)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.IsPaidToVendor).HasDefaultValue(false);
            entity.Property(e => e.OrderStatus)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Pending");
            entity.Property(e => e.PaidToVendorDate).HasColumnType("datetime");
            entity.Property(e => e.PlatformFee)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RefundAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ShippingDistanceKm).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.ShippingFee)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VendorNetAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CustomerProfile).WithMany(p => p.OrderCustomerProfiles)
                .HasForeignKey(d => d.CustomerProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.VendorProfile).WithMany(p => p.OrderVendorProfiles)
                .HasForeignKey(d => d.VendorProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.DetailId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DecorationNote).HasMaxLength(1000);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Quantity).HasDefaultValue(1);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId);

            entity.HasOne(d => d.Variant).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.VariantId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PackageName)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Packages)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.VendorProfile).WithMany(p => p.Packages)
                .HasForeignKey(d => d.VendorProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PackageVariant>(entity =>
        {
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.VariantName)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.Package).WithMany(p => p.PackageVariants)
                .HasForeignKey(d => d.PackageId);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.Property(e => e.PaymentId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.PaidAt).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaymentStatus)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TransactionCode).HasMaxLength(100);

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId);
        });

        modelBuilder.Entity<RefundRequest>(entity =>
        {
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProofImage).HasMaxLength(500);
            entity.Property(e => e.Reason).IsRequired();
            entity.Property(e => e.ResolvedAt).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.CustomerProfile).WithMany(p => p.RefundRequests)
                .HasForeignKey(d => d.CustomerProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Order).WithMany(p => p.RefundRequests)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CustomerProfile).WithMany(p => p.ReviewCustomerProfiles)
                .HasForeignKey(d => d.CustomerProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Order).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.VendorProfile).WithMany(p => p.ReviewVendorProfiles)
                .HasForeignKey(d => d.VendorProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SystemConfig>(entity =>
        {
            entity.Property(e => e.ConfigKey).HasMaxLength(100);
            entity.Property(e => e.ConfigValue).IsRequired();
            entity.Property(e => e.DataType).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ReferenceId).HasMaxLength(50);
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Wallet).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.WalletId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("AspNetUsers")
			.Ignore(u => u.PhoneNumberConfirmed)
				.Ignore(u => u.TwoFactorEnabled)
				.Ignore(u => u.LockoutEnd)
				.Ignore(u => u.LockoutEnabled)
				.Ignore(u => u.AccessFailedCount);

            entity.HasIndex(e => e.Email).IsUnique();

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Active");
        });

		modelBuilder.Entity<IdentityRole>().Ignore(u => u.ConcurrencyStamp);

		modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable(null as string);
		modelBuilder.Entity<IdentityUserToken<string>>().ToTable(null as string);
		modelBuilder.Entity<IdentityUserLogin<string>>().ToTable(null as string);
		modelBuilder.Entity<IdentityUserClaim<string>>().ToTable(null as string);

		modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.Property(e => e.ProfileId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AddressText).HasMaxLength(500);
            entity.Property(e => e.AvatarUrl).HasMaxLength(500);
            entity.Property(e => e.BusinessLicenseNo).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.IsVendor).HasDefaultValue(false);
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RatingAvg)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(3, 2)");
            entity.Property(e => e.ShopName).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.VerificationStatus)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.Property(e => e.Balance)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HeldBalance)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active");

            entity.HasOne(d => d.User).WithMany(p => p.Wallets)
                .HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<WithdrawalRequest>(entity =>
        {
            entity.Property(e => e.AccountHolder)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.AccountNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BankName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.ProcessedDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20);

            entity.HasOne(d => d.Wallet).WithMany(p => p.WithdrawalRequests)
                .HasForeignKey(d => d.WalletId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }
}