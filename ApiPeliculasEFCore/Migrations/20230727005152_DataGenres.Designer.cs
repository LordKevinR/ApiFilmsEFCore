﻿// <auto-generated />
using System;
using ApiPeliculasEFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiPeliculasEFCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230727005152_DataGenres")]
    partial class DataGenres
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiPeliculasEFCore.Entities.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("date");

                    b.Property<decimal>("Fortune")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("ApiPeliculasEFCore.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<bool>("Recommend")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ApiPeliculasEFCore.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("InTheaters")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("ApiPeliculasEFCore.Entities.FilmActor", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("Character")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("ActorId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("FilmsActors");
                });

            modelBuilder.Entity("ApiPeliculasEFCore.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Animation"
                        });
                });

            modelBuilder.Entity("FilmGenre", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("filmsId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "filmsId");

                    b.HasIndex("filmsId");

                    b.ToTable("FilmGenre");
                });

            modelBuilder.Entity("ApiPeliculasEFCore.Entities.Comment", b =>
                {
                    b.HasOne("ApiPeliculasEFCore.Entities.Film", "Film")
                        .WithMany("Comments")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");
                });

            modelBuilder.Entity("ApiPeliculasEFCore.Entities.FilmActor", b =>
                {
                    b.HasOne("ApiPeliculasEFCore.Entities.Actor", "Actor")
                        .WithMany("FilmsActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiPeliculasEFCore.Entities.Film", "Film")
                        .WithMany("FilmsActors")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("FilmGenre", b =>
                {
                    b.HasOne("ApiPeliculasEFCore.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiPeliculasEFCore.Entities.Film", null)
                        .WithMany()
                        .HasForeignKey("filmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiPeliculasEFCore.Entities.Actor", b =>
                {
                    b.Navigation("FilmsActors");
                });

            modelBuilder.Entity("ApiPeliculasEFCore.Entities.Film", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FilmsActors");
                });
#pragma warning restore 612, 618
        }
    }
}
