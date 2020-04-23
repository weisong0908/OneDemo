﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OneDemo.EfCore.Persistence;

namespace OneDemo.EfCore.Migrations.Blogging
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20200421055759_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OneDemo.EfCore.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "personal blog"
                        },
                        new
                        {
                            Id = 2,
                            Title = "work blog"
                        });
                });

            modelBuilder.Entity("OneDemo.EfCore.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BlogId = 1,
                            Title = "personal post 1"
                        },
                        new
                        {
                            Id = 2,
                            BlogId = 1,
                            Title = "personal post 2"
                        },
                        new
                        {
                            Id = 3,
                            BlogId = 1,
                            Title = "personal post 3"
                        },
                        new
                        {
                            Id = 4,
                            BlogId = 2,
                            Title = "work post 1"
                        },
                        new
                        {
                            Id = 5,
                            BlogId = 2,
                            Title = "work post 2"
                        },
                        new
                        {
                            Id = 6,
                            BlogId = 2,
                            Title = "work post 3"
                        });
                });

            modelBuilder.Entity("OneDemo.EfCore.Models.Post", b =>
                {
                    b.HasOne("OneDemo.EfCore.Models.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}