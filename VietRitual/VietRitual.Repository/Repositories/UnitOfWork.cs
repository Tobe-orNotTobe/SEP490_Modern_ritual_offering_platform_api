using Microsoft.EntityFrameworkCore.Storage;
using VietRitual.Data.Models;
using VietRitual.Repository.Interfaces;

namespace VietRitual.Repository.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly VietRitualDBContext _context;

		public IUserRepository Users { get; }
		public ICeremonyCategoryRepository CeremonyCategories { get; }
		public ICulturalGuidelineRepository CulturalGuidelines { get; }
		public IDeliveryFeeRuleRepository DeliveryFeeRules { get; }
		public INotificationRepository Notifications { get; }
		public IOrderDetailRepository OrderDetails { get; }
		public IOrderRepository Orders { get; }
		public IPackageRepository Packages { get; }
		public IPackageVariantRepository PackageVariants { get; }
		public IPaymentRepository Payments { get; }
		public IRefundRequestRepository RefundRequests { get; }
		public IReviewRepository Reviews { get; }
		public IRoleRepository Roles { get; }
		public ISystemConfigRepository SystemConfigs { get; }
		public ITransactionRepository Transactions { get; }
		public IUserProfileRepository UserProfiles { get; }
		public IWalletRepository Wallets { get; }
		public IWithdrawalRequestRepository WithdrawalRequests { get; }

		public UnitOfWork(VietRitualDBContext context, IUserRepository userRepository, IDeliveryFeeRuleRepository deliveryFeeRuleRepository, INotificationRepository notificationRepository, IOrderDetailRepository orderDetailRepository, IOrderRepository orderRepository, IPackageRepository packageRepository, IPackageVariantRepository packageVariantRepository, IPaymentRepository paymentRepository, IRefundRequestRepository refundRequestRepository, IReviewRepository reviewRepository, IRoleRepository roleRepository, ISystemConfigRepository systemConfigRepository, ITransactionRepository transactionRepository, IUserProfileRepository userProfileRepository, IWalletRepository walletRepository, IWithdrawalRequestRepository withdrawalRequestRepository)
		{
			_context = context;
			Users = userRepository;
			DeliveryFeeRules = deliveryFeeRuleRepository;
			Notifications = notificationRepository;
			OrderDetails = orderDetailRepository;
			Orders = orderRepository;
			Packages = packageRepository;
			PackageVariants = packageVariantRepository;
			Payments = paymentRepository;
			RefundRequests = refundRequestRepository;
			Reviews = reviewRepository;
			Roles = roleRepository;
			SystemConfigs = systemConfigRepository;
			Transactions = transactionRepository;
			UserProfiles = userProfileRepository;
			Wallets = walletRepository;
			WithdrawalRequests = withdrawalRequestRepository;
		}

		public async Task<int> CompleteAsync()
		{
			return await _context.SaveChangesAsync();
		}
		public async Task<IDbContextTransaction> BeginTransactionAsync()
		{
			return await _context.Database.BeginTransactionAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
