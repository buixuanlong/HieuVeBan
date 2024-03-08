﻿// <auto-generated />
using System;
using HieuVeBan.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HieuVeBan.Models.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_datetime");

                    b.Property<Guid>("CreatedUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("created_userid");

                    b.Property<string>("SecretKey")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("secret_key");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_datetime");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("updated_userid");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("user_email");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("user_name");

                    b.Property<byte[]>("row_version")
                        .IsConcurrencyToken()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("app_user", "dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
