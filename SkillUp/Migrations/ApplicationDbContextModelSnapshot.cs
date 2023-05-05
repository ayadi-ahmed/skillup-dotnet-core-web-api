﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SkillUp.Models;

#nullable disable

namespace SkillUp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SkillUp.Models.Achat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("candidatId")
                        .HasColumnType("integer");

                    b.Property<int?>("trainingId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("candidatId");

                    b.HasIndex("trainingId");

                    b.ToTable("achats");
                });

            modelBuilder.Entity("SkillUp.Models.Candidat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("candidats");
                });

            modelBuilder.Entity("SkillUp.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("managers");
                });

            modelBuilder.Entity("SkillUp.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("trainingCenterId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("trainingCenterId");

                    b.ToTable("trainings");
                });

            modelBuilder.Entity("SkillUp.Models.TrainingCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TrainingCenterId")
                        .HasColumnType("integer");

                    b.Property<int?>("managerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TrainingCenterId");

                    b.HasIndex("managerId");

                    b.ToTable("trainingCenters");
                });

            modelBuilder.Entity("SkillUp.Models.Achat", b =>
                {
                    b.HasOne("SkillUp.Models.Candidat", "candidat")
                        .WithMany("achats")
                        .HasForeignKey("candidatId");

                    b.HasOne("SkillUp.Models.Training", "training")
                        .WithMany("achats")
                        .HasForeignKey("trainingId");

                    b.Navigation("candidat");

                    b.Navigation("training");
                });

            modelBuilder.Entity("SkillUp.Models.Training", b =>
                {
                    b.HasOne("SkillUp.Models.TrainingCenter", "trainingCenter")
                        .WithMany()
                        .HasForeignKey("trainingCenterId");

                    b.Navigation("trainingCenter");
                });

            modelBuilder.Entity("SkillUp.Models.TrainingCenter", b =>
                {
                    b.HasOne("SkillUp.Models.TrainingCenter", null)
                        .WithMany("trainingCenters")
                        .HasForeignKey("TrainingCenterId");

                    b.HasOne("SkillUp.Models.Manager", "manager")
                        .WithMany("trainingCenters")
                        .HasForeignKey("managerId");

                    b.Navigation("manager");
                });

            modelBuilder.Entity("SkillUp.Models.Candidat", b =>
                {
                    b.Navigation("achats");
                });

            modelBuilder.Entity("SkillUp.Models.Manager", b =>
                {
                    b.Navigation("trainingCenters");
                });

            modelBuilder.Entity("SkillUp.Models.Training", b =>
                {
                    b.Navigation("achats");
                });

            modelBuilder.Entity("SkillUp.Models.TrainingCenter", b =>
                {
                    b.Navigation("trainingCenters");
                });
#pragma warning restore 612, 618
        }
    }
}
