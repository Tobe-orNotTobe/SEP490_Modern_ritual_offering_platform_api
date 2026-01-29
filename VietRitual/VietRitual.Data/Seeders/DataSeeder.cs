using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VietRitual.Data.Entities;
using VietRitual.Data.Models;

namespace VietRitual.Data.Seeders
{
	public static class VietRitualDataSeeder
	{
		public static async Task SeedAsync(VietRitualDBContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			// 1. SEED ROLES
			await SeedRoles(roleManager);

			// 2. SEED USERS (4 accounts)
			await SeedUsers(userManager);

			// 3. SEED USER PROFILES
			await SeedUserProfiles(context);

			// 4. SEED CEREMONY CATEGORIES (Admin tạo)
			await SeedCeremonyCategories(context);

			// 5. SEED PACKAGES (Vendor tạo)
			await SeedPackages(context);

			// 6. SEED PACKAGE VARIANTS (Vendor tạo)
			await SeedPackageVariants(context);

			// 7. SEED CULTURAL GUIDELINES
			await SeedCulturalGuidelines(context);

			// 8. SEED DELIVERY FEE RULES
			await SeedDeliveryFeeRules(context);

			// 9. SEED SYSTEM CONFIGS
			await SeedSystemConfigs(context);

			await context.SaveChangesAsync();
		}

		// ==================== 1. ROLES ====================
		private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
		{
			string[] roles = { "Admin", "Staff", "Vendor", "Customer" };

			foreach (var roleName in roles)
			{
				if (!await roleManager.RoleExistsAsync(roleName))
				{
					await roleManager.CreateAsync(new IdentityRole { Name = roleName, NormalizedName = roleName.ToUpper() });
				}
			}
		}

		// ==================== 2. USERS ====================
		private static async Task SeedUsers(UserManager<User> userManager)
		{
			// Admin Account
			var admin = new User
			{
				Id = "admin-001",
				Email = "admin@vietritual.com",
				UserName = "admin@vietritual.com",
				NormalizedEmail = "ADMIN@VIETRITUAL.COM",
				NormalizedUserName = "ADMIN@VIETRITUAL.COM",
				EmailConfirmed = true,
				Status = "Active",
				CreateAt = DateTime.Now
			};
			await CreateUser(userManager, admin, "Admin@123", "Admin");

			// Staff Account
			var staff = new User
			{
				Id = "staff-001",
				Email = "staff@vietritual.com",
				UserName = "staff@vietritual.com",
				NormalizedEmail = "STAFF@VIETRITUAL.COM",
				NormalizedUserName = "STAFF@VIETRITUAL.COM",
				EmailConfirmed = true,
				Status = "Active",
				CreateAt = DateTime.Now
			};
			await CreateUser(userManager, staff, "Staff@123", "Staff");

			// Vendor Account
			var vendor = new User
			{
				Id = "vendor-001",
				Email = "vendor@vietritual.com",
				UserName = "vendor@vietritual.com",
				NormalizedEmail = "VENDOR@VIETRITUAL.COM",
				NormalizedUserName = "VENDOR@VIETRITUAL.COM",
				EmailConfirmed = true,
				Status = "Active",
				CreateAt = DateTime.Now
			};
			await CreateUser(userManager, vendor, "Vendor@123", "Vendor");

			// Customer Account
			var customer = new User
			{
				Id = "customer-001",
				Email = "customer@vietritual.com",
				UserName = "customer@vietritual.com",
				NormalizedEmail = "CUSTOMER@VIETRITUAL.COM",
				NormalizedUserName = "CUSTOMER@VIETRITUAL.COM",
				EmailConfirmed = true,
				Status = "Active",
				CreateAt = DateTime.Now
			};
			await CreateUser(userManager, customer, "Customer@123", "Customer");
		}

