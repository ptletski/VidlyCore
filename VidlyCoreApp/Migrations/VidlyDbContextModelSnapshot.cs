﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.Migrations
{
    [DbContext(typeof(VidlyDbContext))]
    partial class VidlyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("VidlyCoreApp.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("VidlyCoreApp.Models.ContentProvider", b =>
                {
                    b.Property<int>("ContentProviderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentProviderName");

                    b.Property<string>("ContractReference");

                    b.HasKey("ContentProviderId");

                    b.ToTable("ContentProviders");
                });

            modelBuilder.Entity("VidlyCoreApp.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("City");

                    b.Property<bool>("IsSubscribedToNewsletter");

                    b.Property<byte>("MembershipTypeId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("State");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("VidlyCoreApp.Models.InventoryControlEntry", b =>
                {
                    b.Property<int>("InventoryControlId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContentProviderId");

                    b.Property<int>("MovieId");

                    b.Property<short>("PermittedUsageCount");

                    b.HasKey("InventoryControlId");

                    b.ToTable("InventoryControl");
                });

            modelBuilder.Entity("VidlyCoreApp.Models.MembershipType", b =>
                {
                    b.Property<byte>("MembershipTypeId");

                    b.Property<byte>("DiscountRate");

                    b.Property<byte>("DurationInMonths");

                    b.Property<string>("MembershipName");

                    b.Property<short>("SignUpFee");

                    b.HasKey("MembershipTypeId");

                    b.ToTable("MembershipTypes");
                });

            modelBuilder.Entity("VidlyCoreApp.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActiveUseCount");

                    b.Property<DateTime>("DateAdded");

                    b.Property<int>("InventoryControlId");

                    b.Property<byte>("MovieGenreId");

                    b.Property<byte>("MpaRatingId");

                    b.Property<string>("Title");

                    b.Property<int>("Year");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("VidlyCoreApp.Models.MovieGenre", b =>
                {
                    b.Property<byte>("MovieGenreId");

                    b.Property<string>("MovieGenreName");

                    b.HasKey("MovieGenreId");

                    b.ToTable("MovieGenres");
                });

            modelBuilder.Entity("VidlyCoreApp.Models.MpaRating", b =>
                {
                    b.Property<byte>("MpaRatingId");

                    b.Property<string>("MpaRatingName");

                    b.HasKey("MpaRatingId");

                    b.ToTable("MpaRatings");
                });

            modelBuilder.Entity("VidlyCoreApp.Models.RentalTransaction", b =>
                {
                    b.Property<int>("RentalTransactionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<int>("RentedMoviesId");

                    b.HasKey("RentalTransactionId");

                    b.ToTable("RentalTransactions");
                });

            modelBuilder.Entity("VidlyCoreApp.Models.RentedMovie", b =>
                {
                    b.Property<int>("RentalTransactionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MovieId");

                    b.HasKey("RentalTransactionId");

                    b.ToTable("RentedMovies");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("VidlyCoreApp.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("VidlyCoreApp.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VidlyCoreApp.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("VidlyCoreApp.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
