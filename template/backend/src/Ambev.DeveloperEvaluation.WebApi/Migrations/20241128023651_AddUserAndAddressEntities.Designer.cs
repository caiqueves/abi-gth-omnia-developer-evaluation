﻿// <auto-generated />
using System;
using Ambev.DeveloperEvaluation.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ambev.DeveloperEvaluation.WebApi.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20241128023651_AddUserAndAddressEntities")]
    partial class AddUserAndAddressEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("GeolocationId")
                        .HasColumnType("uuid");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GeolocationId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Geolocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Lat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Long")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Geolocation");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Address", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Geolocation", "Geolocation")
                        .WithMany()
                        .HasForeignKey("GeolocationId");

                    b.Navigation("Geolocation");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.User", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
