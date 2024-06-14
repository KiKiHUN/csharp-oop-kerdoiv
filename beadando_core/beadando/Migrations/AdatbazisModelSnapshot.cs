﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using beadando.Osztalyok.DBrelated;

#nullable disable

namespace beadando.Migrations
{
    [DbContext(typeof(Adatbazis))]
    partial class AdatbazisModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("beadando.Osztalyok.DBrelated.Kerdes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Kutatas")
                        .HasColumnType("int");

                    b.Property<string>("szoveg")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("Kutatas");

                    b.ToTable("kerdesek");
                });

            modelBuilder.Entity("beadando.Osztalyok.DBrelated.Kitoltesek", b =>
                {
                    b.Property<string>("email")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("KerdesID")
                        .HasColumnType("int");

                    b.Property<DateTime>("KitoltesIdo")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Kutatas")
                        .HasColumnType("int");

                    b.Property<int>("Valasz")
                        .HasColumnType("int");

                    b.Property<int>("kor")
                        .HasColumnType("int");

                    b.Property<string>("nem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("vegzettseg")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("email", "KerdesID");

                    b.HasIndex("KerdesID");

                    b.HasIndex("Kutatas");

                    b.HasIndex("Valasz");

                    b.ToTable("kitoltesek");
                });

            modelBuilder.Entity("beadando.Osztalyok.DBrelated.Kutatas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("aktivalva")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("elvartKitoltes")
                        .HasColumnType("int");

                    b.Property<int>("kapottKitoltes")
                        .HasColumnType("int");

                    b.Property<DateTime>("kezdet")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("nev")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("veg")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("kutatasok");
                });

            modelBuilder.Entity("beadando.Osztalyok.DBrelated.Valasz", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Kerdes")
                        .HasColumnType("int");

                    b.Property<string>("szoveg")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("Kerdes");

                    b.ToTable("valaszok");
                });

            modelBuilder.Entity("beadando.Osztalyok.DBrelated.Kerdes", b =>
                {
                    b.HasOne("beadando.Osztalyok.DBrelated.Kutatas", "kutatasID")
                        .WithMany()
                        .HasForeignKey("Kutatas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kutatasID");
                });

            modelBuilder.Entity("beadando.Osztalyok.DBrelated.Kitoltesek", b =>
                {
                    b.HasOne("beadando.Osztalyok.DBrelated.Kerdes", "kerdes")
                        .WithMany()
                        .HasForeignKey("KerdesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("beadando.Osztalyok.DBrelated.Kutatas", "kutatas")
                        .WithMany()
                        .HasForeignKey("Kutatas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("beadando.Osztalyok.DBrelated.Valasz", "valaszID")
                        .WithMany()
                        .HasForeignKey("Valasz")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kerdes");

                    b.Navigation("kutatas");

                    b.Navigation("valaszID");
                });

            modelBuilder.Entity("beadando.Osztalyok.DBrelated.Valasz", b =>
                {
                    b.HasOne("beadando.Osztalyok.DBrelated.Kerdes", "kerdesID")
                        .WithMany()
                        .HasForeignKey("Kerdes")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kerdesID");
                });
#pragma warning restore 612, 618
        }
    }
}