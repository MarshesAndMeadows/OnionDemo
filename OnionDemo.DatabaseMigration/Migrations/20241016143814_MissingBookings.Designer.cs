﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnionDemo.Infrastructure;

#nullable disable

namespace OnionDemo.DatabaseMigration.Migrations
{
    [DbContext(typeof(BookMyHomeContext))]
    [Migration("20241016143814_MissingBookings")]
    partial class MissingBookings
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnionDemo.Domain.Entity.Accommodation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HostId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("HostId");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("OnionDemo.Domain.Entity.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("GuestId");

                    b.HasIndex("ReviewId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("OnionDemo.Domain.Entity.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("OnionDemo.Domain.Entity.Host", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Hosts");
                });

            modelBuilder.Entity("OnionDemo.Domain.Entity.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Blurb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("OnionDemo.Domain.Entity.Accommodation", b =>
                {
                    b.HasOne("OnionDemo.Domain.Entity.Host", "Host")
                        .WithMany("Accommodations")
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Host");
                });

            modelBuilder.Entity("OnionDemo.Domain.Entity.Booking", b =>
                {
                    b.HasOne("OnionDemo.Domain.Entity.Accommodation", null)
                        .WithMany("Bookings")
                        .HasForeignKey("AccommodationId");

                    b.HasOne("OnionDemo.Domain.Entity.Guest", "Guest")
                        .WithMany("Bookings")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnionDemo.Domain.Entity.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId");

                    b.Navigation("Guest");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("OnionDemo.Domain.Entity.Accommodation", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("OnionDemo.Domain.Entity.Guest", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("OnionDemo.Domain.Entity.Host", b =>
                {
                    b.Navigation("Accommodations");
                });
#pragma warning restore 612, 618
        }
    }
}
