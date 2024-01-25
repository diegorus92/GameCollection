﻿// <auto-generated />
using System;
using GameCollectionAPI_DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameCollectionAPI_DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CategoryGame", b =>
                {
                    b.Property<int>("GameCategoryCategoryId")
                        .HasColumnType("int");

                    b.Property<long>("GamesGameId")
                        .HasColumnType("bigint");

                    b.HasKey("GameCategoryCategoryId", "GamesGameId");

                    b.HasIndex("GamesGameId");

                    b.ToTable("CategoryGame");
                });

            modelBuilder.Entity("GameCollectionAPI_DAL.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GameCollectionAPI_DAL.Models.DevelopmentCompany", b =>
                {
                    b.Property<long>("DevelopmentCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DevelopmentCompanyId"), 1L, 1);

                    b.Property<string>("DevelopmentCompanyLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DevelopmentCompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DevelopmentCompanyId");

                    b.ToTable("DevelopmentCompanies");
                });

            modelBuilder.Entity("GameCollectionAPI_DAL.Models.Game", b =>
                {
                    b.Property<long>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GameId"), 1L, 1);

                    b.Property<long?>("GameDevelopmentCompanyDevelopmentCompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("GameImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameRank")
                        .HasColumnType("int");

                    b.Property<string>("GameSynopsis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameId");

                    b.HasIndex("GameDevelopmentCompanyDevelopmentCompanyId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameCollectionAPI_DAL.Models.GameImage", b =>
                {
                    b.Property<long>("GameImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GameImageId"), 1L, 1);

                    b.Property<string>("GameImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ImageGameGameId")
                        .HasColumnType("bigint");

                    b.HasKey("GameImageId");

                    b.HasIndex("ImageGameGameId");

                    b.ToTable("GameImages");
                });

            modelBuilder.Entity("GameCollectionAPI_DAL.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GameCollectionAPI_DAL.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"), 1L, 1);

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserNickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("UserPasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("UserPasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserRoleRoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserRoleRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GameUser", b =>
                {
                    b.Property<long>("GameUsersUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserGamesGameId")
                        .HasColumnType("bigint");

                    b.HasKey("GameUsersUserId", "UserGamesGameId");

                    b.HasIndex("UserGamesGameId");

                    b.ToTable("GameUser");
                });

            modelBuilder.Entity("CategoryGame", b =>
                {
                    b.HasOne("GameCollectionAPI_DAL.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("GameCategoryCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameCollectionAPI_DAL.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameCollectionAPI_DAL.Models.Game", b =>
                {
                    b.HasOne("GameCollectionAPI_DAL.Models.DevelopmentCompany", "GameDevelopmentCompany")
                        .WithMany("Games")
                        .HasForeignKey("GameDevelopmentCompanyDevelopmentCompanyId");

                    b.Navigation("GameDevelopmentCompany");
                });

            modelBuilder.Entity("GameCollectionAPI_DAL.Models.GameImage", b =>
                {
                    b.HasOne("GameCollectionAPI_DAL.Models.Game", "ImageGame")
                        .WithMany("GameImages")
                        .HasForeignKey("ImageGameGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImageGame");
                });

            modelBuilder.Entity("GameCollectionAPI_DAL.Models.User", b =>
                {
                    b.HasOne("GameCollectionAPI_DAL.Models.Role", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("GameUser", b =>
                {
                    b.HasOne("GameCollectionAPI_DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("GameUsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameCollectionAPI_DAL.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("UserGamesGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameCollectionAPI_DAL.Models.DevelopmentCompany", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("GameCollectionAPI_DAL.Models.Game", b =>
                {
                    b.Navigation("GameImages");
                });

            modelBuilder.Entity("GameCollectionAPI_DAL.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}