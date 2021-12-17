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
    [Migration("20211217135628_UpdateBase17.12.21")]
    partial class UpdateBase171221
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MMS.ArmyCorp", b =>
                {
                    b.Property<int>("CorpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommanderId")
                        .HasColumnType("int");

                    b.Property<int>("defeates")
                        .HasColumnType("int");

                    b.Property<int?>("stateID_STATE")
                        .HasColumnType("int");

                    b.Property<int>("victories")
                        .HasColumnType("int");

                    b.HasKey("CorpId");

                    b.HasIndex("CommanderId");

                    b.HasIndex("stateID_STATE");

                    b.ToTable("Corps");
                });

            modelBuilder.Entity("MMS.Conflict", b =>
                {
                    b.Property<int>("id_conflict")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("start_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.HasKey("id_conflict");

                    b.ToTable("Conflicts");
                });

            modelBuilder.Entity("MMS.DAL.Entities.Divizion", b =>
                {
                    b.Property<int>("DivizionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CorpId")
                        .HasColumnType("int");

                    b.Property<string>("DivizionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GeneralID")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DivizionID");

                    b.HasIndex("CorpId");

                    b.ToTable("Divizions");
                });

            modelBuilder.Entity("MMS.DAL.Entities.Mission", b =>
                {
                    b.Property<int>("id_mission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("end_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("start_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.HasKey("id_mission");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("MMS.Garrison", b =>
                {
                    b.Property<int>("id_garrison")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MilitaryBaseIdBase")
                        .HasColumnType("int");

                    b.Property<int>("available_rooms")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("start_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.HasKey("id_garrison");

                    b.HasIndex("MilitaryBaseIdBase");

                    b.ToTable("Garrisons");
                });

            modelBuilder.Entity("MMS.Leader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("First_Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Last_Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("birth_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("sex")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Leaders");
                });

            modelBuilder.Entity("MMS.Location", b =>
                {
                    b.Property<int>("id_location")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("province")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id_location");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("MMS.MilitaryBase", b =>
                {
                    b.Property<int>("IdBase")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BaseName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FoundDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<int?>("locationid_location")
                        .HasColumnType("int");

                    b.Property<int?>("stateID_STATE")
                        .HasColumnType("int");

                    b.HasKey("IdBase");

                    b.HasIndex("locationid_location");

                    b.HasIndex("stateID_STATE");

                    b.ToTable("Bases");
                });

            modelBuilder.Entity("MMS.PersonalMilitary", b =>
                {
                    b.Property<int>("ID_PERS")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DivizionID")
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

                    b.Property<int?>("mBaseIdBase")
                        .HasColumnType("int");

                    b.Property<float>("salary")
                        .HasMaxLength(20)
                        .HasPrecision(2)
                        .HasColumnType("float(2)");

                    b.Property<string>("sex")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("ID_PERS");

                    b.HasIndex("DivizionID");

                    b.HasIndex("mBaseIdBase");

                    b.ToTable("Militaries");
                });

            modelBuilder.Entity("MMS.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SkillDescription")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("SkillName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("MMS.State", b =>
                {
                    b.Property<int>("ID_STATE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_leader")
                        .HasColumnType("int");

                    b.Property<string>("legislator")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("population")
                        .HasColumnType("int");

                    b.Property<int>("surface")
                        .HasColumnType("int");

                    b.HasKey("ID_STATE");

                    b.ToTable("States");
                });

            modelBuilder.Entity("MMS.ArmyCorp", b =>
                {
                    b.HasOne("MMS.PersonalMilitary", "Commander")
                        .WithMany()
                        .HasForeignKey("CommanderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MMS.State", "state")
                        .WithMany("corps")
                        .HasForeignKey("stateID_STATE");

                    b.Navigation("Commander");

                    b.Navigation("state");
                });

            modelBuilder.Entity("MMS.DAL.Entities.Divizion", b =>
                {
                    b.HasOne("MMS.ArmyCorp", "Corp")
                        .WithMany("divizions")
                        .HasForeignKey("CorpId");

                    b.Navigation("Corp");
                });

            modelBuilder.Entity("MMS.Garrison", b =>
                {
                    b.HasOne("MMS.MilitaryBase", "MilitaryBase")
                        .WithMany("Garrison")
                        .HasForeignKey("MilitaryBaseIdBase");

                    b.Navigation("MilitaryBase");
                });

            modelBuilder.Entity("MMS.MilitaryBase", b =>
                {
                    b.HasOne("MMS.Location", "location")
                        .WithMany("bases")
                        .HasForeignKey("locationid_location");

                    b.HasOne("MMS.State", "state")
                        .WithMany("bases")
                        .HasForeignKey("stateID_STATE");

                    b.Navigation("location");

                    b.Navigation("state");
                });

            modelBuilder.Entity("MMS.PersonalMilitary", b =>
                {
                    b.HasOne("MMS.DAL.Entities.Divizion", "divizion")
                        .WithMany("personalMilitaries")
                        .HasForeignKey("DivizionID");

                    b.HasOne("MMS.MilitaryBase", "mBase")
                        .WithMany("personalMilitaries")
                        .HasForeignKey("mBaseIdBase");

                    b.Navigation("divizion");

                    b.Navigation("mBase");
                });

            modelBuilder.Entity("MMS.ArmyCorp", b =>
                {
                    b.Navigation("divizions");
                });

            modelBuilder.Entity("MMS.DAL.Entities.Divizion", b =>
                {
                    b.Navigation("personalMilitaries");
                });

            modelBuilder.Entity("MMS.Location", b =>
                {
                    b.Navigation("bases");
                });

            modelBuilder.Entity("MMS.MilitaryBase", b =>
                {
                    b.Navigation("Garrison");

                    b.Navigation("personalMilitaries");
                });

            modelBuilder.Entity("MMS.State", b =>
                {
                    b.Navigation("bases");

                    b.Navigation("corps");
                });
#pragma warning restore 612, 618
        }
    }
}
