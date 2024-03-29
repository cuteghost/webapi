﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server.Database;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(DentalDBContext))]
    partial class DentalDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Domain.Appointment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AppointmentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("PatientId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StaffId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("StaffId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Models.Domain.Blog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Models.Domain.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Models.Domain.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Models.Domain.Education", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime");

                    b.Property<long?>("LocationId")
                        .HasColumnType("bigint");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("StaffId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("StaffId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("Models.Domain.Experience", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime");

                    b.Property<long?>("LocationId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StaffId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime");

                    b.Property<string>("WorkPlace")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("StaffId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("Models.Domain.Invoice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime");

                    b.Property<long?>("PatientId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StaffId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("StaffId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Models.Domain.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Models.Domain.Material", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("StockAmount")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Models.Domain.Patient", b =>
                {
                    b.Property<long>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PatientId"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Alergies")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime>("FirstVisitDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("LastPaymentDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("LastVisitDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Perceptions")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar");

                    b.Property<string>("SpecialRequests")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("PatientId");

                    b.HasIndex("UserId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Models.Domain.Staff", b =>
                {
                    b.Property<long>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("StaffId"));

                    b.Property<DateTime>("Joined")
                        .HasColumnType("datetime");

                    b.Property<string>("Languages")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("StaffId");

                    b.HasIndex("UserId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("Models.Domain.Treatment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AppointmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DiagnosisCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("InvoiceId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("TreatmentDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("Models.Domain.TreatmentItems", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<long?>("MaterialId")
                        .HasColumnType("bigint");

                    b.Property<float>("RequiredAmount")
                        .HasColumnType("real");

                    b.Property<long?>("TreatmentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("TreatmentItems");
                });

            modelBuilder.Entity("Models.Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar");

                    b.Property<short>("Gender")
                        .HasColumnType("smallint");

                    b.Property<string>("JMBG")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.Domain.Appointment", b =>
                {
                    b.HasOne("Models.Domain.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.HasOne("Models.Domain.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId");

                    b.Navigation("Patient");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("Models.Domain.Blog", b =>
                {
                    b.HasOne("Models.Domain.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Models.Domain.City", b =>
                {
                    b.HasOne("Models.Domain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Models.Domain.Education", b =>
                {
                    b.HasOne("Models.Domain.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("Models.Domain.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId");

                    b.Navigation("Location");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("Models.Domain.Experience", b =>
                {
                    b.HasOne("Models.Domain.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("Models.Domain.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId");

                    b.Navigation("Location");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("Models.Domain.Invoice", b =>
                {
                    b.HasOne("Models.Domain.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.HasOne("Models.Domain.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId");

                    b.Navigation("Patient");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("Models.Domain.Location", b =>
                {
                    b.HasOne("Models.Domain.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Models.Domain.Patient", b =>
                {
                    b.HasOne("Models.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Domain.Staff", b =>
                {
                    b.HasOne("Models.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Domain.Treatment", b =>
                {
                    b.HasOne("Models.Domain.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Domain.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.Navigation("Appointment");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Models.Domain.TreatmentItems", b =>
                {
                    b.HasOne("Models.Domain.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

                    b.HasOne("Models.Domain.Treatment", "Treatment")
                        .WithMany()
                        .HasForeignKey("TreatmentId");

                    b.Navigation("Material");

                    b.Navigation("Treatment");
                });
#pragma warning restore 612, 618
        }
    }
}
