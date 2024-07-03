﻿// <auto-generated />
using System;
using System.Collections.Generic;
using BirdAPI.ApiService.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BirdAPI.ApiService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240703153104_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BirdAPI.ApiService.Database.Models.Label", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("RecordingId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RecordingId");

                    b.ToTable("Label");
                });

            modelBuilder.Entity("BirdAPI.ApiService.Database.Models.Osci", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("large")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("med")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("small")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Oscis");
                });

            modelBuilder.Entity("BirdAPI.ApiService.Database.Models.Recording", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Duration")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Recordings");
                });

            modelBuilder.Entity("BirdAPI.ApiService.Database.Models.Sono", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("full")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("large")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("med")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("small")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sonos");
                });

            modelBuilder.Entity("BirdAPI.ApiService.Database.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BirdAPI.ApiService.Database.Models.XenoCantoEntry", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<List<string>>("also")
                        .HasColumnType("text[]");

                    b.Property<string>("alt")
                        .HasColumnType("text");

                    b.Property<string>("animalSeen")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "animal-seen");

                    b.Property<string>("auto")
                        .HasColumnType("text");

                    b.Property<string>("birdSeen")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "bird-seen");

                    b.Property<string>("cnt")
                        .HasColumnType("text");

                    b.Property<string>("date")
                        .HasColumnType("text");

                    b.Property<string>("dvc")
                        .HasColumnType("text");

                    b.Property<string>("en")
                        .HasColumnType("text");

                    b.Property<string>("file")
                        .HasColumnType("text");

                    b.Property<string>("fileName")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "file-name");

                    b.Property<string>("gen")
                        .HasColumnType("text");

                    b.Property<string>("group")
                        .HasColumnType("text");

                    b.Property<string>("lat")
                        .HasColumnType("text");

                    b.Property<string>("length")
                        .HasColumnType("text");

                    b.Property<string>("lic")
                        .HasColumnType("text");

                    b.Property<string>("lng")
                        .HasColumnType("text");

                    b.Property<string>("loc")
                        .HasColumnType("text");

                    b.Property<string>("method")
                        .HasColumnType("text");

                    b.Property<string>("mic")
                        .HasColumnType("text");

                    b.Property<string>("playbackUsed")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "playback-used");

                    b.Property<string>("q")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("rec")
                        .HasColumnType("text");

                    b.Property<string>("regnr")
                        .HasColumnType("text");

                    b.Property<string>("rmk")
                        .HasColumnType("text");

                    b.Property<string>("sex")
                        .HasColumnType("text");

                    b.Property<string>("smp")
                        .HasColumnType("text");

                    b.Property<string>("sp")
                        .HasColumnType("text");

                    b.Property<string>("ssp")
                        .HasColumnType("text");

                    b.Property<string>("stage")
                        .HasColumnType("text");

                    b.Property<string>("temp")
                        .HasColumnType("text");

                    b.Property<string>("time")
                        .HasColumnType("text");

                    b.Property<string>("type")
                        .HasColumnType("text");

                    b.Property<string>("uploaded")
                        .HasColumnType("text");

                    b.Property<string>("url")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("XenoCantoEntries");
                });

            modelBuilder.Entity("BirdAPI.ApiService.Database.Models.Label", b =>
                {
                    b.HasOne("BirdAPI.ApiService.Database.Models.Recording", "Recording")
                        .WithMany("Labels")
                        .HasForeignKey("RecordingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recording");
                });

            modelBuilder.Entity("BirdAPI.ApiService.Database.Models.Osci", b =>
                {
                    b.HasOne("BirdAPI.ApiService.Database.Models.XenoCantoEntry", "XenoCantoEntry")
                        .WithOne("osci")
                        .HasForeignKey("BirdAPI.ApiService.Database.Models.Osci", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("XenoCantoEntry");
                });

            modelBuilder.Entity("BirdAPI.ApiService.Database.Models.Sono", b =>
                {
                    b.HasOne("BirdAPI.ApiService.Database.Models.XenoCantoEntry", "XenoCantoEntry")
                        .WithOne("sono")
                        .HasForeignKey("BirdAPI.ApiService.Database.Models.Sono", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("XenoCantoEntry");
                });

            modelBuilder.Entity("BirdAPI.ApiService.Database.Models.Recording", b =>
                {
                    b.Navigation("Labels");
                });

            modelBuilder.Entity("BirdAPI.ApiService.Database.Models.XenoCantoEntry", b =>
                {
                    b.Navigation("osci")
                        .IsRequired();

                    b.Navigation("sono")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
