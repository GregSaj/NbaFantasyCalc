﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NbaFantasyCalc;

#nullable disable

namespace NbaFantasyCalc.Migrations
{
    [DbContext(typeof(ScoreContext))]
    [Migration("20230828152152_newOne4")]
    partial class newOne4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NbaFantasyCalc.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Team")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("NbaFantasyCalc.Entities.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AST")
                        .HasColumnType("int");

                    b.Property<int>("BLK")
                        .HasColumnType("int");

                    b.Property<int>("DRB")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FG")
                        .HasColumnType("int");

                    b.Property<int>("FGA")
                        .HasColumnType("int");

                    b.Property<double>("FGper")
                        .HasColumnType("float");

                    b.Property<int>("FT")
                        .HasColumnType("int");

                    b.Property<int>("FTA")
                        .HasColumnType("int");

                    b.Property<double>("FTper")
                        .HasColumnType("float");

                    b.Property<double>("GmSc")
                        .HasColumnType("float");

                    b.Property<string>("MP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ORB")
                        .HasColumnType("int");

                    b.Property<string>("Opp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PF")
                        .HasColumnType("int");

                    b.Property<int>("PTS")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Player_additional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rk")
                        .HasColumnType("int");

                    b.Property<int>("STL")
                        .HasColumnType("int");

                    b.Property<int>("TOV")
                        .HasColumnType("int");

                    b.Property<int>("TRB")
                        .HasColumnType("int");

                    b.Property<string>("Tm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("num3P")
                        .HasColumnType("int");

                    b.Property<int>("num3PA")
                        .HasColumnType("int");

                    b.Property<double>("num3Pper")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("NbaFantasyCalc.Entities.Score", b =>
                {
                    b.HasOne("NbaFantasyCalc.Entities.Player", "Player")
                        .WithMany("Scores")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("NbaFantasyCalc.Entities.Player", b =>
                {
                    b.Navigation("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}
