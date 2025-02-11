﻿using CustomerWebApi.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CustomerWebApi
{
    public class CustomerDbContext : DbContext
    {

        public CustomerDbContext(DbContextOptions<CustomerDbContext> dbContextoptions) : base(dbContextoptions)
        {

            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
