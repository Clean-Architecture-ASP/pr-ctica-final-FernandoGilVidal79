﻿// <auto-generated />
using System;
using CleanArchitecture.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CleanArchitecture.Domain.Apartments.Apartment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("LastRentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_rent_date");

                    b.HasKey("Id")
                        .HasName("pk_apartments");

                    b.ToTable("apartments", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Rents.Rent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CancelDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("cancel_date");

                    b.Property<DateTime?>("CompleteDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("complete_date");

                    b.Property<DateTime?>("ConfirmationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("confirmation_date");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<DateTime?>("RejectDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("reject_date");

                    b.Property<int>("RentStatus")
                        .HasColumnType("integer")
                        .HasColumnName("rent_status");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid>("VehiculeId")
                        .HasColumnType("uuid")
                        .HasColumnName("vehicule_id");

                    b.HasKey("Id")
                        .HasName("pk_rents");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_rents_user_id");

                    b.HasIndex("VehiculeId")
                        .HasDatabaseName("ix_rents_vehicule_id");

                    b.ToTable("rents", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Reviews.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("comment");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<Guid>("RentId")
                        .HasColumnType("uuid")
                        .HasColumnName("rent_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uuid")
                        .HasColumnName("vehicle_id");

                    b.HasKey("Id")
                        .HasName("pk_reviews");

                    b.HasIndex("RentId")
                        .HasDatabaseName("ix_reviews_rent_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_reviews_user_id");

                    b.HasIndex("VehicleId")
                        .HasDatabaseName("ix_reviews_vehicle_id");

                    b.ToTable("reviews", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.Property<string>("Surname")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Vehicles.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int[]>("Extras")
                        .IsRequired()
                        .HasColumnType("integer[]")
                        .HasColumnName("extras");

                    b.Property<DateTime?>("LastRentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_rent_date");

                    b.Property<string>("Model")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("model");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.Property<string>("Vin")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("vin");

                    b.HasKey("Id")
                        .HasName("pk_vehicles");

                    b.ToTable("vehicles", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Apartments.Apartment", b =>
                {
                    b.OwnsOne("CleanArchitecture.Domain.Shared.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("ApartmentId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_country");

                            b1.Property<string>("Departure")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_departure");

                            b1.Property<string>("Province")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_province");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_street");

                            b1.HasKey("ApartmentId");

                            b1.ToTable("apartments");

                            b1.WithOwner()
                                .HasForeignKey("ApartmentId")
                                .HasConstraintName("fk_apartments_apartments_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Currency", "Price", b1 =>
                        {
                            b1.Property<Guid>("ApartmentId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("currencyType")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("price_currency_type");

                            b1.Property<decimal>("quantity")
                                .HasColumnType("numeric")
                                .HasColumnName("price_quantity");

                            b1.HasKey("ApartmentId");

                            b1.ToTable("apartments");

                            b1.WithOwner()
                                .HasForeignKey("ApartmentId")
                                .HasConstraintName("fk_apartments_apartments_id");
                        });

                    b.Navigation("Address");

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Rents.Rent", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_rents_user_user_id");

                    b.HasOne("CleanArchitecture.Domain.Apartments.Apartment", null)
                        .WithMany()
                        .HasForeignKey("VehiculeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_rents_apartments_apartment_id");

                    b.HasOne("CleanArchitecture.Domain.Vehicles.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiculeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_rents_vehicle_vehicle_id");

                    b.OwnsOne("CleanArchitecture.Domain.Rents.DateRange", "Duration", b1 =>
                        {
                            b1.Property<Guid>("RentId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<DateOnly>("End")
                                .HasColumnType("date")
                                .HasColumnName("duration_end");

                            b1.Property<DateOnly>("Start")
                                .HasColumnType("date")
                                .HasColumnName("duration_start");

                            b1.HasKey("RentId");

                            b1.ToTable("rents");

                            b1.WithOwner()
                                .HasForeignKey("RentId")
                                .HasConstraintName("fk_rents_rents_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Currency", "ExtraPrice", b1 =>
                        {
                            b1.Property<Guid>("RentId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("currencyType")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("extra_price_currency_type");

                            b1.Property<decimal>("quantity")
                                .HasColumnType("numeric")
                                .HasColumnName("extra_price_quantity");

                            b1.HasKey("RentId");

                            b1.ToTable("rents");

                            b1.WithOwner()
                                .HasForeignKey("RentId")
                                .HasConstraintName("fk_rents_rents_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Currency", "MaintenancePrice", b1 =>
                        {
                            b1.Property<Guid>("RentId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("currencyType")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("maintenance_price_currency_type");

                            b1.Property<decimal>("quantity")
                                .HasColumnType("numeric")
                                .HasColumnName("maintenance_price_quantity");

                            b1.HasKey("RentId");

                            b1.ToTable("rents");

                            b1.WithOwner()
                                .HasForeignKey("RentId")
                                .HasConstraintName("fk_rents_rents_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Currency", "Price", b1 =>
                        {
                            b1.Property<Guid>("RentId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("currencyType")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("price_currency_type");

                            b1.Property<decimal>("quantity")
                                .HasColumnType("numeric")
                                .HasColumnName("price_quantity");

                            b1.HasKey("RentId");

                            b1.ToTable("rents");

                            b1.WithOwner()
                                .HasForeignKey("RentId")
                                .HasConstraintName("fk_rents_rents_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Currency", "TotalPrice", b1 =>
                        {
                            b1.Property<Guid>("RentId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("currencyType")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("total_price_currency_type");

                            b1.Property<decimal>("quantity")
                                .HasColumnType("numeric")
                                .HasColumnName("total_price_quantity");

                            b1.HasKey("RentId");

                            b1.ToTable("rents");

                            b1.WithOwner()
                                .HasForeignKey("RentId")
                                .HasConstraintName("fk_rents_rents_id");
                        });

                    b.Navigation("Duration");

                    b.Navigation("ExtraPrice")
                        .IsRequired();

                    b.Navigation("MaintenancePrice")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("TotalPrice")
                        .IsRequired();
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Reviews.Review", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Rents.Rent", null)
                        .WithMany()
                        .HasForeignKey("RentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_rents_rent_id");

                    b.HasOne("CleanArchitecture.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_user_user_id");

                    b.HasOne("CleanArchitecture.Domain.Vehicles.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_vehicle_vehicle_id");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Vehicles.Vehicle", b =>
                {
                    b.OwnsOne("CleanArchitecture.Domain.Shared.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("VehicleId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_country");

                            b1.Property<string>("Departure")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_departure");

                            b1.Property<string>("Province")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_province");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_street");

                            b1.HasKey("VehicleId");

                            b1.ToTable("vehicles");

                            b1.WithOwner()
                                .HasForeignKey("VehicleId")
                                .HasConstraintName("fk_vehicles_vehicles_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Currency", "Maintenance", b1 =>
                        {
                            b1.Property<Guid>("VehicleId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("currencyType")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("maintenance_currency_type");

                            b1.Property<decimal>("quantity")
                                .HasColumnType("numeric")
                                .HasColumnName("maintenance_quantity");

                            b1.HasKey("VehicleId");

                            b1.ToTable("vehicles");

                            b1.WithOwner()
                                .HasForeignKey("VehicleId")
                                .HasConstraintName("fk_vehicles_vehicles_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Currency", "Price", b1 =>
                        {
                            b1.Property<Guid>("VehicleId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("currencyType")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("price_currency_type");

                            b1.Property<decimal>("quantity")
                                .HasColumnType("numeric")
                                .HasColumnName("price_quantity");

                            b1.HasKey("VehicleId");

                            b1.ToTable("vehicles");

                            b1.WithOwner()
                                .HasForeignKey("VehicleId")
                                .HasConstraintName("fk_vehicles_vehicles_id");
                        });

                    b.Navigation("Address");

                    b.Navigation("Maintenance")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
