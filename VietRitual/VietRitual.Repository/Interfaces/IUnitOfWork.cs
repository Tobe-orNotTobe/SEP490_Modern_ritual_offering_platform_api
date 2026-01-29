using Microsoft.EntityFrameworkCore.Storage;

namespace VietRitual.Repository.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository Users { get; }
		ICeremonyCategoryRepository CeremonyCategories { get; }
		ICulturalGuidelineRepository CulturalGuidelines { get; }
		IDeliveryFeeRuleRepository DeliveryFeeRules { get; }
		INotificationRepository Notifications { get; }
		IOrderDetailRepository OrderDetails { get; }
		IOrderRepository Orders { get; }
		IPackageRepository Packages { get; }
		IPackageVariantRepository PackageVariants { get; }
		IPaymentRepository Payments { get; }
		IRefundRequestRepository RefundRequests { get; }
		IReviewRepository Reviews { get; }
		IRoleRepository Roles { get; }
		ISystemConfigRepository SystemConfigs { get; }
		ITransactionRepository Transactions { get; }
		IUserProfileRepository UserProfiles { get; }
		IWalletRepository Wallets { get; }
		IWithdrawalRequestRepository WithdrawalRequests { get; }

		Task<int> CompleteAsync();
		Task<IDbContextTransaction> BeginTransactionAsync();
	}
}
