﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Patronage2018.Persistence;

namespace Patronage2018.Persistence.Migrations
{
    [DbContext(typeof(PatronageDbContext))]
    partial class PatronageDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Patronage2018.Domain.Entities.Calendar", b =>
                {
                    b.Property<int>("CalendarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CalendarID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("From");

                    b.Property<int>("RoomId");

                    b.Property<DateTime>("To");

                    b.HasKey("CalendarId");

                    b.HasIndex("RoomId");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("Patronage2018.Domain.Entities.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RoomID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("RoomId");

                    b.HasIndex("RoomName")
                        .IsUnique();

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Patronage2018.Domain.Entities.Calendar", b =>
                {
                    b.HasOne("Patronage2018.Domain.Entities.Room", "Room")
                        .WithMany("Calendars")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}