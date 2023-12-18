﻿// <auto-generated />
using CampSleepway_TeamGaJoL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CampSleepway_TeamGaJoL.Migrations
{
    [DbContext(typeof(CampSleepawayContext))]
    [Migration("20231218140548_serpatabord")]
    partial class serpatabord
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CampSleepway_TeamGaJoL.Cabin", b =>
                {
                    b.Property<int>("CabinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CabinId"));

                    b.HasKey("CabinId");

                    b.ToTable("Cabins");
                });

            modelBuilder.Entity("CampSleepway_TeamGaJoL.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("CampSleepway_TeamGaJoL.Camper", b =>
                {
                    b.HasBaseType("CampSleepway_TeamGaJoL.Person");

                    b.Property<int>("CamperId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("endDate")
                        .HasColumnType("int");

                    b.Property<int>("startDate")
                        .HasColumnType("int");

                    b.HasIndex("PersonId");

                    b.ToTable("Campers", (string)null);
                });

            modelBuilder.Entity("CampSleepway_TeamGaJoL.Councelor", b =>
                {
                    b.HasBaseType("CampSleepway_TeamGaJoL.Person");

                    b.Property<int>("CouncelorId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasIndex("PersonId");

                    b.ToTable("Councelors", (string)null);
                });

            modelBuilder.Entity("CampSleepway_TeamGaJoL.NextOfKin", b =>
                {
                    b.HasBaseType("CampSleepway_TeamGaJoL.Person");

                    b.Property<int>("NextOfKinId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasIndex("PersonId");

                    b.ToTable("NextOfKins", (string)null);
                });

            modelBuilder.Entity("CampSleepway_TeamGaJoL.Camper", b =>
                {
                    b.HasOne("CampSleepway_TeamGaJoL.Person", null)
                        .WithOne()
                        .HasForeignKey("CampSleepway_TeamGaJoL.Camper", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampSleepway_TeamGaJoL.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CampSleepway_TeamGaJoL.Councelor", b =>
                {
                    b.HasOne("CampSleepway_TeamGaJoL.Person", null)
                        .WithOne()
                        .HasForeignKey("CampSleepway_TeamGaJoL.Councelor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampSleepway_TeamGaJoL.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CampSleepway_TeamGaJoL.NextOfKin", b =>
                {
                    b.HasOne("CampSleepway_TeamGaJoL.Person", null)
                        .WithOne()
                        .HasForeignKey("CampSleepway_TeamGaJoL.NextOfKin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampSleepway_TeamGaJoL.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
