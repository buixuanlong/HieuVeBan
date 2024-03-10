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
    [Migration("20240310112416_InitMBTIResult")]
    partial class InitMBTIResult
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HieuVeBan.Models.Entities.AdministrativeRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("code_name");

                    b.Property<string>("CodeNameEn")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("code_name_en");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name_en");

                    b.HasKey("Id");

                    b.ToTable("administrative_regions", "dbo");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.AdministrativeUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("code_name");

                    b.Property<string>("CodeNameEn")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("code_name_en");

                    b.Property<string>("FullName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("full_name");

                    b.Property<string>("FullNameEn")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("full_name_en");

                    b.Property<string>("ShortName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("short_name");

                    b.Property<string>("ShortNameEn")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("short_name_en");

                    b.HasKey("Id");

                    b.ToTable("administrative_units", "dbo");
                });

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

                    b.ToTable("app_users", "dbo");
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

                    b.ToTable("holland_answers", "dbo");
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

                    b.ToTable("mbti_answers", "dbo");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.MBTICelebrity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image_link");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<Guid>("PersonalityGroupId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("personality_group_id");

                    b.HasKey("Id");

                    b.HasIndex("PersonalityGroupId");

                    b.ToTable("mbti_celebrities", "dbo");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.MBTIDichotomousPair", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("mbti_dichotomous_pairs", "dbo");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.MBTIFunctionalFactor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("MBTIDichotomousPairId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("mbti_dichotomous_pair_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("symbol");

                    b.HasKey("Id");

                    b.HasIndex("MBTIDichotomousPairId");

                    b.ToTable("mbti_functional_factors", "dbo");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.MBTIPersonalityGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("symbol");

                    b.HasKey("Id");

                    b.ToTable("mbti_personality_groups", "dbo");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.MBTIResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("MBTIAnswerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("mbti_answer_id");

                    b.Property<Guid>("MBTIFunctionalFactorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("mbti_functional_factor_id");

                    b.Property<int>("Mark")
                        .HasColumnType("int")
                        .HasColumnName("mark");

                    b.Property<Guid>("PersonalityAssessmentQuestionId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("personality_assessment_question_id");

                    b.HasKey("Id");

                    b.HasIndex("MBTIAnswerId");

                    b.HasIndex("MBTIFunctionalFactorId");

                    b.HasIndex("PersonalityAssessmentQuestionId");

                    b.ToTable("mbti_results", "dbo");
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

                    b.ToTable("personality_assessment_methods", "dbo");
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

                    b.ToTable("personality_assessment_questions", "dbo");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdministrativeRegionId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("administrative_region_id");

                    b.Property<int?>("AdministrativeUnitId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("administrative_unit_id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("code");

                    b.Property<string>("CodeName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("code_name");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("full_name");

                    b.Property<string>("FullNameEn")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("full_name_en");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("NameEn")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name_en");

                    b.HasKey("Id");

                    b.HasIndex("AdministrativeRegionId");

                    b.HasIndex("AdministrativeUnitId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("provinces", "dbo");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.UserInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_datetime");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("Date")
                        .HasColumnName("dob");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int")
                        .HasColumnName("province_id");

                    b.Property<string>("Thpt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("thpt");

                    b.Property<Guid>("UserObjectId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_object_id");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ProvinceId");

                    b.HasIndex("UserObjectId");

                    b.ToTable("user_informations", "dbo");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.UserObject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int")
                        .HasColumnName("sort_order");

                    b.HasKey("Id");

                    b.ToTable("user_objects", "dbo");
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

            modelBuilder.Entity("HieuVeBan.Models.Entities.MBTICelebrity", b =>
                {
                    b.HasOne("HieuVeBan.Models.Entities.MBTIPersonalityGroup", "PersonalityGroup")
                        .WithMany()
                        .HasForeignKey("PersonalityGroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PersonalityGroup");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.MBTIFunctionalFactor", b =>
                {
                    b.HasOne("HieuVeBan.Models.Entities.MBTIDichotomousPair", "MBTIDichotomousPair")
                        .WithMany()
                        .HasForeignKey("MBTIDichotomousPairId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MBTIDichotomousPair");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.MBTIResult", b =>
                {
                    b.HasOne("HieuVeBan.Models.Entities.MBTIAnswer", "MBTIAnswer")
                        .WithMany()
                        .HasForeignKey("MBTIAnswerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HieuVeBan.Models.Entities.MBTIFunctionalFactor", "MBTIFunctionalFactor")
                        .WithMany()
                        .HasForeignKey("MBTIFunctionalFactorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HieuVeBan.Models.Entities.PersonalityAssessmentQuestion", "PersonalityAssessmentQuestion")
                        .WithMany()
                        .HasForeignKey("PersonalityAssessmentQuestionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MBTIAnswer");

                    b.Navigation("MBTIFunctionalFactor");

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

            modelBuilder.Entity("HieuVeBan.Models.Entities.Province", b =>
                {
                    b.HasOne("HieuVeBan.Models.Entities.AdministrativeRegion", "AdministrativeRegion")
                        .WithMany()
                        .HasForeignKey("AdministrativeRegionId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HieuVeBan.Models.Entities.AdministrativeUnit", "AdministrativeUnit")
                        .WithMany()
                        .HasForeignKey("AdministrativeUnitId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("AdministrativeRegion");

                    b.Navigation("AdministrativeUnit");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.UserInformation", b =>
                {
                    b.HasOne("HieuVeBan.Models.Entities.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HieuVeBan.Models.Entities.UserObject", "UserObject")
                        .WithMany()
                        .HasForeignKey("UserObjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Province");

                    b.Navigation("UserObject");
                });

            modelBuilder.Entity("HieuVeBan.Models.Entities.PersonalityAssessmentMethod", b =>
                {
                    b.Navigation("PersonalityAssessmentQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}
