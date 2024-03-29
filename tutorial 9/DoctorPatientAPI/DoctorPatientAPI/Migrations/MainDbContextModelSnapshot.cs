﻿// <auto-generated />
using System;
using DoctorPatientAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoctorPatientAPI.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DoctorPatientAPI.Models.AppUser", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExp")
                        .HasColumnType("datetime");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DoctorPatientAPI.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdDoctor");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "jan@gmail.com",
                            FirstName = "Jan",
                            LastName = "Kowak"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "ksmith@gmail.com",
                            FirstName = "Ken",
                            LastName = "Smith"
                        },
                        new
                        {
                            IdDoctor = 3,
                            Email = "alisacat@gmail.com",
                            FirstName = "Alisa",
                            LastName = "Kathe"
                        });
                });

            modelBuilder.Entity("DoctorPatientAPI.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdMedicament");

                    b.ToTable("Medicaments");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "default",
                            Name = "",
                            Type = ""
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "default",
                            Name = "",
                            Type = ""
                        },
                        new
                        {
                            IdMedicament = 3,
                            Description = "default",
                            Name = "",
                            Type = ""
                        },
                        new
                        {
                            IdMedicament = 4,
                            Description = "default",
                            Name = "",
                            Type = ""
                        },
                        new
                        {
                            IdMedicament = 5,
                            Description = "default",
                            Name = "",
                            Type = ""
                        });
                });

            modelBuilder.Entity("DoctorPatientAPI.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdPatient");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            Birthdate = new DateTime(2021, 5, 17, 1, 28, 20, 223, DateTimeKind.Local).AddTicks(1054),
                            FirstName = "Lolita",
                            LastName = "Kowalski"
                        },
                        new
                        {
                            IdPatient = 2,
                            Birthdate = new DateTime(2021, 5, 17, 1, 28, 20, 225, DateTimeKind.Local).AddTicks(542),
                            FirstName = "Kevin",
                            LastName = "Kim"
                        },
                        new
                        {
                            IdPatient = 3,
                            Birthdate = new DateTime(2021, 5, 17, 1, 28, 20, 225, DateTimeKind.Local).AddTicks(586),
                            FirstName = "Alisher",
                            LastName = "Sabirov"
                        });
                });

            modelBuilder.Entity("DoctorPatientAPI.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescriptions");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(1076),
                            DueDate = new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(1930),
                            IdDoctor = 2,
                            IdPatient = 2
                        },
                        new
                        {
                            IdPrescription = 2,
                            Date = new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4355),
                            DueDate = new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4364),
                            IdDoctor = 1,
                            IdPatient = 3
                        },
                        new
                        {
                            IdPrescription = 3,
                            Date = new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4367),
                            DueDate = new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4369),
                            IdDoctor = 3,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 4,
                            Date = new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4372),
                            DueDate = new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4373),
                            IdDoctor = 2,
                            IdPatient = 3
                        },
                        new
                        {
                            IdPrescription = 5,
                            Date = new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4377),
                            DueDate = new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4378),
                            IdDoctor = 1,
                            IdPatient = 1
                        });
                });

            modelBuilder.Entity("DoctorPatientAPI.Models.Prescription_Medicament", b =>
                {
                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription");

                    b.HasIndex("IdMedicament");

                    b.ToTable("Prescription_Medicaments");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Details = "default",
                            Dose = 3,
                            IdMedicament = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            Details = "default",
                            IdMedicament = 2
                        },
                        new
                        {
                            IdPrescription = 3,
                            Details = "default",
                            Dose = 10,
                            IdMedicament = 3
                        },
                        new
                        {
                            IdPrescription = 4,
                            Details = "default",
                            IdMedicament = 4
                        },
                        new
                        {
                            IdPrescription = 5,
                            Details = "default",
                            Dose = 5,
                            IdMedicament = 5
                        });
                });

            modelBuilder.Entity("DoctorPatientAPI.Models.Prescription", b =>
                {
                    b.HasOne("DoctorPatientAPI.Models.Doctor", "IdDoctorNavigation")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .IsRequired();

                    b.HasOne("DoctorPatientAPI.Models.Patient", "IdPatientNavigation")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .IsRequired();

                    b.Navigation("IdDoctorNavigation");

                    b.Navigation("IdPatientNavigation");
                });

            modelBuilder.Entity("DoctorPatientAPI.Models.Prescription_Medicament", b =>
                {
                    b.HasOne("DoctorPatientAPI.Models.Medicament", "IdMedicamentNavigation")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdMedicament")
                        .IsRequired();

                    b.HasOne("DoctorPatientAPI.Models.Prescription", "IdPrescriptionNavigation")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdPrescription")
                        .IsRequired();

                    b.Navigation("IdMedicamentNavigation");

                    b.Navigation("IdPrescriptionNavigation");
                });

            modelBuilder.Entity("DoctorPatientAPI.Models.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("DoctorPatientAPI.Models.Medicament", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });

            modelBuilder.Entity("DoctorPatientAPI.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("DoctorPatientAPI.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}
