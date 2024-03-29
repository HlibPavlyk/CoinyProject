﻿// <auto-generated />
using System;
using CoinyProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoinyProject.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240229014411_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.AlbumElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessibilityId")
                        .HasColumnType("int");

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccessibilityId");

                    b.HasIndex("AlbumId");

                    b.ToTable("AlbumElements");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.AlbumElementAccessibility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AlbumElementAccessibilities");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LotId");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.Discussion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DiscussionTopicId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RootQuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiscussionTopicId");

                    b.HasIndex("RootQuestionId");

                    b.ToTable("Discussions");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.DiscussionMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DiscussionId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DiscussionId");

                    b.HasIndex("UserId");

                    b.ToTable("DiscussionMessages");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.DiscussionTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DiscussionTopics");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.Album", b =>
                {
                    b.HasOne("CoinyProject.Core.Domain.Entities.User", null)
                        .WithMany("Albums")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.AlbumElement", b =>
                {
                    b.HasOne("CoinyProject.Core.Domain.Entities.AlbumElementAccessibility", "Accessibility")
                        .WithMany()
                        .HasForeignKey("AccessibilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoinyProject.Core.Domain.Entities.Album", null)
                        .WithMany("Elements")
                        .HasForeignKey("AlbumId");

                    b.Navigation("Accessibility");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.Auction", b =>
                {
                    b.HasOne("CoinyProject.Core.Domain.Entities.AlbumElement", "Lot")
                        .WithMany()
                        .HasForeignKey("LotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lot");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.Discussion", b =>
                {
                    b.HasOne("CoinyProject.Core.Domain.Entities.DiscussionTopic", "DiscussionTopic")
                        .WithMany()
                        .HasForeignKey("DiscussionTopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoinyProject.Core.Domain.Entities.DiscussionMessage", "RootQuestion")
                        .WithMany()
                        .HasForeignKey("RootQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiscussionTopic");

                    b.Navigation("RootQuestion");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.DiscussionMessage", b =>
                {
                    b.HasOne("CoinyProject.Core.Domain.Entities.Discussion", null)
                        .WithMany("Messages")
                        .HasForeignKey("DiscussionId");

                    b.HasOne("CoinyProject.Core.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.User", b =>
                {
                    b.HasOne("CoinyProject.Core.Domain.Entities.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.Album", b =>
                {
                    b.Navigation("Elements");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.Discussion", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("CoinyProject.Core.Domain.Entities.User", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}
