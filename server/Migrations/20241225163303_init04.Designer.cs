﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server.DBContext;

#nullable disable

namespace server.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20241225163303_init04")]
    partial class init04
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("server.Models.MovieModel", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ratings")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("server.Models.ShowModel", b =>
                {
                    b.Property<int>("showID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("showID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("cost")
                        .HasColumnType("int");

                    b.Property<int>("movieID")
                        .HasColumnType("int");

                    b.Property<string>("seats")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("slot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("theaterID")
                        .HasColumnType("int");

                    b.HasKey("showID");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("server.Models.TheaterModel", b =>
                {
                    b.Property<int>("theaterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("theaterId"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("theaterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("theaterId");

                    b.ToTable("Theater");
                });

            modelBuilder.Entity("server.Models.TicketModal", b =>
                {
                    b.Property<int>("ticketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ticketID"));

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.Property<int>("movieID")
                        .HasColumnType("int");

                    b.Property<string>("seats")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("showID")
                        .HasColumnType("int");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("ticketID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("server.Models.UserModal", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userID"));

                    b.Property<int>("balance")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
