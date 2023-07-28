﻿// <auto-generated />
using System;
using ApiPeliculasEFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiPeliculasEFCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Birthdate = new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fortune = 15000m,
                            Name = "Samuel L. Jackson"
                        },
                        new
                        {
                            Id = 3,
                            Birthdate = new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fortune = 18000m,
                            Name = "Robert Downey Jr."
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Content = "I Love it",
                            FilmId = 2,
                            Recommend = true
                        },
                        new
                        {
                            Id = 3,
                            Content = "A very good film",
                            FilmId = 2,
                            Recommend = true
                        },
                        new
                        {
                            Id = 4,
                            Content = "I dont really like it",
                            FilmId = 3,
                            Recommend = false
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 2,
                            InTheaters = false,
                            ReleaseDate = new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Avengers EndGame"
                        },
                        new
                        {
                            Id = 3,
                            InTheaters = false,
                            ReleaseDate = new DateTime(2021, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Spider-Man: No Way Home"
                        },
                        new
                        {
                            Id = 4,
                            InTheaters = false,
                            ReleaseDate = new DateTime(2022, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Spider-Man: Across the Spider-Verse (Part One)"
                        });
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

                    b.HasData(
                        new
                        {
                            ActorId = 2,
                            FilmId = 3,
                            Character = "Nick Fury",
                            Order = 1
                        },
                        new
                        {
                            ActorId = 2,
                            FilmId = 2,
                            Character = "Nick Fury",
                            Order = 2
                        },
                        new
                        {
                            ActorId = 3,
                            FilmId = 2,
                            Character = "Iron Man",
                            Order = 1
                        });
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

                    b.HasIndex("Name")
                        .IsUnique();

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

                    b.HasData(
                        new
                        {
                            GenresId = 5,
                            filmsId = 2
                        },
                        new
                        {
                            GenresId = 5,
                            filmsId = 3
                        },
                        new
                        {
                            GenresId = 6,
                            filmsId = 4
                        });
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
