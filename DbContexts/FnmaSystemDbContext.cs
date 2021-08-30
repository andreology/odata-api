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

        public FnmaSystemDbContext(DbContextOptions<FnmaSystemDbContext> options) : base(options) {    }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
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