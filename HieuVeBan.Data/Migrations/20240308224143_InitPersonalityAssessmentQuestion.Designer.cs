﻿// <auto-generated />
using System;
using HieuVeBan.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240308224143_InitPersonalityAssessmentQuestion")]
    partial class InitPersonalityAssessmentQuestion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("SecretKey")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("secret_key");

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

                    b.HasKey("Id");

                    b.ToTable("app_user", "dbo");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.PersonalityAssessmentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("author");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("note");

                    b.HasKey("Id");

                    b.ToTable("personality_assessment_method", "dbo");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.PersonalityAssessmentQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("PersonalityAssessmentMethodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("QuestionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("question_name");

                    b.Property<int>("QuestionNumber")
                        .HasColumnType("int")
                        .HasColumnName("question_number");

                    b.HasKey("Id");

                    b.HasIndex("PersonalityAssessmentMethodId");

                    b.ToTable("personality_assessment_question", "dbo");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.PersonalityAssessmentQuestion", b =>
                {
                    b.HasOne("HieuVeBan.Models.Entities.PersonalityAssessmentMethod", "PersonalityAssessmentMethod")
                        .WithMany("PersonalityAssessmentQuestions")
                        .HasForeignKey("PersonalityAssessmentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalityAssessmentMethod");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.PersonalityAssessmentMethod", b =>
                {
                    b.Navigation("PersonalityAssessmentQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}
