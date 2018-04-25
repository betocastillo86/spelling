﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Spelling.Data;
using System;

namespace Spelling.Data.Migrations
{
    [DbContext(typeof(SpellingContext))]
    [Migration("20180425213329_AddColumn_CreationDate_Table_BestScore")]
    partial class AddColumn_CreationDate_Table_BestScore
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Spelling.Domain.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CorrectAnswer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("GameId");

                    b.Property<int>("WordId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("WordId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Spelling.Domain.BestScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("GameCreationDate")
                        .HasColumnType("datetime");

                    b.Property<short>("GroupId");

                    b.Property<int>("Points");

                    b.Property<int>("Time");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("BestScores");
                });

            modelBuilder.Entity("Spelling.Domain.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<short>("GroupId");

                    b.Property<int>("Negatives");

                    b.Property<string>("OriginLanguage")
                        .HasMaxLength(50);

                    b.Property<int>("Positives");

                    b.Property<int>("Time");

                    b.Property<int>("Total");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Spelling.Domain.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("FullMessage")
                        .IsRequired();

                    b.Property<string>("IpAddress")
                        .HasColumnType("varchar(100)");

                    b.Property<short>("LogLevelId");

                    b.Property<string>("PageUrl")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ShortMessage")
                        .IsRequired();

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Spelling.Domain.SystemSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("SystemSettings");
                });

            modelBuilder.Entity("Spelling.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(150);

                    b.Property<string>("Password")
                        .HasMaxLength(50);

                    b.Property<string>("Salt")
                        .HasMaxLength(6);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Spelling.Domain.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("English")
                        .HasMaxLength(600);

                    b.Property<short>("GroupId");

                    b.Property<string>("Spanish")
                        .HasMaxLength(600);

                    b.HasKey("Id");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("Spelling.Domain.Answer", b =>
                {
                    b.HasOne("Spelling.Domain.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Spelling.Domain.Word", "Word")
                        .WithMany()
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Spelling.Domain.Game", b =>
                {
                    b.HasOne("Spelling.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Spelling.Domain.Log", b =>
                {
                    b.HasOne("Spelling.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Log_User_UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
