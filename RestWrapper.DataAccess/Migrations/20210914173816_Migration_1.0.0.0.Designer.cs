﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using RestWrapper.DataAccess.Concrete.EntityFramework.Contexts;

namespace RestWrapper.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210914173816_Migration_1.0.0.0")]
    partial class Migration_1000
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestWrapper.Entities.Concrete.CallDAO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.ToTable("Calls");
                });

            modelBuilder.Entity("RestWrapper.Entities.Concrete.RequestDAO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CallId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ParentId");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("clob");

                    b.HasKey("Id");

                    b.HasIndex("CallId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("RestWrapper.Entities.Concrete.RequestDAO", b =>
                {
                    b.HasOne("RestWrapper.Entities.Concrete.CallDAO", "Call")
                        .WithMany("Calls")
                        .HasForeignKey("CallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Call");
                });

            modelBuilder.Entity("RestWrapper.Entities.Concrete.CallDAO", b =>
                {
                    b.Navigation("Calls");
                });
#pragma warning restore 612, 618
        }
    }
}
