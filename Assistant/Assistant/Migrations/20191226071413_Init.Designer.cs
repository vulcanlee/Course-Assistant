﻿// <auto-generated />
using System;
using Assistant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assistant.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20191226071413_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("Assistant.Models.CourseUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("Roles")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Salt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CourseUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