		private static async Task CreateUser(UserManager<User> userManager, User user, string password, string role)
		{
			var existingUser = await userManager.FindByEmailAsync(user.Email);
			if (existingUser == null)
			{
				var result = await userManager.CreateAsync(user, password);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, role);
				}
			}
		}

		// ==================== 3. USER PROFILES ====================
		private static async Task SeedUserProfiles(VietRitualDBContext context)
		{
			if (!context.UserProfiles.Any())
			{
				var profiles = new List<UserProfile>
				{
                    // Admin Profile
                    new UserProfile
					{
						ProfileId = Guid.NewGuid().ToString(),
						UserId = "admin-001",
						FullName = "Nguyễn Văn Quản Trị",
						Phone = "0901234567",
						Gender = "Nam",
						DateOfBirth = new DateOnly(1990, 1, 1),
						AddressText = "123 Nguyễn Huệ, Quận 1, TP.HCM",
						Latitude = 10.7756m,
						Longitude = 106.7019m,
						IsVendor = false,
						VerificationStatus = "Verified",
						CreatedAt = DateTime.Now
					},
                    // Staff Profile
                    new UserProfile
					{
						ProfileId = Guid.NewGuid().ToString(),
						UserId = "staff-001",
						FullName = "Trần Thị Nhân Viên",
						Phone = "0902345678",
						Gender = "Nữ",
						DateOfBirth = new DateOnly(1995, 5, 15),
						AddressText = "456 Lê Lợi, Quận 1, TP.HCM",
						Latitude = 10.7740m,
						Longitude = 106.7008m,
						IsVendor = false,
						VerificationStatus = "Verified",
						CreatedAt = DateTime.Now
					},
                    // Vendor Profile
                    new UserProfile
					{
						ProfileId = Guid.NewGuid().ToString(),
						UserId = "vendor-001",
						FullName = "Lê Văn Kinh Doanh",
						Phone = "0903456789",
						Gender = "Nam",
						DateOfBirth = new DateOnly(1985, 3, 20),
						AddressText = "789 Điện Biên Phủ, Quận 3, TP.HCM",
						Latitude = 10.7821m,
						Longitude = 106.6945m,
						IsVendor = true,
						ShopName = "Cúng Bái Tâm Linh",
						BusinessLicenseNo = "0123456789",
						VerificationStatus = "Verified",
						RatingAvg = 4.5m,
						CreatedAt = DateTime.Now
					},
                    // Customer Profile
                    new UserProfile
					{
						ProfileId = Guid.NewGuid().ToString(),
						UserId = "customer-001",
						FullName = "Phạm Thị Khách Hàng",
						Phone = "0904567890",
						Gender = "Nữ",
						DateOfBirth = new DateOnly(1992, 7, 10),
						AddressText = "321 Hai Bà Trưng, Quận 3, TP.HCM",
						Latitude = 10.7886m,
						Longitude = 106.6891m,
						IsVendor = false,
						VerificationStatus = "Verified",
						CreatedAt = DateTime.Now
					}
				};

				await context.UserProfiles.AddRangeAsync(profiles);
				await context.SaveChangesAsync();
			}
		}

		// ==================== 4. CEREMONY CATEGORIES ====================
		private static async Task SeedCeremonyCategories(VietRitualDBContext context)
		{
			if (!context.CeremonyCategories.Any())
			{
				var categories = new List<CeremonyCategory>
				{
					new CeremonyCategory
					{
						Name = "Lễ Thôi Nôi",
						Description = "Lễ mừng em bé tròn 1 tuổi, đánh dấu cột mốc quan trọng trong cuộc đời",
						IsActive = true
					},
					new CeremonyCategory
					{
						Name = "Lễ Khai Trương",
						Description = "Lễ cúng khai trương cửa hàng, công ty, nhà mới để cầu may mắn và phát tài",
						IsActive = true
					},
					new CeremonyCategory
					{
						Name = "Lễ Cúng Giao Thừa",
						Description = "Lễ cúng đón năm mới, tiễn năm cũ để cầu bình an và thịnh vượng",
						IsActive = true
					},
					new CeremonyCategory
					{
						Name = "Lễ Cúng Rằm",
						Description = "Lễ cúng rằm tháng, cúng Phật và tổ tiên vào ngày 15 âm lịch",
						IsActive = true
					},
					new CeremonyCategory
					{
						Name = "Lễ Hội Kỵ",
						Description = "Lễ cúng giỗ tổ tiên, bày tỏ lòng thành kính và nhớ đến người đã khuất",
						IsActive = true
					},
					new CeremonyCategory
					{
						Name = "Lễ Cúng Ông Táo",
						Description = "Lễ cúng Táo Quân ngày 23 tháng Chạp, tiễn ông Táo về trời",
						IsActive = true
					},
					new CeremonyCategory
					{
						Name = "Lễ Động Thổ",
						Description = "Lễ khởi công xây dựng nhà, động thổ để cầu bình an và thuận lợi",
						IsActive = true
					},
					new CeremonyCategory
					{
						Name = "Lễ Cưới Hỏi",
						Description = "Lễ cúng gia tiên trong ngày cưới, xin phép tổ tiên và cầu hạnh phúc",
						IsActive = true
					}
				};

				await context.CeremonyCategories.AddRangeAsync(categories);
				await context.SaveChangesAsync();
			}
		}

		// ==================== 5. PACKAGES ====================
		private static async Task SeedPackages(VietRitualDBContext context)
		{
			if (!context.Packages.Any())
			{
				// Lấy vendor profile ID
				var vendorProfileId = await context.UserProfiles
		.Where(p => p.UserId == "vendor-001")
		.Select(p => p.ProfileId)
		.FirstOrDefaultAsync();

				if (vendorProfileId == null) return;

				var packages = new List<Package>
					{
                        // === PACKAGES CHO LỄ THÔI NÔI ===
                        new Package
						{
							CategoryId = 1,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Thôi Nôi Truyền Thống",
							Description = "Mâm cúng thôi nôi đầy đủ gồm: cơm, canh, thịt luộc, gà luộc, trái cây 5 loại, bánh trôi, bánh chay, hoa quả và hương đèn",
							IsActive = true,
							CreatedAt = DateTime.Now
						},
						new Package
						{
							CategoryId = 1,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Thôi Nôi Cao Cấp",
							Description = "Mâm cúng thôi nôi VIP với hải sản: tôm, cua, mực, cá, cùng trái cây nhập khẩu và bánh kem sinh nhật",
							IsActive = true,
							CreatedAt = DateTime.Now
						},

                        // === PACKAGES CHO LỄ KHAI TRƯƠNG ===
                        new Package
						{
							CategoryId = 2,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Khai Trương Cơ Bản",
							Description = "Mâm cúng khai trương gồm: hoa quả 5 sắc, thịt luộc, gà luộc nguyên con, xôi gấc, bánh pía và hương đèn",
							IsActive = true,
							CreatedAt = DateTime.Now
						},
						new Package
						{
							CategoryId = 2,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Khai Trương Thịnh Vượng",
							Description = "Mâm cúng cao cấp với heo quay nguyên con, gà luộc, cá chép hóa rồng, trái cây cao cấp và lễ vật đặc biệt",
							IsActive = true,
							CreatedAt = DateTime.Now
						},

                        // === PACKAGES CHO LỄ GIAO THỪA ===
                        new Package
						{
							CategoryId = 3,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Giao Thừa Gia Đình",
							Description = "Mâm cúng giao thừa truyền thống: bánh chưng, dưa hành, thịt kho, cá kho, xôi gấc, trái cây và hương nến",
							IsActive = true,
							CreatedAt = DateTime.Now
						},
						new Package
						{
							CategoryId = 3,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Giao Thừa Hoành Tráng",
							Description = "Mâm cúng tất niên cao cấp: bánh tét, giò chả, nem rán, gà luộc, cá chép, trái cây 7 loại",
							IsActive = true,
							CreatedAt = DateTime.Now
						},

                        // === PACKAGES CHO LỄ RẰM ===
                        new Package
						{
							CategoryId = 4,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Rằm Đơn Giản",
							Description = "Mâm cúng rằm gồm: cơm, rau luộc, đậu hũ, trái cây, bánh trôi bánh chay, hương đèn",
							IsActive = true,
							CreatedAt = DateTime.Now
						},
						new Package
						{
							CategoryId = 4,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Rằm Phật Bà",
							Description = "Mâm cúng rằm Phật Bà cao cấp: chay 7 món, hoa tươi, trái cây nhập khẩu, bánh pía, bánh trung thu",
							IsActive = true,
							CreatedAt = DateTime.Now
						},

                        // === PACKAGES CHO LỄ GIỖ ===
                        new Package
						{
							CategoryId = 5,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Giỗ Tiết Kiệm",
							Description = "Mâm cúng giỗ đầy đủ: cơm, canh, thịt luộc, cá, rau luộc, trái cây và hương đèn",
							IsActive = true,
							CreatedAt = DateTime.Now
						},
						new Package
						{
							CategoryId = 5,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Giỗ Trọng Thể",
							Description = "Mâm cúng giỗ 12 món cao cấp: gà luộc, thịt luộc, giò chả, bánh, trái cây 5 loại, rượu, nước ngọt",
							IsActive = true,
							CreatedAt = DateTime.Now
						},

                        // === PACKAGES CHO LỄ ÔNG TÁO ===
                        new Package
						{
							CategoryId = 6,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Ông Táo Tiêu Chuẩn",
							Description = "Mâm cúng ông Táo: cá chép, xôi gấc, trái cây, bánh kẹo, mũ, áo giấy, vàng mã đầy đủ",
							IsActive = true,
							CreatedAt = DateTime.Now
						},
						new Package
						{
							CategoryId = 6,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Ông Táo Sang Trọng",
							Description = "Mâm cúng Táo Quân cao cấp: 3 con cá chép, hoa quả nhập khẩu, bánh kẹo Châu Âu, lễ vật đặc biệt",
							IsActive = true,
							CreatedAt = DateTime.Now
						},

                        // === PACKAGES CHO LỄ ĐỘNG THỔ ===
                        new Package
						{
							CategoryId = 7,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Động Thổ Cơ Bản",
							Description = "Mâm cúng động thổ: thịt luộc, gà luộc, cá luộc, trái cây, xôi gấc, hương đèn, vàng mã",
							IsActive = true,
							CreatedAt = DateTime.Now
						},
						new Package
						{
							CategoryId = 7,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Động Thổ May Mắn",
							Description = "Mâm cúng khởi công cao cấp: heo quay, gà luộc, trái cây 7 loại, xôi gấc, rượu, vàng mã đầy đủ",
							IsActive = true,
							CreatedAt = DateTime.Now
						},

                        // === PACKAGES CHO LỄ CƯỚI ===
                        new Package
						{
							CategoryId = 8,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Cưới Hỏi Truyền Thống",
							Description = "Mâm cúng lễ cưới: gà luộc, thịt luộc, trái cây, bánh phu thê, trầu cau, rượu đẹp",
							IsActive = true,
							CreatedAt = DateTime.Now
						},
						new Package
						{
							CategoryId = 8,
							VendorProfileId = vendorProfileId,
							PackageName = "Mâm Cúng Cưới Hỏi Hoàn Hảo",
							Description = "Mâm cúng cưới VIP: heo quay, gà luộc, hải sản, trái cây cao cấp, bánh kem, rượu ngoại",
							IsActive = true,
							CreatedAt = DateTime.Now
						}
					};

					context.ChangeTracker.Clear();	

					await context.Packages.AddRangeAsync(packages);
					await context.SaveChangesAsync();
				}
			}

		// ==================== 6. PACKAGE VARIANTS ====================
		private static async Task SeedPackageVariants(VietRitualDBContext context)
		{
			if (!context.PackageVariants.Any())
			{
				var variants = new List<PackageVariant>
				{
                    // VARIANTS CHO PACKAGE 1: Mâm Cúng Thôi Nôi Truyền Thống
					new PackageVariant {
						PackageId = 1, VariantName = "Gói Tiết Kiệm", Price = 850000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Đầy đủ lễ vật cơ bản: Xôi chè (12 phần nhỏ, 1 phần lớn), gà luộc, trầu cau, giấy cúng và trà rượu."
					},
					new PackageVariant {
						PackageId = 1, VariantName = "Gói Tiêu Chuẩn", Price = 1200000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Bao gồm gói tiết kiệm kèm thêm heo quay miếng (500g), hoa tươi (Cát tường/Đồng tiền) và bộ đồ bốc chọn nghề cho bé."
					},
					new PackageVariant {
						PackageId = 1, VariantName = "Gói Cao Cấp", Price = 1800000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Gói thịnh soạn với gà ta thả vườn lớn, heo quay nguyên con 5kg, trái cây ngũ quả nhập khẩu và hỗ trợ bày biện mâm cúng đẹp mắt tại nhà."
					},

					// VARIANTS CHO PACKAGE 2: Mâm Cúng Thôi Nôi Cao Cấp
					new PackageVariant {
						PackageId = 2, VariantName = "Gói VIP Cơ Bản", Price = 2500000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Mâm cúng phong cách hiện đại với xôi chè tạo hình nghệ thuật, hải sản (tôm hùm/cua), bánh kem sinh nhật và trang trí hoa tươi cao cấp."
					},

					// VARIANTS CHO PACKAGE 3: Mâm Cúng Khai Trương Cơ Bản
					new PackageVariant {
						PackageId = 3, VariantName = "Gói Tiết Kiệm", Price = 1200000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Dành cho cửa hàng nhỏ: Gà luộc, xôi gấc, bộ tam sên, trái cây ngũ quả, hoa cúc và giấy cúng khai trương."
					},
					new PackageVariant {
						PackageId = 3, VariantName = "Gói Phát Tài", Price = 2500000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Bao gồm heo quay sữa, bánh hỏi, gà trống thiến, trái cây cao cấp, rượu nếp và hỗ trợ văn khấn khai trương chuyên nghiệp."
					},

					// VARIANTS CHO PACKAGE 4: Mâm Cúng Khai Trương Thịnh Vượng
					new PackageVariant {
						PackageId = 4, VariantName = "Gói Đại Cát", Price = 6000000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Gói đặc biệt cho công ty lớn: Heo quay đại, cá chép hóa rồng, tháp trái cây nghệ thuật, hoa Lan hồ điệp và đội ngũ hỗ trợ sắp đặt lễ vật đúng phong thủy."
					},

					// VARIANTS CHO PACKAGE 11: Mâm Cúng Ông Táo
					new PackageVariant {
						PackageId = 11, VariantName = "Gói Đầy Đủ", Price = 750000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Bao gồm 3 con cá chép sống, xôi gấc, bộ mũ áo ông táo (2 nam 1 nữ), tiền vàng và mâm cơm mặn tiễn ông Táo về trời."
					},

					// VARIANTS CHO PACKAGE 12: Mâm Cúng Ông Táo Sang Trọng
					new PackageVariant {
						PackageId = 12, VariantName = "Gói Sang Trọng", Price = 1500000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Mâm lễ tươm tất với 3 con cá chép đỏ lớn, mâm cơm mặn 7 món, xôi gấc cá chép, trái cây nhập khẩu và bộ đồ thế cao cấp."
					},
					new PackageVariant {
						PackageId = 12, VariantName = "Gói Hoàn Hảo", Price = 2200000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Lễ vật đặc biệt: Cá chép rồng, heo quay miếng, rượu ngoại, bình hoa thanh liễu/ly và đội ngũ hỗ trợ sắp xếp mâm cúng đúng hướng."
					},

					// VARIANTS CHO PACKAGE 13: Mâm Cúng Động Thổ Cơ Bản
					new PackageVariant {
						PackageId = 13, VariantName = "Gói Tiết Kiệm", Price = 1200000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Lễ vật cơ bản để xin phép Thổ Địa: Gà luộc, bộ tam sên (thịt luộc, trứng, tôm), xôi gấc, rượu trắng, muối gạo và giấy cúng động thổ."
					},
					new PackageVariant {
						PackageId = 13, VariantName = "Gói Tiêu Chuẩn", Price = 1800000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Bổ sung thêm mâm ngũ quả lớn, hoa cúc kim cương, bánh kẹo loại tốt và hỗ trợ bài văn khấn động thổ chuẩn phong thủy."
					},

					// VARIANTS CHO PACKAGE 14: Mâm Cúng Động Thổ May Mắn
					new PackageVariant {
						PackageId = 14, VariantName = "Gói May Mắn", Price = 3000000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Dành cho công trình lớn: Heo quay nguyên con, gà trống thiến, mâm ngũ quả nghệ thuật, rượu trà đầy đủ và bộ vàng mã động thổ cao cấp."
					},
					new PackageVariant {
						PackageId = 14, VariantName = "Gói Đại Phát", Price = 4500000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Gói cao cấp nhất: Heo quay đại, cá lóc nướng, tháp xôi gấc, hoa ly/hoa lan nhập khẩu và hỗ trợ nhân viên bày biện mâm cúng chuyên nghiệp."
					},

					// VARIANTS CHO PACKAGE 15: Mâm Cúng Cưới Hỏi Truyền Thống
					new PackageVariant {
						PackageId = 15, VariantName = "Gói Tiêu Chuẩn", Price = 1500000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Mâm cúng gia tiên ngày cưới: Gà luộc buộc cánh tiên, xôi gấc hỷ, trái cây ngũ quả, trầu cau têm cánh phượng và rượu trà."
					},
					new PackageVariant {
						PackageId = 15, VariantName = "Gói Cao Cấp", Price = 2500000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Bổ sung heo quay miếng, bánh phu thê (xu xê) truyền thống, hoa tươi trang trí bàn thờ gia tiên và cặp đèn cầy long phụng lớn."
					},

					// VARIANTS CHO PACKAGE 16: Mâm Cúng Cưới Hỏi Hoàn Hảo
					new PackageVariant {
						PackageId = 16, VariantName = "Gói VIP", Price = 4000000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Mâm cúng thịnh soạn: Heo quay sữa nguyên con, tháp trái cây kết rồng phượng, bánh hỷ loại 1, hoa tươi cao cấp và bộ lễ vật đầy đủ theo phong tục vùng miền."
					},
					new PackageVariant {
						PackageId = 16, VariantName = "Gói Premium", Price = 6000000, IsActive = true, CreatedAt = DateTime.Now,
						Description = "Đẳng cấp Marketplace: Bao gồm toàn bộ lễ vật gói VIP cộng với tôm hùm/hải sản cao cấp, rượu ngoại thượng hạng và trang trí mâm lễ nghệ thuật theo yêu cầu."
					}
				};

				await context.PackageVariants.AddRangeAsync(variants);
				await context.SaveChangesAsync();
			}
		}

		// ==================== 7. CULTURAL GUIDELINES ====================
		private static async Task SeedCulturalGuidelines(VietRitualDBContext context)
		{
			if (!context.CulturalGuidelines.Any())
			{
				var guidelines = new List<CulturalGuideline>
				{
					new CulturalGuideline
					{
						CategoryId = 1,
						Title = "Hướng dẫn cúng thôi nôi",
						Description = "Lễ thôi nôi thường được tổ chức vào đúng ngày bé tròn 1 tuổi âm lịch. Mâm cúng cần có đủ cơm, canh, thịt, gà, trái cây và bánh trôi bánh chay. Nên chọn giờ cúng hợp tuổi cha mẹ và bé.",
						IsActive = true,
						CreatedAt = DateTime.Now
					},
					new CulturalGuideline
					{
						CategoryId = 2,
						Title = "Hướng dẫn cúng khai trương",
						Description = "Lễ khai trương nên chọn ngày giờ tốt, hợp tuổi chủ. Mâm cúng cần có heo quay hoặc gà luộc nguyên con, trái cây 5 sắc màu, bánh kẹo và hương hoa. Cúng thần Tài và Thổ Công trước khi khai trương.",
						IsActive = true,
						CreatedAt = DateTime.Now
					},
					new CulturalGuideline
					{
						CategoryId = 3,
						Title = "Hướng dẫn cúng giao thừa",
						Description = "Lễ giao thừa cúng vào đêm 30 Tết, trước khi giao thời. Mâm cúng gồm bánh chưng, dưa hành, thịt kho, cá kho, xôi gấc. Cúng ông bà tổ tiên và các vị thần trong nhà.",
						IsActive = true,
						CreatedAt = DateTime.Now
					},
					new CulturalGuideline
					{
						CategoryId = 6,
						Title = "Hướng dẫn cúng Táo Quân",
						Description = "Cúng Táo Quân vào ngày 23 tháng Chạp âm lịch. Mâm cúng cần có 3 con cá chép sống, trái cây, xôi gấc, bánh kẹo, mũ áo giấy và vàng mã. Cúng xong thả cá chép về trời.",
						IsActive = true,
						CreatedAt = DateTime.Now
					}
				};

				await context.CulturalGuidelines.AddRangeAsync(guidelines);
				await context.SaveChangesAsync();
			}
		}

		// ==================== 8. DELIVERY FEE RULES ====================
		private static async Task SeedDeliveryFeeRules(VietRitualDBContext context)
		{
			if (!context.DeliveryFeeRules.Any())
			{
				var deliveryRules = new List<DeliveryFeeRule>
				{
					new DeliveryFeeRule { MinDistanceKm = 0, MaxDistanceKm = 5, FeeAmount = 30000, IsActive = true },
					new DeliveryFeeRule { MinDistanceKm = 5, MaxDistanceKm = 10, FeeAmount = 50000, IsActive = true },
					new DeliveryFeeRule { MinDistanceKm = 10, MaxDistanceKm = 15, FeeAmount = 70000, IsActive = true },
					new DeliveryFeeRule { MinDistanceKm = 15, MaxDistanceKm = 20, FeeAmount = 100000, IsActive = true },
					new DeliveryFeeRule { MinDistanceKm = 20, MaxDistanceKm = 30, FeeAmount = 150000, IsActive = true },
					new DeliveryFeeRule { MinDistanceKm = 30, MaxDistanceKm = 50, FeeAmount = 250000, IsActive = true }
				};

				await context.DeliveryFeeRules.AddRangeAsync(deliveryRules);
				await context.SaveChangesAsync();
			}
		}

		// ==================== 9. SYSTEM CONFIGS ====================
		private static async Task SeedSystemConfigs(VietRitualDBContext context)
		{
			if (!context.SystemConfigs.Any())
			{
				var configs = new List<SystemConfig>
				{
					new SystemConfig { ConfigKey = "CommissionRate", ConfigValue = "0.10", DataType = "decimal", Description = "Tỷ lệ hoa hồng platform thu từ vendor (10%)" },
					new SystemConfig { ConfigKey = "MinOrderAmount", ConfigValue = "300000", DataType = "decimal", Description = "Giá trị đơn hàng tối thiểu (300,000 VNĐ)" },
					new SystemConfig { ConfigKey = "MaxOrderAmount", ConfigValue = "10000000", DataType = "decimal", Description = "Giá trị đơn hàng tối đa (10,000,000 VNĐ)" },
					new SystemConfig { ConfigKey = "FreeShippingThreshold", ConfigValue = "1000000", DataType = "decimal", Description = "Miễn phí ship cho đơn từ 1,000,000 VNĐ" },
					new SystemConfig { ConfigKey = "VendorPayoutDay", ConfigValue = "7", DataType = "int", Description = "Số ngày thanh toán cho vendor sau khi hoàn thành đơn" },
					new SystemConfig { ConfigKey = "RefundTimeLimit", ConfigValue = "24", DataType = "int", Description = "Thời hạn yêu cầu hoàn tiền (24 giờ)" },
					new SystemConfig { ConfigKey = "SupportEmail", ConfigValue = "support@vietritual.com", DataType = "string", Description = "Email hỗ trợ khách hàng" },
					new SystemConfig { ConfigKey = "SupportPhone", ConfigValue = "1900123456", DataType = "string", Description = "Hotline hỗ trợ 24/7" }
				};

				await context.SystemConfigs.AddRangeAsync(configs);
				await context.SaveChangesAsync();
			}
		}
	}
}