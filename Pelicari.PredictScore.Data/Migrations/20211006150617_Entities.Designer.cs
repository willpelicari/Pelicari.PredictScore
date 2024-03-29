﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pelicari.PredictScore.Data.Models.Context;

namespace Pelicari.PredictScore.Data.Migrations
{
    [DbContext(typeof(PredictScoreContext))]
    [Migration("20211006150617_Entities")]
    partial class Entities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("GroupSeason", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("SeasonsId")
                        .HasColumnType("int");

                    b.HasKey("GroupsId", "SeasonsId");

                    b.HasIndex("SeasonsId");

                    b.ToTable("GroupSeason");
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("GroupsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GuestTeamId")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<int>("RoundId")
                        .HasColumnType("int");

                    b.Property<int>("ScoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuestTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("RoundId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Prediction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("ScoreId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("ScoreId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Predictions");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("GuestScore")
                        .HasColumnType("int");

                    b.Property<int>("HomeScore")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId")
                        .IsUnique();

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SportId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Sport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Initials")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SportId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GroupSeason", b =>
                {
                    b.HasOne("Pelicari.PredictScore.Data.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pelicari.PredictScore.Data.Models.Season", null)
                        .WithMany()
                        .HasForeignKey("SeasonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.HasOne("Pelicari.PredictScore.Data.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pelicari.PredictScore.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Group", b =>
                {
                    b.HasOne("Pelicari.PredictScore.Data.Models.User", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Match", b =>
                {
                    b.HasOne("Pelicari.PredictScore.Data.Models.Team", "GuestTeam")
                        .WithMany()
                        .HasForeignKey("GuestTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pelicari.PredictScore.Data.Models.Team", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pelicari.PredictScore.Data.Models.Round", "Round")
                        .WithMany("Matches")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GuestTeam");

                    b.Navigation("HomeTeam");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Prediction", b =>
                {
                    b.HasOne("Pelicari.PredictScore.Data.Models.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pelicari.PredictScore.Data.Models.Score", "Score")
                        .WithOne()
                        .HasForeignKey("Pelicari.PredictScore.Data.Models.Prediction", "ScoreId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pelicari.PredictScore.Data.Models.User", "User")
                        .WithMany("Predictions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Score");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Round", b =>
                {
                    b.HasOne("Pelicari.PredictScore.Data.Models.Season", "Season")
                        .WithMany("Rounds")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Score", b =>
                {
                    b.HasOne("Pelicari.PredictScore.Data.Models.Match", "Match")
                        .WithOne("Score")
                        .HasForeignKey("Pelicari.PredictScore.Data.Models.Score", "MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Season", b =>
                {
                    b.HasOne("Pelicari.PredictScore.Data.Models.Sport", "Sport")
                        .WithMany("Seasons")
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Team", b =>
                {
                    b.HasOne("Pelicari.PredictScore.Data.Models.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Match", b =>
                {
                    b.Navigation("Score");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Round", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Season", b =>
                {
                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.Sport", b =>
                {
                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("Pelicari.PredictScore.Data.Models.User", b =>
                {
                    b.Navigation("Predictions");
                });
#pragma warning restore 612, 618
        }
    }
}
