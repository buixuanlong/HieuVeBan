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
    [Migration("20240309174330_AddTypeInPersonalityAssessmentQuestion")]
    partial class AddTypeInPersonalityAssessmentQuestion
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

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hashed");

                    b.Property<string>("SecretKey")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("secret_key");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint")
                        .HasColumnName("type")
                        .HasComment("Type of UserType: 0 Unknown, 1 Internal, 2 External");

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

                    b.HasIndex(new[] { "UserName" }, "u_idx_app_user_username")
                        .IsUnique();

                    b.ToTable("app_user", "dbo");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.HollandAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("short_name");

                    b.HasKey("Id");

                    b.ToTable("holland_answer", "dbo");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.MBTIAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<Guid>("PersonalityAssessmentQuestionId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("personality_assessment_question_id");

                    b.HasKey("Id");

                    b.HasIndex("PersonalityAssessmentQuestionId");

                    b.ToTable("mbti_answer", "dbo");
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

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint")
                        .HasColumnName("type")
                        .HasComment("Type of MethodType: 1 Holland, 2 MBTI");

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
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("personality_assessment_method_id");

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

            modelBuilder.Entity("HieuVeBan.Models.Entities.MBTIAnswer", b =>
                {
                    b.HasOne("HieuVeBan.Models.Entities.PersonalityAssessmentQuestion", "PersonalityAssessmentQuestion")
                        .WithMany()
                        .HasForeignKey("PersonalityAssessmentQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalityAssessmentQuestion");
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
