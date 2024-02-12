﻿// <auto-generated />
using DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AirportDbContext))]
    [Migration("20240211180135_AddRouteWithAirportRelationship")]
    partial class AddRouteWithAirportRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Model.Airport", b =>
                {
                    b.Property<int>("AirportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AirportId"));

                    b.Property<int>("GeographyLevel1Id")
                        .HasColumnType("int");

                    b.Property<string>("IATACode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AirportId");

                    b.HasIndex("GeographyLevel1Id");

                    b.ToTable("Airport");
                });

            modelBuilder.Entity("DataAccess.Model.Country", b =>
                {
                    b.Property<int>("GeographyLevel1Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeographyLevel1Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GeographyLevel1Id")
                        .HasName("Pk_GeographyLevel1Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("GeographyLevel1");
                });

            modelBuilder.Entity("DataAccess.Model.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteId"));

                    b.Property<int>("ArrivalAirportId")
                        .HasColumnType("int");

                    b.Property<int>("DepartureAirportId")
                        .HasColumnType("int");

                    b.HasKey("RouteId");

                    b.HasIndex("ArrivalAirportId");

                    b.HasIndex("DepartureAirportId");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("DataAccess.Model.Airport", b =>
                {
                    b.HasOne("DataAccess.Model.Country", "Country")
                        .WithMany("Airports")
                        .HasForeignKey("GeographyLevel1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DataAccess.Model.Route", b =>
                {
                    b.HasOne("DataAccess.Model.Airport", "ArrivalAirport")
                        .WithMany("ArrivalAirportRoutes")
                        .HasForeignKey("ArrivalAirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Model.Airport", "DepartureAirport")
                        .WithMany("DepartureAirportRoutes")
                        .HasForeignKey("DepartureAirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArrivalAirport");

                    b.Navigation("DepartureAirport");
                });

            modelBuilder.Entity("DataAccess.Model.Airport", b =>
                {
                    b.Navigation("ArrivalAirportRoutes");

                    b.Navigation("DepartureAirportRoutes");
                });

            modelBuilder.Entity("DataAccess.Model.Country", b =>
                {
                    b.Navigation("Airports");
                });
#pragma warning restore 612, 618
        }
    }
}
