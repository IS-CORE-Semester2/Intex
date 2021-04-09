﻿// <auto-generated />
using System;
using Intex.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Intex.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210409052244_DbDone")]
    partial class DbDone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Intex.BioSamples", b =>
                {
                    b.Property<int>("BioSampleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BagNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BurialLocationEw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BurialLocationNs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("BurialNumber")
                        .HasColumnType("float");

                    b.Property<string>("BurialSubplot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Date")
                        .HasColumnType("float");

                    b.Property<double?>("HighPairEw")
                        .HasColumnType("float");

                    b.Property<double?>("HighPairNs")
                        .HasColumnType("float");

                    b.Property<string>("Initials")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("LowPairEw")
                        .HasColumnType("float");

                    b.Property<double?>("LowPairNs")
                        .HasColumnType("float");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviouslySampled")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("RackNumber")
                        .HasColumnType("float");

                    b.HasKey("BioSampleId");

                    b.ToTable("BioSamples");
                });

            modelBuilder.Entity("Intex.Burials", b =>
                {
                    b.Property<int>("MainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ArtifactFound")
                        .HasColumnType("bit");

                    b.Property<string>("ArtifactsDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BasilarSuture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("BasionBregmaHeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("BasionNasion")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("BasionProsthionLength")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("BizygomaticDiameter")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("BoneLength")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("BoneTaken")
                        .HasColumnType("bit");

                    b.Property<decimal?>("BurialDepth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BurialIdOld")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BurialLocationEw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BurialLocationNs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BurialNumber")
                        .HasColumnType("int");

                    b.Property<string>("BurialSituation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BurialSubplot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CranialSuture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DayFound")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionOfTaken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DorsalPitting")
                        .HasColumnType("int");

                    b.Property<decimal?>("EastToFeet")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EastToHead")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("EpiphysealUnion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("EstimateAge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EstimateLivingStature")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("FemurHead")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("FemurLength")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ForemanMagnum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("GeFunctionTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("GenderBodyCol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenderGe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gonian")
                        .HasColumnType("int");

                    b.Property<string>("HairColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HairTaken")
                        .HasColumnType("bit");

                    b.Property<string>("HeadDirection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HighPairEw")
                        .HasColumnType("int");

                    b.Property<int?>("HighPairNs")
                        .HasColumnType("int");

                    b.Property<decimal?>("HumerusHead")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("HumerusLength")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("InterorbitalBreadth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("LengthOfRemains")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("LowPairEw")
                        .HasColumnType("int");

                    b.Property<int?>("LowPairNs")
                        .HasColumnType("int");

                    b.Property<decimal?>("MaximumCranialBreadth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MaximumCranialLength")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MaximumNasalBreadth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("MedialIpRamus")
                        .HasColumnType("int");

                    b.Property<string>("MonthFound")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("NasionProsthion")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("NuchalCrest")
                        .HasColumnType("int");

                    b.Property<int?>("OrbitEdge")
                        .HasColumnType("int");

                    b.Property<string>("Osteophytosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParietalBossing")
                        .HasColumnType("int");

                    b.Property<string>("PathologyAnomalies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PreaurSulcus")
                        .HasColumnType("int");

                    b.Property<string>("PreservationIndex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PubicBone")
                        .HasColumnType("int");

                    b.Property<string>("PubicSymphysis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Robust")
                        .HasColumnType("int");

                    b.Property<int?>("SampleNumber")
                        .HasColumnType("int");

                    b.Property<int?>("SciaticNotch")
                        .HasColumnType("int");

                    b.Property<bool>("SoftTissueTaken")
                        .HasColumnType("bit");

                    b.Property<decimal?>("SouthToFeet")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SouthToHead")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SubpubicAngle")
                        .HasColumnType("int");

                    b.Property<int?>("SupraorbitalRidges")
                        .HasColumnType("int");

                    b.Property<bool>("TextileTaken")
                        .HasColumnType("bit");

                    b.Property<decimal?>("TibiaLength")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ToothAttrition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToothEruption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ToothTaken")
                        .HasColumnType("bit");

                    b.Property<int?>("VentralArc")
                        .HasColumnType("int");

                    b.Property<string>("YearFound")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ZygomaticCrest")
                        .HasColumnType("int");

                    b.HasKey("MainId");

                    b.ToTable("Burials");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
