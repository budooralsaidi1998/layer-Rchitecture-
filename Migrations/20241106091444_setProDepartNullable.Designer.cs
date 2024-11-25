﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OutsysCompany;

#nullable disable

namespace OutsysCompany.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241106091444_setProDepartNullable")]
    partial class setProDepartNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OutsysCompany.Models.Attedence", b =>
                {
                    b.Property<int>("EmpleeID")
                        .HasColumnType("int");

                    b.Property<string>("month")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.Property<int>("AbsentDays")
                        .HasColumnType("int");

                    b.HasKey("EmpleeID", "month", "year");

                    b.ToTable("Atteces");
                });

            modelBuilder.Entity("OutsysCompany.Models.Department", b =>
                {
                    b.Property<int>("Dnumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dnumber"));

                    b.Property<string>("Dname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MgrSsn")
                        .HasColumnType("int");

                    b.Property<DateTime>("MgrStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Dnumber");

                    b.HasIndex("MgrSsn");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("OutsysCompany.Models.Dependent", b =>
                {
                    b.Property<int>("Essn")
                        .HasColumnType("int");

                    b.Property<string>("DependentName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Bdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Relationship")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Essn", "DependentName");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("OutsysCompany.Models.DeptLocation", b =>
                {
                    b.Property<int>("Dnumber")
                        .HasColumnType("int");

                    b.Property<string>("Dlocation")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Dnumber", "Dlocation");

                    b.ToTable("DeptLocations");
                });

            modelBuilder.Entity("OutsysCompany.Models.Employee", b =>
                {
                    b.Property<int>("Ssn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ssn"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Bdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Dno")
                        .HasColumnType("int");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Minit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SuperSsn")
                        .HasColumnType("int");

                    b.HasKey("Ssn");

                    b.HasIndex("Dno");

                    b.HasIndex("SuperSsn");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OutsysCompany.Models.Project", b =>
                {
                    b.Property<int>("Pnumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pnumber"));

                    b.Property<int?>("Dnum")
                        .HasColumnType("int");

                    b.Property<string>("Plocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pnumber");

                    b.HasIndex("Dnum");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("OutsysCompany.Models.WorksOn", b =>
                {
                    b.Property<int>("Essn")
                        .HasColumnType("int");

                    b.Property<int>("Pno")
                        .HasColumnType("int");

                    b.Property<decimal>("Hours")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Essn", "Pno");

                    b.HasIndex("Pno");

                    b.ToTable("WorksOn");
                });

            modelBuilder.Entity("OutsysCompany.Models.Attedence", b =>
                {
                    b.HasOne("OutsysCompany.Models.Employee", "employee")
                        .WithMany("Attedences")
                        .HasForeignKey("EmpleeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
                });

            modelBuilder.Entity("OutsysCompany.Models.Department", b =>
                {
                    b.HasOne("OutsysCompany.Models.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("MgrSsn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("OutsysCompany.Models.Dependent", b =>
                {
                    b.HasOne("OutsysCompany.Models.Employee", "Employee")
                        .WithMany("Dependents")
                        .HasForeignKey("Essn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("OutsysCompany.Models.DeptLocation", b =>
                {
                    b.HasOne("OutsysCompany.Models.Department", "Department")
                        .WithMany("Locations")
                        .HasForeignKey("Dnumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("OutsysCompany.Models.Employee", b =>
                {
                    b.HasOne("OutsysCompany.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("Dno");

                    b.HasOne("OutsysCompany.Models.Employee", "Supervisor")
                        .WithMany("Supervisees")
                        .HasForeignKey("SuperSsn");

                    b.Navigation("Department");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("OutsysCompany.Models.Project", b =>
                {
                    b.HasOne("OutsysCompany.Models.Department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("Dnum");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("OutsysCompany.Models.WorksOn", b =>
                {
                    b.HasOne("OutsysCompany.Models.Employee", "Employee")
                        .WithMany("WorksOnProjects")
                        .HasForeignKey("Essn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OutsysCompany.Models.Project", "Project")
                        .WithMany("WorksOnEmployees")
                        .HasForeignKey("Pno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("OutsysCompany.Models.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Locations");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("OutsysCompany.Models.Employee", b =>
                {
                    b.Navigation("Attedences");

                    b.Navigation("Dependents");

                    b.Navigation("Supervisees");

                    b.Navigation("WorksOnProjects");
                });

            modelBuilder.Entity("OutsysCompany.Models.Project", b =>
                {
                    b.Navigation("WorksOnEmployees");
                });
#pragma warning restore 612, 618
        }
    }
}
