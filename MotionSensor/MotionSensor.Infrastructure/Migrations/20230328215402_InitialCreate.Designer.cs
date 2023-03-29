﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotionSensor.Infrastructure;

#nullable disable

namespace MotionSensor.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230328215402_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("MotionSensor.Domain.Alert", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ParentMotionSensorId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentMotionSensorId");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("MotionSensor.Domain.RFIDMotionSensor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MotionSensors");
                });

            modelBuilder.Entity("MotionSensor.Domain.Alert", b =>
                {
                    b.HasOne("MotionSensor.Domain.RFIDMotionSensor", "ParentMotionSensor")
                        .WithMany("AlertsList")
                        .HasForeignKey("ParentMotionSensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentMotionSensor");
                });

            modelBuilder.Entity("MotionSensor.Domain.RFIDMotionSensor", b =>
                {
                    b.Navigation("AlertsList");
                });
#pragma warning restore 612, 618
        }
    }
}
