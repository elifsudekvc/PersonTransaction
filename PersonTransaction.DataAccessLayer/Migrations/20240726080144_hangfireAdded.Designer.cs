﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonTransaction.DataAccessLayer.Concrete;

#nullable disable

namespace PersonTransaction.DataAccessLayer.Migrations
{
    [DbContext(typeof(PersonTransactionContext))]
    [Migration("20240726080144_hangfireAdded")]
    partial class hangfireAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PersonTransaction.EntityLayer.Entities.ExpenseTransaction", b =>
                {
                    b.Property<int>("ExpenseTransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseTransactionID"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("ExpenseTransactionID");

                    b.HasIndex("PersonID");

                    b.ToTable("ExpenseTransactions");
                });

            modelBuilder.Entity("PersonTransaction.EntityLayer.Entities.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TCKimlik")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("PersonID");

                    b.HasIndex("TCKimlik")
                        .IsUnique();

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PersonTransaction.EntityLayer.Entities.ExpenseTransaction", b =>
                {
                    b.HasOne("PersonTransaction.EntityLayer.Entities.Person", "Person")
                        .WithMany("ExpenseTransactions")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PersonTransaction.EntityLayer.Entities.Person", b =>
                {
                    b.Navigation("ExpenseTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
