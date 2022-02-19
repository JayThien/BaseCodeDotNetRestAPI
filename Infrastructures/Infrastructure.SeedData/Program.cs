using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using ExcelDataReader;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
    class Program
    {
        public static IServiceProvider _serviceProvider;
        private static string[] phoneNumbers = {
                    "0355588574",
                    "0355546955",
                    "0355555200",
                    "0855548984",
                    "0555514285",
                    "0855503017",
                    "0555523699",
                    "0855513847",
                    "0355573996",
                    "0555525810",
                    "0755554223",
                    "0555524749",
                    "0855532923",
                    "0955556718",
                    "0555585764",
                    "0355508801",
                    "0755584934",
                    "0855507075",
                    "0855547575",
                    "0355551926",
                    "0955537549",
                    "0355580911",
                    "0555512149",
                    "0355592938",
                    "0955560551",
                    "0355561663",
                    "0555535370",
                    "0355511144",
                    "0955503605",
                    "0755515410",
                    "0555545296",
                    "0955555254",
                    "0555508570",
                    "0755591878",
                    "0555529299",
                    "0355514955",
                    "0755535544",
                    "0355589452",
                    "0355556488",
                    "0355504094",
                    "0555531188",
                    "0555502244",
                    "0855544028",
                    "0855524646",
                    "0555522134",
                    "0555579750",
                    "0855555762",
                    "0855547031",
                    "0555508407",
                    "0555585031",
                    "0855512576",
                    "0555510636",
                    "0555570339",
                    "0555571998",
                    "0755589385",
                    "0955513069",
                    "0555511416",
                    "0555570386",
                    "0355582519",
                    "0355512379",
                    "0855561376",
                    "0555516933",
                    "0555527802",
                    "0555559709",
                    "0555570553",
                    "0355549943",
                    "0355590290",
                    "0555581568",
                    "0555569866",
                    "0555533713",
                    "0555507649",
                    "0555540353",
                    "0355529760",
                    "0555592052",
                    "0355523238",
                    "0555500904",
                    "0355503776",
                    "0555595412",
                    "0955515374",
                    "0855503357",
                    "0555546811",
                    "0755577215",
                    "0355526347",
                    "0955536142",
                    "0355556265",
                    "0355516781",
                    "0555578149",
                    "0855510543",
                    "0955533100",
                    "0555513514",
                    "0555503118",
                    "0555580543",
                    "0355535496",
                    "0755503325",
                    "0555595638",
                    "0955501017",
                    "0355576387",
                    "0355595024",
                    "0355512255",
                    "0755589721",
                    "0555518256",
                    "0755504580",
                    "0355515482",
                    "0755597666",
                    "0355561952",
                    "0555529440",
                    "0355501403",
                    "0355572927",
                    "0355503977",
                    "0555592599",
                    "0355526339",
                    "0955574828",
                    "0955559722",
                    "0355557335",
                    "0355504664",
                    "0955588086",
                    "0355577036",
                    "0555540549",
                    "0555539220",
                    "0555507318",
                    "0755502204",
                    "0955548005",
                    "0555584932",
                    "0355559803",
                    "0355525987",
                    "0355554867",
                    "0855598409",
                    "0855528245",
                    "0355515747",
                    "0355520498",
                    "0755537526",
                    "0955595390",
                    "0755510606",
                    "0955510250",
                    "0355582642",
                    "0555518316",
                    "0355578860",
                    "0955502753",
                    "0555552954",
                    "0755587448",
                    "0355564063",
                    "0755547408",
                    "0555540915",
                    "0955598495",
                    "0355520112",
                    "0955529702",
                    "0755502003",
                    "0855558024",
                    "0555549600",
                    "0755542668",
                    "0555540585",
                    "0955511357",
                    "0355507893",
                    "0555515990",
                    "0855569313",
                    "0555524093",
                    "0355562576",
                    "0355512898",
                    "0355579284",
                    "0355548298",
                    "0355531993",
                    "0555540602",
                    "0355593623",
                    "0855571786",
                    "0555548623",
                    "0955557930",
                    "0555515232",
                    "0555522686",
                    "0755595269",
                    "0355519395",
                    "0555569294",
                    "0855574922",
                    "0955501940",
                    "0355572171",
                    "0355524637",
                    "0355521444",
                    "0555548934",
                    "0555575111",
                    "0355504402",
                    "0355581482",
                    "0555547236",
                    "0555533412",
                    "0955543397",
                    "0555571935",
                    "0355573818",
                    "0355558414",
                    "0355589030",
                    "0555545272",
                    "0555551351",
                    "0555568741",
                    "0355529200",
                    "0555563633",
                    "0555575135",
                    "0355590904",
                    "0355554266",
                    "0755557871",
                    "0555576923",
                    "0555565443",
                    "0755529757",
                    "0755570413"
                };
        private static string[] names = {
                    "Đặng Tuấn Anh",
                    "Hoàng Đức Anh",
                    "Lưu Trang Anh",
                    "Phạm Hoàng Anh",
                    "Phạm Thị Hiền Anh",
                    "Phạm Khắc Việt Anh",
                    "Đỗ Hoàng Gia Bảo",
                    "Trần Thị Minh Châu",
                    "Tăng Phương Chi",
                    "Gan Feng Du",
                    "Phạm Tiến Dũng",
                    "Nguyễn Thái Dương",
                    "Trần An Dương",
                    "Mạc Trung Đức",
                    "Vũ Hương Giang",
                    "Nguyễn Thị Ngân Hà",
                    "Nguyễn Lê Hiếu",
                    "Phạm Xuân Hòa",
                    "Khoa Minh Hoàng",
                    "Nguyễn Hữu Hiệp Hoàng",
                    "Nguyễn Mạnh Hùng",
                    "Nguyễn Vũ Gia Hưng",
                    "Trần Tuấn Hưng",
                    "Phạm Gia Minh",
                    "Đỗ Hoàng Mỹ",
                    "Đỗ Quang Ngọc",
                    "Đàm Yến Nhi",
                    "Đoàn Hoàng Sơn",
                    "Nguyễn Công Thành",
                    "Bùi Phương Thảo",
                    "Nguyễn Hương Thảo",
                    "Tô Diệu Thảo",
                    "Vũ Phương Thảo",
                    "Đặng Huyền Thi",
                    "Đặng Thành Trung",
                    "Trịnh Thiên Trường",
                    "Lê Khánh Vy",
                    "Phạm Vũ Ngọc Diệp",
                    "Trần Đức Dương",
                    "Nguyễn Quốc Huy",
                    "Phạm Bảo Liên",
                    "Đinh Thùy Linh",
                    "Nguyễn Thùy Linh",
                    "Đỗ Hà Linh",
                    "Vũ Thùy Linh",
                    "Đỗ Thùy Linh",
                    "Hoàng Nhật Mai",
                    "Nguyễn Trọng Minh",
                    "Ngô Gia Minh",
                    "Mai Hoàng Minh",
                    "Đỗ Hải Nam",
                    "Trần Bảo Ngân",
                    "Trần Kim Ngân",
                    "Đỗ Minh Ngọc",
                    "Bùi Khánh Ngọc",
                    "Trần Uyên Nhi",
                    "Phạm Đặng Gia Như",
                    "Lê Tất Hoàng Phát",
                    "Đào Tuấn Phong",
                    "Nguyễn Phú Hải Phong",
                    "Trần Trung Phong",
                    "Bùi Thành Tài",
                    "Đặng Thanh Thảo",
                    "Nguyễn Trường Thịnh",
                    "Dương Phúc Thịnh",
                    "Nguyễn Minh Thư",
                    "Bùi Trung Minh Trí",
                    "Hoàng Quốc Trung",
                    "Vũ Hữu Minh Tường",
                    "Lê Thị Phương Vy",
                    "Nguyễn Hùng Anh",
                    "Nguyễn Ngọc Anh",
                    "Mai Tùng Bách",
                    "Nguyễn Trần Bình",
                    "Vũ Điệp Chi",
                    "Phạm Văn Đạt",
                    "Hoàng An Đông",
                    "Vũ Trung Đức",
                    "Phí Vũ Trí Đức",
                    "Đặng Gia Hân",
                    "Lưu Ngọc Hiền",
                    "Phạm Ngọc Hiếu",
                    "Phạm Sỹ Hiếu",
                    "Phạm Phương Hoa",
                    "Vũ Đức Huy",
                    "Vũ Thanh Huyền",
                    "Phạm Thu Huyền",
                    "Nguyễn Tuấn Hưng",
                    "Trần Đức Hưng",
                    "Nguyễn Tiến Hưng",
                    "Lê Nguyễn Diệu Hương",
                    "Nguyễn Hữu Ngọc Khánh",
                    "Bùi Nam Khánh",
                    "Đinh Ngọc Khánh",
                    "Hồ Nguyễn Minh Khuê",
                    "Phạm Vũ Diệp Lam",
                    "Đinh Hoàng Tùng Lâm",
                    "Lê Quang Long",
                    "Phạm Thị Phương Mai",
                    "Lê Trần Tuấn Minh",
                    "Nguyễn Thị Bích Ngọc",
                    "Lê Trung Nguyên",
                    "Lê Quỳnh Nhi",
                    "Nguyễn Tuyết Anh Nhi",
                    "Đinh Phú Sang",
                    "Đào Duy Thái",
                    "Hà Duy Anh",
                    "Đồng Đức Anh",
                    "Vũ Ngân Anh",
                    "Trần Mai Quỳnh Anh",
                    "Nguyễn Thị Tùng Chi",
                    "Phạm Quang Dũng",
                    "Nguyễn Tùng Dương",
                    "Phạm Đức Đạt ",
                    "Nguyễn Hải Đông ",
                    "Nguyễn Duy Đức",
                    "Nguyễn Vũ Minh Đức",
                    "Trịnh Việt Đức",
                    "Lưu Hương Giang",
                    "Quản Gia Hân ",
                    "Nguyễn Trọng Hiếu ",
                    "Nguyễn Quang Hùng",
                    "Trần Gia Huy",
                    "Đặng Vũ Huy",
                    "Phạm Ngọc Huyền",
                    "Trần Ngọc Khánh",
                    "Bùi Đức Kiên ",
                    "Bùi Hải Lâm ",
                    "Dương Khánh Linh",
                    "Trần Huy Hoàng Linh",
                    "Trần Nhật Long",
                    "Trần Đức Lương",
                    "Nguyễn Đức Minh",
                    "Đoàn Hải Minh",
                    "Mai Xuân Minh ",
                    "Bùi Xuân Nam ",
                    "Bùi Khánh Ngọc ",
                    "Mai Phương Ngọc ",
                    "Nguyễn Yến Nhi ",
                    "Đinh Ngọc Quỳnh Như",
                    "Nguyễn Minh Phương",
                    "Nguyễn Minh Quân ",
                    "Nguyễn Thúy Quỳnh ",
                    "Lê Thị Minh Tâm ",
                    "Hoàng Đức Thành",
                    "Nguyễn Đức Thiện",
                    "Phạm Thị Thu Trang",
                    "Lương Thị Thúy An",
                    "Bùi Quỳnh Anh",
                    "Phạm Phương Anh",
                    "Phạm Hoàng Bách",
                    "Đoàn Việt Bách",
                    "Trần Lê Gia Bảo",
                    "Bùi Ngọc Chi",
                    "Ng Hoàng Kim Cương",
                    "Hoàng Trung Dũng",
                    "Phạm Anh Duy",
                    "Bùi Công Duy",
                    "Bùi Nhật Dương",
                    "Đỗ Duy Đoàn",
                    "Đỗ Duy Hải",
                    "Lương Bảo Hân",
                    "Đỗ Gia Hân",
                    "Phạm Minh Hiển",
                    "Nguyễn Đức Hiếu",
                    "Phạm Gia Huy",
                    "Nguyễn Minh Huyền",
                    "Bùi Công Khanh",
                    "Nguyễn Hoàng Lâm",
                    "Văn Tiến Long",
                    "Hoàng Hải Minh",
                    "Nguyễn Tuấn Minh",
                    "Đỗ Trần Nam",
                    "Trần Đức Nam",
                    "Nguyễn Bảo Nam",
                    "Trần Vũ Hà Ngân",
                    "Phạm Trần Lan Nhi",
                    "Nguyễn Đăng Phong",
                    "Bùi An Phú",
                    "Đỗ Đức Phúc",
                    "Nguyễn Hồng Phúc",
                    "Bùi Đàm Mai Phương",
                    "Phạm Minh Phương",
                    "Nguyễn Hữu Thành",
                    "Lại Hương Thảo",
                    "Nguyễn Quang Thiện",
                    "Ngô Kim Khánh",
                    "Bùi Lam Khê",
                    "An Gia Linh",
                    "Đoàn Phạm Ngọc Linh",
                    "Nguyễn Hoàng Linh",
                    "Trương Hồng Linh",
                    "Phạm Xuân Mai",
                    "Vũ Hoàng Mai",
                    "Dương Gia Minh",
                    "Hà Trần Thảo Minh",
                    "Nguyễn Quỳnh Nga",
                    "Bùi Thảo Ngọc",
                    "Phạm Hải Đức Phát",
                    "Nguyễn Việt Phong"
                };

        static void Main(string[] args)
        {
            Console.WriteLine("Starting to seed data");
            _serviceProvider = ConfigureService(new ServiceCollection(), args);
            using (var dbContext = _serviceProvider.GetService<ApplicationDbContext>())
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    SeedDataAsync(dbContext).Wait();
                    transaction.Commit();
                    Console.WriteLine("Commit all seed");
                }
            }
            Console.WriteLine("Seed data successfull");
        }

        public static IServiceProvider ConfigureService(IServiceCollection services, string[] args)
        {
            var dbContextFactory = new DesignTimeDbContextFactory();

            services.AddLogging();
            services.AddScoped<ApplicationDbContext>(p => dbContextFactory.CreateDbContext(args));
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;

                // User settings
                options.User.RequireUniqueEmail = true;
            });
            return services.BuildServiceProvider();
        }
        private static async Task SeedDataAsync(ApplicationDbContext dbContext)
        {
            SeedRoleDataAsync(dbContext).Wait();
            SeedSysadmin(dbContext).Wait();
            SeedCustomer(dbContext).Wait();
            SeedArea(dbContext).Wait();
            SeedRestaurant(dbContext).Wait();
            SeedMenuAsync(dbContext).Wait();
            SeedProduct(dbContext).Wait();
            SeedBaseProduct(dbContext).Wait();
        }
        private static async Task SeedRoleDataAsync(ApplicationDbContext dbContext)
        {
            if (!await dbContext.Set<Role>().AnyAsync())
            {
                Console.WriteLine("Start to seed role info");
                var roleManagement = _serviceProvider.GetService<RoleManager<Role>>();
                await roleManagement.CreateAsync(new Role
                {
                    Name = RoleName.ADMIN.ToString(),
                });
                await roleManagement.CreateAsync(new Role
                {
                    Name = RoleName.AREA_MANAGER.ToString(),
                });
                await roleManagement.CreateAsync(new Role
                {
                    Name = RoleName.RESTAURANT_MANAGER.ToString(),
                });
                await roleManagement.CreateAsync(new Role
                {
                    Name = RoleName.STAFF.ToString(),
                });
                await roleManagement.CreateAsync(new Role
                {
                    Name = RoleName.CUSTOMER.ToString(),
                });
            }
            Console.WriteLine("Finish seed role info");
        }
        private static async Task SeedSysadmin(ApplicationDbContext dbContext)
        {
            if (!dbContext.Users.Any(p => p.PhoneNumber == "0338279632"))
            {
                var userManagement = _serviceProvider.GetService<UserManager<User>>();
                var user = new User
                {
                    Fullname = "Đoàn Quang Đức",
                    UserName = "0338279632",
                    Email = "duc.doan0102@gmail.com",
                    PhoneNumber = "0338279632",
                    DateOfBirth = new DateTime(1997, 2, 1),
                    Gender = true,
                    Status = UserStatus.ACTIVATE,
                    SearchName = StringUtil.GenerateSearchString("Đoàn Quang Đức")
                };
                var userResult = await userManagement.CreateAsync(user, "Password@1");
                if (userResult.Succeeded)
                {
                    await userManagement.AddToRoleAsync(user, RoleName.ADMIN);
                }

                string confirmEmailToken = await userManagement.GenerateEmailConfirmationTokenAsync(user);
                await userManagement.ConfirmEmailAsync(user, confirmEmailToken);
                return;
            }
        }

        public static async Task SeedArea(ApplicationDbContext dbContext)
        {
            Console.WriteLine("Start to seed area");
            if (!dbContext.Set<Area>().Any())
            {
                List<Area> allAreas = new List<Area>()
                {
                    new Area()
                    {
                        Name = "All",
                        Code = "ALL",
                        Country = Country.Vietnam
                    },
                    new Area()
                    {
                        Name = "All",
                        Code = "ALL",
                        Country = Country.Thailand
                    },
                    new Area()
                    {
                        Name = "All",
                        Code = "ALL",
                        Country = Country.Philippines
                    },
                    new Area()
                    {
                        Name = "All",
                        Code = "ALL",
                        Country = Country.HongKong
                    },
                    new Area()
                    {
                        Name = "All",
                        Code = "ALL",
                        Country = Country.Slovakia
                    },
                    new Area()
                    {
                        Name = "All",
                        Code = "ALL",
                        Country = Country.CzechRepublic
                    },
                };
                List<Area> areas = new List<Area>()
                {
                    new Area()
                    {
                        Name = "Thành phố Hồ Chí Minh",
                        Code = "HCM",
                        Country = Country.Vietnam
                    },
                      new Area()
                    {
                        Name = "Đà Nẵng",
                        Code = "DN",
                        Country = Country.Vietnam
                    },
                        new Area()
                    {
                        Name = "Hà Nội",
                        Code = "HN",
                        Country = Country.Vietnam
                    },
                    new Area()
                    {
                        Name = "Taguig",
                        Code = "TAG",
                        Country = Country.Philippines
                    },
                    new Area()
                    {
                        Name = "Makati",
                        Code = "MAK",
                        Country = Country.Philippines
                    },
                    new Area()
                    {
                        Name = "Bangkok",
                        Code = "BK",
                        Country = Country.Thailand
                    },
                     new Area()
                    {
                        Name = "Koh Samui",
                        Code = "KS",
                        Country = Country.Thailand
                    },
                    new Area()
                    {
                        Name = "Phuket",
                        Code = "PHU",
                        Country = Country.Thailand
                    },
                };
                await dbContext.AddRangeAsync(allAreas);
                await dbContext.AddRangeAsync(areas);
                await dbContext.SaveChangesAsync();
            }
            Console.WriteLine("Finish seed area");
        }
        private static async Task SeedRestaurant(ApplicationDbContext dbContext)
        {
            if (!dbContext.Set<Restaurant>().Any())
            {
                Console.WriteLine("Start to seed Restaurant");

                await dbContext.AddRangeAsync(
                    new List<Restaurant>()
                    {
                        new Restaurant()
                        {
                            Name = "Saigon Pearl",
                            Address ="92A Nguyễn Hữu Cảnh, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh 700000, Vietnam",
                            Email = "",
                            PhoneNumber ="+84972697654",
                            Longitude = 10.790284341787673,
                            Latitude = 106.71798355968933,
                            OpenTime =  "3/12/2020 11:00",
                            CloseTime =  "3/12/2020 22:00",
                            ReservationLink = "https://widget.guestplan.com/?i=9a12b86df5ecbae4b281ca66076eeab9c05a19c5",
                            Country = Country.Vietnam
                        },
                        new Restaurant()
                        {
                            Name = "HAI BA TRUNG",
                            Address ="74/1 Hai Bà Trưng, Bến Nghé, Quận 1, Thành phố Hồ Chí Minh 100000, Vietnam",
                            Email = "",
                            PhoneNumber ="+842838272090",
                            Longitude = 10.778302374536688,
                            Latitude = 106.70353842853099,
                            OpenTime =  "3/12/2020 11:00",
                            CloseTime =  "3/12/2020 22:00",
                            ReservationLink = "https://widget.guestplan.com/?i=ec33fcea178e7befe3476dd5e4e93971b56b117f",
                            Country = Country.Vietnam
                        },
                        new Restaurant()
                        {
                            Name = "An Phu",
                            Address ="Lot L1-01, 02, 88 Song Hành, An Phú, Quận 2, Thành phố Hồ Chí Minh 71106, Vietnam",
                            Email = "",
                            PhoneNumber ="+84981214921",
                            Longitude = 10.80211963686763,
                            Latitude =106.74783833042243,
                            OpenTime =  "3/12/2020 11:00",
                            CloseTime =  "3/12/2020 22:00",
                            ReservationLink = "https://widget.guestplan.com/?i=d646545ccd2fff879a9884b291fdc468eb9a3803",
                            Country = Country.Vietnam
                        },
                        new Restaurant()
                        {
                            Name = "PHU MY HUNG",
                            Address ="103 Tôn Dật Tiên, Phú Mỹ, Quận 7, Thành phố Hồ Chí Minh 700000, Vietnam",
                            Email = "",
                            PhoneNumber ="+842854136909",
                            Longitude = 10.728121635326294,
                            Latitude = 106.71857820161436,
                            OpenTime =  "3/12/2020 11:00",
                            CloseTime =  "3/12/2020 22:00",
                            ReservationLink = "https://widget.guestplan.com/?i=bde0aabd41e9f8d0df7141fc0dcf7c19572f34dc",
                            Country = Country.Vietnam
                        },
                        new Restaurant()
                        {
                            Name = "Da Nang",
                            Address ="Lot G1-G4 Indochina Riverside Building 74 Bach Dang, 1 Ward, Hải Châu 1, Hải Châu, Đà Nẵng 590000, Vietnam",
                            Email = "",
                            PhoneNumber ="+842363886474",
                            Longitude = 16.07039302707959,
                            Latitude = 108.22447298942329,
                            OpenTime = "3/12/2020 11:00",
                            CloseTime =  "3/12/2020 22:00",
                            ReservationLink = "https://widget.guestplan.com/?i=e4603d600d6f621fa80757edda6b4b3a1508c67e",
                            Country = Country.Vietnam
                        },
                        new Restaurant()
                        {
                            Name = "Ba Dinh",
                            Address ="29 Liễu Giai VINCOM Center Metropolis Unit L1-16A Ground Floor, Ba Đình, Hà Nội, Vietnam",
                            Email = "",
                            PhoneNumber ="+84964000319",
                            Longitude = 21.031198327092202,
                            Latitude = 105.81527704467163,
                            OpenTime =  "3/12/2020 11:00",
                            CloseTime =  "3/12/2020 22:00",
                            ReservationLink = "https://widget.guestplan.com/?i=adcd8bd91a60bf2859808c89e5ee8172c2fad73a",
                            Country = Country.Vietnam
                        },
                        new Restaurant()
                        {
                            Name = "Tay Ho",
                            Address ="Someret West Point, No.2 Đường Tây Hồ, Quảng An, Tây Hồ, Hà Nội 100000, Vietnam",
                            Email = "",
                            PhoneNumber ="+842437186991",
                            Longitude = 21.066858660484776,
                            Latitude =105.82592451551005,
                            OpenTime = "3/12/2020 11:00",
                            CloseTime =  "3/12/2020 22:00",
                            ReservationLink = "https://widget.guestplan.com/?i=28e81cd76a4b131b187f4c0f14a42480dbca5f82",
                            Country = Country.Vietnam
                        },
                        new Restaurant()
                        {
                            Name = "TRANG TIEN ",
                            Address ="11 Tràng Tiền, Hoàn Kiếm, Hà Nội, Vietnam",
                            Email = "",
                            PhoneNumber ="+842438247280",
                            Longitude = 21.024735724193093,
                            Latitude = 105.85639259103279,
                            OpenTime =  "3/12/2020 11:00",
                            CloseTime =  "3/12/2020 22:00",
                            ReservationLink = "https://widget.guestplan.com/?i=4caa5fe921c14b98c665948598ef3417f031e858",
                            Country = Country.Vietnam
                        },
                    }
                    );
                await dbContext.SaveChangesAsync();
            }
            Console.WriteLine("Finish seed restaurant");
        }
        public static async Task SeedMenuAsync(ApplicationDbContext dbContext)
        {
            Console.WriteLine("Start to seed menu");
            if (!dbContext.Set<Menu>().Any())
            {
                var adminAreas = await dbContext.Set<Area>().ToListAsync();
                List<Menu> countries = new List<Menu>();
                adminAreas.ForEach(e => countries.Add(new Menu() { AreaId = e.Id }));
                await dbContext.AddRangeAsync(countries);
                await dbContext.SaveChangesAsync();
            }
            Console.WriteLine("Finish seed country");
        }

        private async static Task SeedProduct(ApplicationDbContext dbContext)
        {
            if (!await dbContext.Set<Product>().AnyAsync())
            {
                using (StreamReader reader = new StreamReader(String.Format(@"{0}\Data\products.json", Environment.CurrentDirectory)))
                {
                    var menu = await dbContext.Set<Menu>().ToListAsync();
                    int hcmMenu = menu.Where(p => p.Area.Code == "HCM").Select(p => p.Id).FirstOrDefault();
                    int dnMenu = menu.Where(p => p.Area.Code == "DN").Select(p => p.Id).FirstOrDefault();
                    string json = await reader.ReadToEndAsync();
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
                    products.ForEach(item => { item.Id = 0; item.MenuId = hcmMenu; item.IsAvailable = true; });

                    List<Product> customProducts = JsonConvert.DeserializeObject<List<Product>>(json);
                    customProducts.ForEach(item => { item.Id = 0; item.MenuId = dnMenu; item.IsAvailable = true; });
                    await dbContext.AddRangeAsync(products);
                    await dbContext.AddRangeAsync(customProducts);
                    await dbContext.SaveChangesAsync();
                }
            }

        }
        private async static Task SeedBaseProduct(ApplicationDbContext dbContext)
        {
            Console.WriteLine("Start to seed base product");
            if (!await dbContext.Set<BaseProduct>().AnyAsync())
            {
                using (StreamReader reader = new StreamReader(String.Format(@"{0}\Data\products.json", Environment.CurrentDirectory)))
                {
                    string json = await reader.ReadToEndAsync();
                    List<BaseProduct> products = JsonConvert.DeserializeObject<List<BaseProduct>>(json);
                    products.ForEach(item => { item.Id = 0; item.IsAvailable = true; });

                    await dbContext.AddRangeAsync(products);
                    await dbContext.SaveChangesAsync();
                }
            }
            Console.WriteLine("Finish seed base product");

        }
        private async static Task SeedCustomer(ApplicationDbContext dbContext)
        {
            Console.WriteLine("Start to seed customer");
            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                await CreateUser(i, RoleName.CUSTOMER);
            }
            Console.WriteLine("Finish seed customer");
        }

        private async static Task CreateUser(int i, string role)
        {
            var userManagement = _serviceProvider.GetService<UserManager<User>>();
            if (i < 0 || i > names.Length || i > phoneNumbers.Length)
            {
                return;
            }
            if (await userManagement.Users.AnyAsync(p => p.PhoneNumber == phoneNumbers[i]))
            {
                return;
            }
            var user = new User
            {
                Fullname = names[i],
                UserName = phoneNumbers[i],
                Email = GenerateEmail(names[i]),
                PhoneNumber = phoneNumbers[i],
                DateOfBirth = new DateTime(1990 + (i % 6), (i % 12) + 1, 18),
                Gender = i % 2 == 0,
                Status = UserStatus.ACTIVATE,
                SearchName = StringUtil.GenerateSearchString(names[i]),
                Point = i * 10
            };
            var userResult = await userManagement.CreateAsync(user, "Password@1");
            if (userResult.Succeeded)
            {
                await userManagement.AddToRoleAsync(user, role);
            }

            var token = await userManagement.GenerateEmailConfirmationTokenAsync(user);
            await userManagement.ConfirmEmailAsync(user, token);
            return;
        }
        private static string GenerateEmail(string suffix)
        {
            suffix = StringUtil.GenerateSearchString(suffix);
            return $"{suffix.ToLower()}@gmail.com";
        }
    }
}
