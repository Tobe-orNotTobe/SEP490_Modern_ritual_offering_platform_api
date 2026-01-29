using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VietRitual.Repository.Interfaces;
using VietRitual.Repository.Repositories;

namespace VietRitual.Repository
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
		{
			services.ConfigureDatabase(configuration);

			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<ICeremonyCategoryRepository, CeremonyCategoryRepository>();
			services.AddTransient<ICulturalGuidelineRepository, CulturalGuidelineRepository>();
			services.AddTransient<IDeliveryFeeRuleRepository, DeliveryFeeRuleRepository>();
			services.AddTransient<INotificationRepository, NotificationRepository>();
			services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
			services.AddTransient<IOrderRepository, OrderRepository>();
			services.AddTransient<IPackageRepository, PackageRepository>();
			services.AddTransient<IPackageVariantRepository, PackageVariantRepository>();
			services.AddTransient<IPaymentRepository, PaymentRepository>();
			services.AddTransient<IRefundRequestRepository, RefundRequestRepository>();
			services.AddTransient<IReviewRepository, ReviewRepository>();
			services.AddTransient<IRoleRepository, RoleRepository>();
			services.AddTransient<ISystemConfigRepository, SystemConfigRepository>();
			services.AddTransient<ITransactionRepository, TransactionRepository>();
			services.AddTransient<IUserProfileRepository, UserProfileRepository>();
			services.AddTransient<IWalletRepository, WalletRepository>();
			services.AddTransient<IWithdrawalRequestRepository, WithdrawalRequestRepository>();


			//DI Unit of Work
			services.AddTransient<IUnitOfWork, UnitOfWork>();

			return services;
		}
	}
}
