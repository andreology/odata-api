using odata_poc.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace odata_poc.DbContexts {
    public class FnmaSystemDbContext : DbContext {
        public DbSet<FnmaSystem> Systems {get; set;}
        public DbSet<SystemInterface> Interface {get; set;}

        public DbSet<Account> Accounts {get; set;}
        public DbSet<Property> Properties {get; set;}

        public FnmaSystemDbContext(DbContextOptions<FnmaSystemDbContext> options) : base(options) {    }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Account>().HasData(
                new Account() {
                    AccountId = 7,
                    Name = "Bill Nye",
                    LoanNumber = 236467
                },
                new Account() {
                    AccountId = 1,
                    Name = "Phill Mcdonald",
                    LoanNumber = 442346
                },
                new Account() {
                    AccountId = 2,
                    Name = "Brian James",
                    LoanNumber = 675686
                },
                new Account() {
                    AccountId = 3,
                    Name = "Ryan Arol",
                    LoanNumber = 345747
                },
                new Account() {
                    AccountId = 4,
                    Name = "Jose East",
                    LoanNumber = 648799
                },
                new Account() {
                    AccountId = 5,
                    Name = "Drake West",
                    LoanNumber = 467475
                },
                new Account() {
                    AccountId = 6,
                    Name = "Ed Sharee",
                    LoanNumber = 123497
                }
            );
            modelBuilder.Entity<Property>().HasData (
                new Property() {
                    PropertyId = 7,
                    Street = "Orange Ave",
                    City = "Signal Hill",
                    Zip = 92010,
                    Price = 3000000,
                    LoanNumber = 123497
                },
                new Property() {
                    PropertyId = 1,
                    Street = "Atlantic",
                    City = "Long Beach",
                    Zip = 20192,
                    Price = 390000,
                    LoanNumber = 467475
                },
                new Property() {
                    PropertyId = 2,
                    Street = "Lincohn Blvd",
                    City = "Aneheim",
                    Zip = 90293,
                    Price = 1000000,
                    LoanNumber = 648799
                },
                new Property() {
                    PropertyId = 3,
                    Street = "Knott Ave",
                    City = "Cerritos",
                    Zip = 92912,
                    Price = 800281,
                    LoanNumber = 345747
                },
                new Property() {
                    PropertyId = 4,
                    Street = "Artesia Blvd",
                    City = "Bellflower",
                    Zip = 91920,
                    Price = 690000,
                    LoanNumber = 675686
                },
                new Property() {
                    PropertyId = 5,
                    Street = "Greenleaf Blvd",
                    City = "Compton",
                    Zip = 883023,
                    Price = 90000,
                    LoanNumber = 442346
                },
                new Property() {
                    PropertyId = 6,
                    Street = "Somerset Blvd",
                    City = "Paramount",
                    Zip = 90280,
                    Price = 100201,
                    LoanNumber = 236467
                }
            );
            modelBuilder.Entity<FnmaSystem>().HasData (
                new FnmaSystem() {
                    FnmaSystemId = 1, 
                    OwnerFirstName = "bill", 
                    OwnerLastName = "Mclearn",
                    DateCreated = new DateTimeOffset(new DateTime(2021, 4, 2))
                },
                new FnmaSystem() {
                    FnmaSystemId = 2, 
                    OwnerFirstName = "jill", 
                    OwnerLastName = "Smith",
                    DateCreated = new DateTimeOffset(new DateTime(2020, 4, 6))
                },
                new FnmaSystem() {
                    FnmaSystemId = 3, 
                    OwnerFirstName = "Jose", 
                    OwnerLastName = "Mcdonald",
                    DateCreated = new DateTimeOffset(new DateTime(2001, 8, 5))
                },
                new FnmaSystem() {
                    FnmaSystemId = 4, 
                    OwnerFirstName = "Tae", 
                    OwnerLastName = "Richards",
                    DateCreated = new DateTimeOffset(new DateTime(2016, 2, 9))
                },
                new FnmaSystem() {
                    FnmaSystemId = 5, 
                    OwnerFirstName = "Ryan", 
                    OwnerLastName = "Lia",
                    DateCreated = new DateTimeOffset(new DateTime(2005, 8, 2))
                }
            );

             modelBuilder.Entity<SystemInterface>().HasData (
                 new SystemInterface() {
                     SystemInterfaceId = 1,
                     InterfaceName = "Credit Checker",
                     FnmaSystemId = 1
                 },
                 new SystemInterface() {
                     SystemInterfaceId = 2,
                     InterfaceName = "CFOC Center",
                     FnmaSystemId = 2
                 },
                 new SystemInterface() {
                     SystemInterfaceId = 3,
                     InterfaceName = "Discolsure Processor",
                     FnmaSystemId = 3
                 },
                 new SystemInterface() {
                     SystemInterfaceId = 4,
                     InterfaceName = "DUC Loan Processor",
                     FnmaSystemId = 4
                 },
                 new SystemInterface() {
                     SystemInterfaceId = 5,
                     InterfaceName = "Aquisition Monitor",
                     FnmaSystemId = 5
                 }
             );
        }
    }
}