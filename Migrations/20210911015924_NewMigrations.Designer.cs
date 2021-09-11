﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using odata_poc.DbContexts;

namespace odata_poc.Migrations
{
    [DbContext(typeof(FnmaSystemDbContext))]
    [Migration("20210911015924_NewMigrations")]
    partial class NewMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("odata_poc.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("LoanNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 7,
                            LoanNumber = 236467,
                            Name = "Bill Nye"
                        },
                        new
                        {
                            AccountId = 1,
                            LoanNumber = 442346,
                            Name = "Phill Mcdonald"
                        },
                        new
                        {
                            AccountId = 2,
                            LoanNumber = 675686,
                            Name = "Brian James"
                        },
                        new
                        {
                            AccountId = 3,
                            LoanNumber = 345747,
                            Name = "Ryan Arol"
                        },
                        new
                        {
                            AccountId = 4,
                            LoanNumber = 648799,
                            Name = "Jose East"
                        },
                        new
                        {
                            AccountId = 5,
                            LoanNumber = 467475,
                            Name = "Drake West"
                        },
                        new
                        {
                            AccountId = 6,
                            LoanNumber = 123497,
                            Name = "Ed Sharee"
                        });
                });

            modelBuilder.Entity("odata_poc.Entities.FnmaSystem", b =>
                {
                    b.Property<int>("FnmaSystemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OwnerFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("OwnerLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("FnmaSystemId");

                    b.ToTable("Systems");

                    b.HasData(
                        new
                        {
                            FnmaSystemId = 1,
                            DateCreated = new DateTimeOffset(new DateTime(2021, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)),
                            OwnerFirstName = "bill",
                            OwnerLastName = "Mclearn"
                        },
                        new
                        {
                            FnmaSystemId = 2,
                            DateCreated = new DateTimeOffset(new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)),
                            OwnerFirstName = "jill",
                            OwnerLastName = "Smith"
                        },
                        new
                        {
                            FnmaSystemId = 3,
                            DateCreated = new DateTimeOffset(new DateTime(2001, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)),
                            OwnerFirstName = "Jose",
                            OwnerLastName = "Mcdonald"
                        },
                        new
                        {
                            FnmaSystemId = 4,
                            DateCreated = new DateTimeOffset(new DateTime(2016, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)),
                            OwnerFirstName = "Tae",
                            OwnerLastName = "Richards"
                        },
                        new
                        {
                            FnmaSystemId = 5,
                            DateCreated = new DateTimeOffset(new DateTime(2005, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)),
                            OwnerFirstName = "Ryan",
                            OwnerLastName = "Lia"
                        });
                });

            modelBuilder.Entity("odata_poc.Entities.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("LoanNumber")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("PropertyId");

                    b.ToTable("Properties");

                    b.HasData(
                        new
                        {
                            PropertyId = 7,
                            City = "Signal Hill",
                            LoanNumber = 123497,
                            Price = 3000000,
                            Street = "Orange Ave",
                            Zip = 92010
                        },
                        new
                        {
                            PropertyId = 1,
                            City = "Long Beach",
                            LoanNumber = 467475,
                            Price = 390000,
                            Street = "Atlantic",
                            Zip = 20192
                        },
                        new
                        {
                            PropertyId = 2,
                            City = "Aneheim",
                            LoanNumber = 648799,
                            Price = 1000000,
                            Street = "Lincohn Blvd",
                            Zip = 90293
                        },
                        new
                        {
                            PropertyId = 3,
                            City = "Cerritos",
                            LoanNumber = 345747,
                            Price = 800281,
                            Street = "Knott Ave",
                            Zip = 92912
                        },
                        new
                        {
                            PropertyId = 4,
                            City = "Bellflower",
                            LoanNumber = 675686,
                            Price = 690000,
                            Street = "Artesia Blvd",
                            Zip = 91920
                        },
                        new
                        {
                            PropertyId = 5,
                            City = "Compton",
                            LoanNumber = 442346,
                            Price = 90000,
                            Street = "Greenleaf Blvd",
                            Zip = 883023
                        },
                        new
                        {
                            PropertyId = 6,
                            City = "Paramount",
                            LoanNumber = 236467,
                            Price = 100201,
                            Street = "Somerset Blvd",
                            Zip = 90280
                        });
                });

            modelBuilder.Entity("odata_poc.Entities.SystemInterface", b =>
                {
                    b.Property<int>("SystemInterfaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FnmaSystemId")
                        .HasColumnType("int");

                    b.Property<string>("InterfaceName")
                        .IsRequired()
                        .HasMaxLength(145)
                        .HasColumnType("varchar(145)");

                    b.HasKey("SystemInterfaceId");

                    b.HasIndex("FnmaSystemId");

                    b.ToTable("Interface");

                    b.HasData(
                        new
                        {
                            SystemInterfaceId = 1,
                            FnmaSystemId = 1,
                            InterfaceName = "Credit Checker"
                        },
                        new
                        {
                            SystemInterfaceId = 2,
                            FnmaSystemId = 2,
                            InterfaceName = "CFOC Center"
                        },
                        new
                        {
                            SystemInterfaceId = 3,
                            FnmaSystemId = 3,
                            InterfaceName = "Discolsure Processor"
                        },
                        new
                        {
                            SystemInterfaceId = 4,
                            FnmaSystemId = 4,
                            InterfaceName = "DUC Loan Processor"
                        },
                        new
                        {
                            SystemInterfaceId = 5,
                            FnmaSystemId = 5,
                            InterfaceName = "Aquisition Monitor"
                        });
                });

            modelBuilder.Entity("odata_poc.Entities.SystemInterface", b =>
                {
                    b.HasOne("odata_poc.Entities.FnmaSystem", "FnmaSystem")
                        .WithMany("SystemInterface")
                        .HasForeignKey("FnmaSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FnmaSystem");
                });

            modelBuilder.Entity("odata_poc.Entities.FnmaSystem", b =>
                {
                    b.Navigation("SystemInterface");
                });
#pragma warning restore 612, 618
        }
    }
}
