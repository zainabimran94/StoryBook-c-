﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StoryBook.Data;

#nullable disable

namespace StoryBook.Migrations
{
    [DbContext(typeof(StoryBookDbContext))]
    [Migration("20241023112307_UpdateAgeTheme")]
    partial class UpdateAgeTheme
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StoryBook.Models.AgeGroup", b =>
                {
                    b.Property<int>("AgeGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AgeGroupId"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AgeGroupId");

                    b.ToTable("AgeGroups");
                });

            modelBuilder.Entity("StoryBook.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("StoryBook.Models.Images", b =>
                {
                    b.Property<Guid>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ImageDesc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ThemeId")
                        .HasColumnType("integer");

                    b.HasKey("ImageId");

                    b.HasIndex("ThemeId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("StoryBook.Models.KidsPreferences", b =>
                {
                    b.Property<Guid>("KidsPrefId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("StoryDesc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("KidsPrefId");

                    b.HasIndex("UserId");

                    b.ToTable("KidPreferences");
                });

            modelBuilder.Entity("StoryBook.Models.StoryGenerated", b =>
                {
                    b.Property<Guid>("StoryGeneratedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("StoryBook")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StoryGenTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StoryImageUrl")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserStoryId")
                        .HasColumnType("uuid");

                    b.HasKey("StoryGeneratedId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserStoryId")
                        .IsUnique();

                    b.ToTable("StoriesGenerated");
                });

            modelBuilder.Entity("StoryBook.Models.Themes", b =>
                {
                    b.Property<int>("ThemeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ThemeId"));

                    b.Property<string>("ThemeDesc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ThemeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ThemeId");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("StoryBook.Models.ToddlerImageSelection", b =>
                {
                    b.Property<Guid>("ToddlerPrefId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uuid");

                    b.HasKey("ToddlerPrefId", "ImageId");

                    b.HasIndex("ImageId");

                    b.ToTable("ToddlerImageSelection");
                });

            modelBuilder.Entity("StoryBook.Models.ToddlerPreferences", b =>
                {
                    b.Property<Guid>("ToddlerPrefId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ImageDesc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("ToddlerPrefId");

                    b.HasIndex("UserId");

                    b.ToTable("ToddlerPreferences");
                });

            modelBuilder.Entity("StoryBook.Models.UserGroup", b =>
                {
                    b.Property<Guid>("UserGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AgeGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("ThemeId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("UserGroupId");

                    b.HasIndex("AgeGroupId");

                    b.HasIndex("ThemeId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("StoryBook.Models.UserProfile", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("StoryBook.Models.UserStoryPref", b =>
                {
                    b.Property<Guid>("UserStoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("KidPreferencesId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ToddlerPreferencesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserGroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("UserStoryId");

                    b.HasIndex("KidPreferencesId");

                    b.HasIndex("ToddlerPreferencesId");

                    b.HasIndex("UserGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("UserStoryPreferences");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StoryBook.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StoryBook.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoryBook.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StoryBook.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoryBook.Models.Images", b =>
                {
                    b.HasOne("StoryBook.Models.Themes", "Theme")
                        .WithMany("Images")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theme");
                });

            modelBuilder.Entity("StoryBook.Models.KidsPreferences", b =>
                {
                    b.HasOne("StoryBook.Models.UserProfile", "UserProfile")
                        .WithMany("KidsPreferences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("StoryBook.Models.StoryGenerated", b =>
                {
                    b.HasOne("StoryBook.Models.UserProfile", "UserProfile")
                        .WithMany("StoriesGenerated")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoryBook.Models.UserStoryPref", "UserStory")
                        .WithOne()
                        .HasForeignKey("StoryBook.Models.StoryGenerated", "UserStoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");

                    b.Navigation("UserStory");
                });

            modelBuilder.Entity("StoryBook.Models.ToddlerImageSelection", b =>
                {
                    b.HasOne("StoryBook.Models.Images", "Image")
                        .WithMany("ToddlerImageSelections")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoryBook.Models.ToddlerPreferences", "ToddlerPreferences")
                        .WithMany("SelectedImages")
                        .HasForeignKey("ToddlerPrefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("ToddlerPreferences");
                });

            modelBuilder.Entity("StoryBook.Models.ToddlerPreferences", b =>
                {
                    b.HasOne("StoryBook.Models.UserProfile", "UserProfile")
                        .WithMany("ToddlerPreferences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("StoryBook.Models.UserGroup", b =>
                {
                    b.HasOne("StoryBook.Models.AgeGroup", "AgeGroup")
                        .WithMany("UserAgeGroups")
                        .HasForeignKey("AgeGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoryBook.Models.Themes", "Theme")
                        .WithMany("UserThemeGroups")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoryBook.Models.UserProfile", "UserProfile")
                        .WithOne("UserGroups")
                        .HasForeignKey("StoryBook.Models.UserGroup", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgeGroup");

                    b.Navigation("Theme");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("StoryBook.Models.UserProfile", b =>
                {
                    b.HasOne("StoryBook.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("UserProfile")
                        .HasForeignKey("StoryBook.Models.UserProfile", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("StoryBook.Models.UserStoryPref", b =>
                {
                    b.HasOne("StoryBook.Models.KidsPreferences", null)
                        .WithMany()
                        .HasForeignKey("KidPreferencesId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("StoryBook.Models.ToddlerPreferences", null)
                        .WithMany()
                        .HasForeignKey("ToddlerPreferencesId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("StoryBook.Models.UserGroup", "UserGroups")
                        .WithMany()
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoryBook.Models.UserProfile", "UserProfile")
                        .WithMany("UserStoryPreferences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserGroups");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("StoryBook.Models.AgeGroup", b =>
                {
                    b.Navigation("UserAgeGroups");
                });

            modelBuilder.Entity("StoryBook.Models.ApplicationUser", b =>
                {
                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("StoryBook.Models.Images", b =>
                {
                    b.Navigation("ToddlerImageSelections");
                });

            modelBuilder.Entity("StoryBook.Models.Themes", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("UserThemeGroups");
                });

            modelBuilder.Entity("StoryBook.Models.ToddlerPreferences", b =>
                {
                    b.Navigation("SelectedImages");
                });

            modelBuilder.Entity("StoryBook.Models.UserProfile", b =>
                {
                    b.Navigation("KidsPreferences");

                    b.Navigation("StoriesGenerated");

                    b.Navigation("ToddlerPreferences");

                    b.Navigation("UserGroups");

                    b.Navigation("UserStoryPreferences");
                });
#pragma warning restore 612, 618
        }
    }
}
