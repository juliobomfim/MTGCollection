﻿// <auto-generated />
using System;
using MTGCollection.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MTGCollection.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20210822183545_Initial_Migration")]
    partial class Initial_Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MTGCollection.Models.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Collection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lore")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Loyalty")
                        .HasColumnType("int");

                    b.Property<string>("ManaCost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Power")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Side")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SubTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Toughness")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("SubTypeId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("MTGCollection.Models.CardSubType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CardSubTypes");
                });

            modelBuilder.Entity("MTGCollection.Models.Card", b =>
                {
                    b.HasOne("MTGCollection.Models.Card", null)
                        .WithMany("OtherFaceCards")
                        .HasForeignKey("CardId");

                    b.HasOne("MTGCollection.Models.CardSubType", "SubType")
                        .WithMany()
                        .HasForeignKey("SubTypeId");

                    b.Navigation("SubType");
                });

            modelBuilder.Entity("MTGCollection.Models.Card", b =>
                {
                    b.Navigation("OtherFaceCards");
                });
#pragma warning restore 612, 618
        }
    }
}
