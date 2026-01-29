using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VietRitual.Common.Helper;
using VietRitual.Repository;
using VietRitual.Service.Interfaces;
using VietRitual.Service.Services;

namespace VietRitual.Service
{
	public static class DependencyInjcection
	{
		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddRepository(configuration);

			services.AddScoped<APIResponse>();

			services.AddTransient<IUserService, UserService>();
			services.AddTransient<ICeremonyCategoryService, CeremonyCategoryService>();
			services.AddTransient<ICulturalGuidelineService, CulturalGuidelineService>();
			services.AddTransient<IDeliveryFeeRuleService, DeliveryFeeRuleService>();
			services.AddTransient<INotificationService, NotificationService>();
			services.AddTransient<IOrderDetailService, OrderDetailService>();
			services.AddTransient<IOrderService, OrderService>();
			services.AddTransient<IPackageService, PackageService>();
			services.AddTransient<IPackageVariantService, PackageVariantService>();
			services.AddTransient<IPaymentService, PaymentService>();
			services.AddTransient<IRefundRequestService, RefundRequestService>();
			services.AddTransient<IReviewService, ReviewService>();
			services.AddTransient<IRoleService, RoleService>();
			services.AddTransient<ISystemConfigService, SystemConfigService>();
			services.AddTransient<IUserProfileService, UserProfileService>();
			services.AddTransient<IWalletService, WalletService>();
			services.AddTransient<IWithdrawalRequestService, WithdrawalRequestService>();

			return services;
		}
	}
}
