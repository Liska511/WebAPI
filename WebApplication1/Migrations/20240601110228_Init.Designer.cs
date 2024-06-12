﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Repository;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240601110228_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CityDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Data.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Data.Form", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("FormProblemId")
                        .HasColumnType("integer");

                    b.Property<string>("FormText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FormProblemId");

                    b.HasIndex("UserId");

                    b.ToTable("Form");
                });

            modelBuilder.Entity("Data.FormProblem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ProblemName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProblemSimpleDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FormProblem");
                });

            modelBuilder.Entity("Data.Hotel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("HotelDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("Data.Notification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("CityID")
                        .HasColumnType("integer");

                    b.Property<int>("CountryID")
                        .HasColumnType("integer");

                    b.Property<long>("HotelID")
                        .HasColumnType("bigint");

                    b.Property<string>("NotificationDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NotificationTemplateId")
                        .HasColumnType("integer");

                    b.Property<string>("NotificationText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NotificationTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NotificationTypeId")
                        .HasColumnType("integer");

                    b.Property<long>("RoomID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CityID");

                    b.HasIndex("CountryID");

                    b.HasIndex("HotelID");

                    b.HasIndex("NotificationTemplateId");

                    b.HasIndex("NotificationTypeId");

                    b.HasIndex("RoomID");

                    b.HasIndex("UserID");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("Data.NotificationTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NotificationTemplateDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NotificationTemplateFilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NotificationTemplateName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("NotificationTemplate");
                });

            modelBuilder.Entity("Data.NotificationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NotificationTypeDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NotificationTypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("NotificationType");
                });

            modelBuilder.Entity("Data.Room", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("HotelId")
                        .HasColumnType("bigint");

                    b.Property<string>("RoomDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Data.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Data.City", b =>
                {
                    b.HasOne("Data.Country", "Country")
                        .WithMany("CitiesList")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Data.Form", b =>
                {
                    b.HasOne("Data.FormProblem", "FormProblem")
                        .WithMany("FormsList")
                        .HasForeignKey("FormProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.User", "User")
                        .WithMany("FormsList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormProblem");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Hotel", b =>
                {
                    b.HasOne("Data.City", "City")
                        .WithMany("HotelsList")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Data.Notification", b =>
                {
                    b.HasOne("Data.City", "City")
                        .WithMany("NotificationsList")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Country", "Country")
                        .WithMany("NotificationsList")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Hotel", "Hotel")
                        .WithMany("NotificationsList")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.NotificationTemplate", "NotificationTemplate")
                        .WithMany("NotificationsList")
                        .HasForeignKey("NotificationTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.NotificationType", "NotificationType")
                        .WithMany("NotificationsList")
                        .HasForeignKey("NotificationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Room", "Room")
                        .WithMany("NotificationsList")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.User", "User")
                        .WithMany("NotificationsList")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("Hotel");

                    b.Navigation("NotificationTemplate");

                    b.Navigation("NotificationType");

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Room", b =>
                {
                    b.HasOne("Data.Hotel", "Hotel")
                        .WithMany("RoomsList")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Data.City", b =>
                {
                    b.Navigation("HotelsList");

                    b.Navigation("NotificationsList");
                });

            modelBuilder.Entity("Data.Country", b =>
                {
                    b.Navigation("CitiesList");

                    b.Navigation("NotificationsList");
                });

            modelBuilder.Entity("Data.FormProblem", b =>
                {
                    b.Navigation("FormsList");
                });

            modelBuilder.Entity("Data.Hotel", b =>
                {
                    b.Navigation("NotificationsList");

                    b.Navigation("RoomsList");
                });

            modelBuilder.Entity("Data.NotificationTemplate", b =>
                {
                    b.Navigation("NotificationsList");
                });

            modelBuilder.Entity("Data.NotificationType", b =>
                {
                    b.Navigation("NotificationsList");
                });

            modelBuilder.Entity("Data.Room", b =>
                {
                    b.Navigation("NotificationsList");
                });

            modelBuilder.Entity("Data.User", b =>
                {
                    b.Navigation("FormsList");

                    b.Navigation("NotificationsList");
                });
#pragma warning restore 612, 618
        }
    }
}
