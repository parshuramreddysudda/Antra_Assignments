﻿// <auto-generated />
using System;
using ApplicationCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApplicationCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240523234942_Updated Admin Table")]
    partial class UpdatedAdminTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationCore.Entities.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaim");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "Admin",
                            ClaimValue = "Add Manager",
                            DateCreated = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9060),
                            DateModified = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070)
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "Admin",
                            ClaimValue = "Edit Manager",
                            DateCreated = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070),
                            DateModified = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070)
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "Admin",
                            ClaimValue = "Delete Manager",
                            DateCreated = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070),
                            DateModified = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070)
                        },
                        new
                        {
                            Id = 4,
                            ClaimType = "Admin",
                            ClaimValue = "Get Manager",
                            DateCreated = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070),
                            DateModified = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070)
                        },
                        new
                        {
                            Id = 5,
                            ClaimType = "Manager",
                            ClaimValue = "Add Employee",
                            DateCreated = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070),
                            DateModified = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070)
                        },
                        new
                        {
                            Id = 6,
                            ClaimType = "Manager",
                            ClaimValue = "Edit Employee",
                            DateCreated = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070),
                            DateModified = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070)
                        },
                        new
                        {
                            Id = 7,
                            ClaimType = "Manager",
                            ClaimValue = "Delete Employee",
                            DateCreated = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070),
                            DateModified = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070)
                        },
                        new
                        {
                            Id = 8,
                            ClaimType = "Manager",
                            ClaimValue = "Get Employee",
                            DateCreated = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070),
                            DateModified = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070)
                        });
                });

            modelBuilder.Entity("ApplicationCore.Entities.ApplicationUser.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "756789fd-2371-4e9d-9956-2d39cfd180fe",
                            CustomerId = 0,
                            DateCreated = new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9210),
                            Email = "admin@admin.com",
                            EmailConfirmed = false,
                            FirstName = "Administrator",
                            Gender = "",
                            LastName = "Reddy",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEFVlp1I6f3m8U7mBpgBWVZ+oWRjsBAbNPBsHIlyq2z5JGzLjuIEiiHBxk+joYtfxMw==",
                            Phone = "",
                            PhoneNumberConfirmed = false,
                            ProfilePic = "",
                            SecurityStamp = "124524543645756ascaaf",
                            TwoFactorEnabled = false,
                            UserId = "0b11ede9-4119-4987-bccd-aa22625e386e",
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "Admin",
                            ClaimValue = "Add Manager",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "Admin",
                            ClaimValue = "Edit Manager",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "Admin",
                            ClaimValue = "Delete Manager",
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            ClaimType = "Admin",
                            ClaimValue = "Get Manager",
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            ClaimType = "Manager",
                            ClaimValue = "Add Employee",
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            ClaimType = "Manager",
                            ClaimValue = "Edit Employee",
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            ClaimType = "Manager",
                            ClaimValue = "Delete Employee",
                            UserId = 1
                        },
                        new
                        {
                            Id = 8,
                            ClaimType = "Manager",
                            ClaimValue = "Get Employee",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ApplicationCore.Entities.ApplicationUser.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ApplicationCore.Entities.ApplicationUser.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.ApplicationUser.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ApplicationCore.Entities.ApplicationUser.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
