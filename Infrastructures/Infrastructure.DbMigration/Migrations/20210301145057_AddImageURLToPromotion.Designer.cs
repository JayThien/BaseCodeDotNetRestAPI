﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.DbMigration.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210301145057_AddImageURLToPromotion")]
    partial class AddImageURLToPromotion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationDomain.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int>("Country");

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("ApplicationDomain.Entities.BaseProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category");

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsAvailable");

                    b.Property<string>("Name");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("SubCategory");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("BaseProduct");
                });

            modelBuilder.Entity("ApplicationDomain.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Email");

                    b.Property<int>("EventType");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Message");

                    b.Property<string>("Phone");

                    b.Property<int>("RestaurantId");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("Size");

                    b.Property<int>("Status");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("ApplicationDomain.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId");

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("ApplicationDomain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BillingAddress");

                    b.Property<string>("Code");

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Note");

                    b.Property<int>("PaymentMethod");

                    b.Property<int?>("PromotionId");

                    b.Property<string>("Receiver");

                    b.Property<string>("ReceiverEmail");

                    b.Property<string>("ReceiverPhone");

                    b.Property<byte[]>("RowVersion");

                    b.Property<double>("ServiceFee");

                    b.Property<string>("ShippingAddress");

                    b.Property<DateTime>("ShippingDate");

                    b.Property<double>("ShippingFee");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("PromotionId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ApplicationDomain.Entities.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Additions");

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<byte[]>("RowVersion");

                    b.Property<double>("TotalPriceOfProduct");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("ApplicationDomain.Entities.OrderPromotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<double>("Discount");

                    b.Property<int>("OrderId");

                    b.Property<int>("PromotionId");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PromotionId");

                    b.ToTable("OrderPromotion");
                });

            modelBuilder.Entity("ApplicationDomain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Additions");

                    b.Property<int>("Category");

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsAvailable");

                    b.Property<int>("MenuId");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<int>("Priority");

                    b.Property<DateTime>("PromotedFrom");

                    b.Property<double>("PromotedPrice");

                    b.Property<DateTime>("PromotedTo");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("SubCategory");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ApplicationDomain.Entities.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId");

                    b.Property<string>("Code");

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<double>("DiscountPrice");

                    b.Property<DateTime>("From");

                    b.Property<string>("ImageURL");

                    b.Property<bool>("IsPercent");

                    b.Property<int>("MaxPoint");

                    b.Property<double>("MaximumDiscount");

                    b.Property<int>("MinPoint");

                    b.Property<double>("MinimumOrderPrice");

                    b.Property<byte[]>("RowVersion");

                    b.Property<DateTime>("To");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Promotion");
                });

            modelBuilder.Entity("ApplicationDomain.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("CloseTime");

                    b.Property<int>("Country");

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsOpening");

                    b.Property<double>("Latitude");

                    b.Property<string>("LocationImage");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("OpenTime");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("ReservationLink");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("ApplicationDomain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ApplicationDomain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("AvatarURL");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Fullname");

                    b.Property<bool>("Gender");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("Point");

                    b.Property<string>("SearchName");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ApplicationDomain.Entities.UserPromotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<bool>("IsApplied");

                    b.Property<int>("PromotionId");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PromotionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPromotion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ApplicationDomain.Entities.Area", b =>
                {
                    b.HasOne("ApplicationDomain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("ApplicationDomain.Entities.Booking", b =>
                {
                    b.HasOne("ApplicationDomain.Entities.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationDomain.Entities.Menu", b =>
                {
                    b.HasOne("ApplicationDomain.Entities.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationDomain.Entities.Order", b =>
                {
                    b.HasOne("ApplicationDomain.Entities.Promotion", "Promotion")
                        .WithMany()
                        .HasForeignKey("PromotionId");
                });

            modelBuilder.Entity("ApplicationDomain.Entities.OrderProduct", b =>
                {
                    b.HasOne("ApplicationDomain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationDomain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationDomain.Entities.OrderPromotion", b =>
                {
                    b.HasOne("ApplicationDomain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationDomain.Entities.Promotion", "Promotion")
                        .WithMany()
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationDomain.Entities.Product", b =>
                {
                    b.HasOne("ApplicationDomain.Entities.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationDomain.Entities.Promotion", b =>
                {
                    b.HasOne("ApplicationDomain.Entities.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationDomain.Entities.Restaurant", b =>
                {
                    b.HasOne("ApplicationDomain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("ApplicationDomain.Entities.UserPromotion", b =>
                {
                    b.HasOne("ApplicationDomain.Entities.Promotion", "Promotion")
                        .WithMany()
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationDomain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("ApplicationDomain.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ApplicationDomain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ApplicationDomain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("ApplicationDomain.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationDomain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ApplicationDomain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
