﻿// <auto-generated />
using System;
using CSMWebsite2024.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CSMWebsite2024.EntityFramework.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20241016091459_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("CSMWebsite2024.Data.Posts.Post", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e042b0f1-3d7a-4b34-bf26-fc0bfe2bebbd"),
                            AuthorId = new Guid("49e86f3d-7c33-460f-80dc-47af528fdaf6"),
                            CreatedAt = new DateTime(2024, 10, 16, 17, 14, 59, 223, DateTimeKind.Local).AddTicks(9356),
                            Description = "Admins open the school year",
                            Title = "SCHOOL YEAR IS OPEN",
                            UpdatedAt = new DateTime(2024, 10, 16, 17, 14, 59, 223, DateTimeKind.Local).AddTicks(9366)
                        },
                        new
                        {
                            Id = new Guid("d2c47548-0c60-4260-b6c4-121356074545"),
                            AuthorId = new Guid("3c5fca94-7ed4-45c4-b432-f68554ff0b41"),
                            CreatedAt = new DateTime(2024, 10, 16, 17, 14, 59, 223, DateTimeKind.Local).AddTicks(9368),
                            Description = "IS Department welcomes 24 new students",
                            Title = "IS COURSE HAS NEW STUDENTS",
                            UpdatedAt = new DateTime(2024, 10, 16, 17, 14, 59, 223, DateTimeKind.Local).AddTicks(9369)
                        },
                        new
                        {
                            Id = new Guid("d846d060-efda-40da-874b-d55432ea913e"),
                            AuthorId = new Guid("42a5979e-665c-4c8a-86d0-3d0489cda67c"),
                            CreatedAt = new DateTime(2024, 10, 16, 17, 14, 59, 223, DateTimeKind.Local).AddTicks(9370),
                            Description = "See Academic Calendar for details",
                            Title = "SPORTSFEST IS APPROACHING",
                            UpdatedAt = new DateTime(2024, 10, 16, 17, 14, 59, 223, DateTimeKind.Local).AddTicks(9371)
                        });
                });

            modelBuilder.Entity("CSMWebsite2024.Data.Security.User", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int?>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("49e86f3d-7c33-460f-80dc-47af528fdaf6"),
                            EmailAddress = "etirel@mailinator.com",
                            FirstName = "Elspeth",
                            LastName = "Tirel",
                            Points = 3
                        },
                        new
                        {
                            Id = new Guid("3c5fca94-7ed4-45c4-b432-f68554ff0b41"),
                            EmailAddress = "jbeleren@mailinator.com",
                            FirstName = "Jace",
                            LastName = "Beleren",
                            Points = 3
                        },
                        new
                        {
                            Id = new Guid("42a5979e-665c-4c8a-86d0-3d0489cda67c"),
                            EmailAddress = "lvess@mailinator.com",
                            FirstName = "Liliana",
                            LastName = "Vess",
                            Points = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
