﻿// <auto-generated />
using ASPNETCoreWebApplicationMVCTemplate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASPNETCoreWebApplicationMVCTemplate.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201222152514_AlterStudentsSeedData")]
    partial class AlterStudentsSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ASPNETCoreWebApplicationMVCTemplate.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Branch")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Section")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            Branch = 1,
                            Email = "lisa@yahoo.com",
                            Gender = 0,
                            Name = "Lisa Simpson"
                        },
                        new
                        {
                            StudentId = 2,
                            Branch = 1,
                            Email = "homer@yahoo.com",
                            Gender = 0,
                            Name = "Homer Simpson"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}