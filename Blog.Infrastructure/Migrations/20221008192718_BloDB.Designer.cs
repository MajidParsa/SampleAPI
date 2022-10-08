﻿// <auto-generated />
using System;
using Blog.Infrastructure.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blog.Infrastructure.Migrations
{
    [DbContext(typeof(BlogDBContext))]
    [Migration("20221008192718_BloDB")]
    partial class BloDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Blog.Domain.AggregatesModel.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatorId = 1,
                            Description = "Description 1",
                            Name = "Blog 1"
                        },
                        new
                        {
                            Id = 2,
                            CreatorId = 1,
                            Description = "Description 2",
                            Name = "Blog 2"
                        },
                        new
                        {
                            Id = 3,
                            CreatorId = 1,
                            Description = "Description 3",
                            Name = "Blog 3"
                        },
                        new
                        {
                            Id = 4,
                            CreatorId = 1,
                            Description = "Description 4",
                            Name = "Blog 4"
                        });
                });

            modelBuilder.Entity("Blog.Domain.AggregatesModel.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Comment 1",
                            CreateDate = new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(581),
                            CreatorId = 1,
                            PostId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "Comment 2",
                            CreateDate = new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(587),
                            CreatorId = 1,
                            PostId = 1
                        },
                        new
                        {
                            Id = 3,
                            Content = "Comment 3",
                            CreateDate = new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(590),
                            CreatorId = 1,
                            PostId = 1
                        },
                        new
                        {
                            Id = 4,
                            Content = "Comment 4",
                            CreateDate = new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(593),
                            CreatorId = 1,
                            PostId = 2
                        });
                });

            modelBuilder.Entity("Blog.Domain.AggregatesModel.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("CommentId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BlogId = 1,
                            Content = "Post 1",
                            CreateDate = new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(476)
                        },
                        new
                        {
                            Id = 2,
                            BlogId = 1,
                            Content = "Post 2",
                            CreateDate = new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(541)
                        },
                        new
                        {
                            Id = 3,
                            BlogId = 2,
                            Content = "Post 3",
                            CreateDate = new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(545)
                        },
                        new
                        {
                            Id = 4,
                            BlogId = 1,
                            Content = "Post 4",
                            CreateDate = new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(548)
                        });
                });

            modelBuilder.Entity("Blog.Domain.AggregatesModel.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=",
                            Username = "Majid"
                        });
                });

            modelBuilder.Entity("Blog.Domain.AggregatesModel.Blog", b =>
                {
                    b.HasOne("Blog.Domain.AggregatesModel.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Blog.Domain.AggregatesModel.Comment", b =>
                {
                    b.HasOne("Blog.Domain.AggregatesModel.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Blog.Domain.AggregatesModel.Post", b =>
                {
                    b.HasOne("Blog.Domain.AggregatesModel.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Blog.Domain.AggregatesModel.Comment", null)
                        .WithMany("Posts")
                        .HasForeignKey("CommentId");

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("Blog.Domain.AggregatesModel.Blog", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Blog.Domain.AggregatesModel.Comment", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
