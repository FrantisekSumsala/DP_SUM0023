﻿// <auto-generated />
using System;
using DP_SUM0023.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DPSUM0023.Migrations
{
    [DbContext(typeof(CustomDbContext))]
    [Migration("20230205231249_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DP_SUM0023.Data.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("company");
                });

            modelBuilder.Entity("DP_SUM0023.Data.Models.Process", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("UserAccountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserAccountId");

                    b.ToTable("process");
                });

            modelBuilder.Entity("DP_SUM0023.Data.Models.ProcessEvaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePerformed")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EvaluatorAccountId")
                        .HasColumnType("int");

                    b.Property<int>("ProcessId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EvaluatorAccountId");

                    b.HasIndex("ProcessId");

                    b.ToTable("processevaluation");
                });

            modelBuilder.Entity("DP_SUM0023.Data.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("project");
                });

            modelBuilder.Entity("DP_SUM0023.Data.Models.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("useraccount");
                });

            modelBuilder.Entity("DP_SUM0023.Data.Models.UserAccountLogin", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Username");

                    b.HasIndex("AccountId");

                    b.ToTable("useraccountlogin");
                });

            modelBuilder.Entity("DP_SUM0023.Data.Models.UserAccountRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("useraccountrole");
                });

            modelBuilder.Entity("DP_SUM0023.Data.Models.Process", b =>
                {
                    b.HasOne("DP_SUM0023.Data.Models.Project", "Project")
                        .WithMany("Processes")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DP_SUM0023.Data.Models.UserAccount", null)
                        .WithMany("AssignedProcesses")
                        .HasForeignKey("UserAccountId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DP_SUM0023.Data.Models.ProcessEvaluation", b =>
                {
                    b.HasOne("DP_SUM0023.Data.Models.UserAccount", "EvaluatorAccount")
                        .WithMany()
                        .HasForeignKey("EvaluatorAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DP_SUM0023.Data.Models.Process", "Process")
                        .WithMany("Evaluations")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EvaluatorAccount");

                    b.Navigation("Process");
                });

            modelBuilder.Entity("DP_SUM0023.Data.Models.Project", b =>
                {
                    b.HasOne("DP_SUM0023.Data.Models.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("DP_SUM0023.Data.Models.UserAccount", b =>
                {
                    b.HasOne("DP_SUM0023.Data.Models.UserAccountRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DP_SUM0023.Data.Models.UserAccountLogin", b =>
                {
                    b.HasOne("DP_SUM0023.Data.Models.UserAccount", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DP_SUM0023.Data.Models.Company", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("DP_SUM0023.Data.Models.Process", b =>
                {
                    b.Navigation("Evaluations");
                });

            modelBuilder.Entity("DP_SUM0023.Data.Models.Project", b =>
                {
                    b.Navigation("Processes");
                });

            modelBuilder.Entity("DP_SUM0023.Data.Models.UserAccount", b =>
                {
                    b.Navigation("AssignedProcesses");
                });
#pragma warning restore 612, 618
        }
    }
}
