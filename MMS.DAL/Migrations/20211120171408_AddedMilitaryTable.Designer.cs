﻿// <auto-generated />
using System;
using MMS.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MMS.DAL.Migrations
{
    [DbContext(typeof(DB_Context))]
    [Migration("20211120171408_AddedMilitaryTable")]
    partial class AddedMilitaryTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MMS.PersonalMilitary", b =>
                {
                    b.Property<int>("ID_PERS")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ID_BASE")
                        .HasColumnType("int");

                    b.Property<int>("ID_DIVIZION")
                        .HasColumnType("int");

                    b.Property<string>("cnp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstname")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("hire_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("lastname")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("salary")
                        .HasMaxLength(20)
                        .HasPrecision(2)
                        .HasColumnType("float(2)");

                    b.Property<string>("sex")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("ID_PERS");

                    b.ToTable("Militaries");
                });
#pragma warning restore 612, 618
        }
    }
}
