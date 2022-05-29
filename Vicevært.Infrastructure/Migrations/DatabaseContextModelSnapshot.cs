﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vicevært.Infrastructure.Database;

#nullable disable

namespace Vicevært.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Vicevært.Domain.Entities.Lejemaal", b =>
                {
                    b.Property<int>("LejemålId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LejemålId"), 1L, 1);

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBookable")
                        .HasColumnType("bit");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LejemålId");

                    b.ToTable("Lejemaal");
                });

            modelBuilder.Entity("Vicevært.Domain.Entities.Lejer", b =>
                {
                    b.Property<int>("LejerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LejerId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LejemaalId")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LejerId");

                    b.HasIndex("LejemaalId");

                    b.ToTable("Lejer");
                });

            modelBuilder.Entity("Vicevært.Domain.Entities.Rekvisition", b =>
                {
                    b.Property<int>("RekvisitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RekvisitionId"), 1L, 1);

                    b.Property<string>("Kommentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LejerId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("RekvisitionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RekvisitionId");

                    b.HasIndex("LejerId");

                    b.ToTable("Rekvisition");
                });

            modelBuilder.Entity("Vicevært.Domain.Entities.Lejer", b =>
                {
                    b.HasOne("Vicevært.Domain.Entities.Lejemaal", "Lejemaal")
                        .WithMany()
                        .HasForeignKey("LejemaalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lejemaal");
                });

            modelBuilder.Entity("Vicevært.Domain.Entities.Rekvisition", b =>
                {
                    b.HasOne("Vicevært.Domain.Entities.Lejer", "Lejer")
                        .WithMany()
                        .HasForeignKey("LejerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lejer");
                });
#pragma warning restore 612, 618
        }
    }
}
