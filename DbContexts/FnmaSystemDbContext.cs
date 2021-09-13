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

        public DbSet<Account> Accounts {get; set;}
        public DbSet<Property> Properties {get; set;}
        public DbSet<Loan> Loans {get; set;}
        public DbSet<LoanExitRate> LoanExitRates {get; set;}

        public FnmaSystemDbContext(DbContextOptions<FnmaSystemDbContext> options) : base(options) {    }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Account>().HasData(
                new Account() {
                    SellerNumber = 27170,
                    Name = "Cap One",
                },
                new Account() {
                    SellerNumber = 23224,
                    Name = "Berkadia",
                },
                new Account() {
                    SellerNumber = 21322,
                    Name = "Wells",
                },
                new Account() {
                    SellerNumber = 26805,
                    Name = "CBRE",
                },
                new Account() {
                    SellerNumber = 23378,
                    Name = "Bell",
                },
                new Account() {
                    SellerNumber = 21321,
                    Name = "W&D",
                },
                new Account() {
                    SellerNumber = 24343,
                    Name = "Arbor",
                }
            );
            modelBuilder.Entity<Property>().HasData (
                new Property() {
                    PropertyId = 123456,
                    Name = "Five Start Apartments",
                    Street = "2660 GLENN PL",
                    City = "JONESBORO",
                    State = "AZ", 
                    PostalCode = 72404,
                    LoanNumber = 145376
                },
                new Property() {
                    PropertyId = 123467,
                    Name = "Bel Air on 16th",
                    Street = "651 W 16TH ST",
                    City = "PLANO",
                    State = "TX", 
                    PostalCode = 75075,
                    LoanNumber = 144691
                },
                new Property() {
                    PropertyId = 123478,
                    Name = "Culter Vista",
                    Street = "10469 SW 216TH ST",
                    City = "MIAMI",
                    State = "FL", 
                    PostalCode = 33190,
                    LoanNumber = 141851
                },
                new Property() {
                    PropertyId = 123489,
                    Name = "Paseo Village",
                    Street = "1740 PASEO CT",
                    City = "RAMONA",
                    State = "CA", 
                    PostalCode = 92065,
                    LoanNumber = 146110
                },
                new Property() {
                    PropertyId = 123490,
                    Name = "Peppertree Place",
                    Street = "2500 BODDIE LN",
                    City = "GULF SHORES",
                    State = "AL", 
                    PostalCode = 36542,
                    LoanNumber = 143501
                },
                new Property() {
                    PropertyId = 123412,
                    Name = "Overture Rancho Santa Margarita",
                    Street = "30824 LA MIRANDA",
                    City = "RANCHO SANTA MARGARITA",
                    State = "CA", 
                    PostalCode = 92688,
                    LoanNumber = 138373
                },
                new Property() {
                    PropertyId = 123413,
                    Name = "Woodale and Seasons",
                    Street = "323 WOODALE DR",
                    City = "MONROE",
                    State = "LA", 
                    PostalCode = 71203,
                    LoanNumber = 144267
                }
            ); 
           modelBuilder.Entity<Loan>().HasData (
               new Loan() {
                   LoanNumber = 145376,
                   LoanAmount = 19599000,
                   GreenFinanceType = "No",
                   SubmittedDate = new DateTimeOffset(new DateTime(2020, 09, 30)),
                   SellerNumber = 27170
               },
                new Loan() {
                   LoanNumber = 144691,
                   LoanAmount = 25000000,
                   GreenFinanceType = "Yes",
                   SubmittedDate = new DateTimeOffset(new DateTime(2019, 11, 21)),
                   SellerNumber = 23224
               },
                new Loan() {
                   LoanNumber = 141851,
                   LoanAmount = 3000000,
                   GreenFinanceType = "Yes",
                   SubmittedDate = new DateTimeOffset(new DateTime(2011, 06, 07)),
                   SellerNumber = 21322
               },
                new Loan() {
                   LoanNumber = 146110,
                   LoanAmount = 1500000,
                   GreenFinanceType = "Yes",
                   SubmittedDate = new DateTimeOffset(new DateTime(2014, 12, 24)),
                   SellerNumber = 26805
               },
                new Loan() {
                   LoanNumber = 143501,
                   LoanAmount = 6467000,
                   GreenFinanceType = "No",
                   SubmittedDate = new DateTimeOffset(new DateTime(2020, 10, 02)),
                   SellerNumber = 23378
               },
                new Loan() {
                   LoanNumber = 138373,
                   LoanAmount = 12500000,
                   GreenFinanceType = "No",
                   SubmittedDate = new DateTimeOffset(new DateTime(2020, 04, 13)),
                   SellerNumber = 21321
               },
                new Loan() {
                   LoanNumber = 144267,
                   LoanAmount = 7500000,
                   GreenFinanceType = "Yes",
                   SubmittedDate = new DateTimeOffset(new DateTime(2020, 12, 03)),
                   SellerNumber = 24343
               }
           );
           modelBuilder.Entity<LoanExitRate>().HasData(
                new LoanExitRate() {
                    MsaCode = 38060,
                    OneYrProjectedGrowthRate = 4.268,
                    TwoYrProjectedGrowthRate = 5.268, 
                    ThirdYrProjectedGrowthRate = 6.268, 
                    ForthYrProjectedGrowthRate = 7.268,
                    FifthYrProjectedGrowthRate = 8.268
                },
                new LoanExitRate() {
                    MsaCode = 12420,
                    OneYrProjectedGrowthRate = 2.851,
                    TwoYrProjectedGrowthRate = 3.851, 
                    ThirdYrProjectedGrowthRate = 4.851, 
                    ForthYrProjectedGrowthRate = 5.851,
                    FifthYrProjectedGrowthRate = 6.851
                },
                new LoanExitRate() {
                    MsaCode = 37460,
                    OneYrProjectedGrowthRate = 3.65,
                    TwoYrProjectedGrowthRate = 4.65, 
                    ThirdYrProjectedGrowthRate = 5.65, 
                    ForthYrProjectedGrowthRate = 6.65,
                    FifthYrProjectedGrowthRate = 7.65
                },
                new LoanExitRate() {
                    MsaCode = 18860,
                    OneYrProjectedGrowthRate = 6.85,
                    TwoYrProjectedGrowthRate = 7.85, 
                    ThirdYrProjectedGrowthRate = 8.85, 
                    ForthYrProjectedGrowthRate = 9.85,
                    FifthYrProjectedGrowthRate = 10.85
                },
                new LoanExitRate() {
                    MsaCode = 19300,
                    OneYrProjectedGrowthRate = 1.12,
                    TwoYrProjectedGrowthRate = 1.99, 
                    ThirdYrProjectedGrowthRate = 2.12, 
                    ForthYrProjectedGrowthRate = 3.12,
                    FifthYrProjectedGrowthRate = 4.12
                },
                new LoanExitRate() {
                    MsaCode = 18860,
                    OneYrProjectedGrowthRate = 6.85,
                    TwoYrProjectedGrowthRate = 7.85, 
                    ThirdYrProjectedGrowthRate = 8.85, 
                    ForthYrProjectedGrowthRate = 9.85,
                    FifthYrProjectedGrowthRate = 10.85
                },
                new LoanExitRate() {
                    MsaCode = 35380,
                    OneYrProjectedGrowthRate = 3.35,
                    TwoYrProjectedGrowthRate = 4.35, 
                    ThirdYrProjectedGrowthRate = 5.35, 
                    ForthYrProjectedGrowthRate = 6.35,
                    FifthYrProjectedGrowthRate = 7.35
                }

           );
        }
    }
}