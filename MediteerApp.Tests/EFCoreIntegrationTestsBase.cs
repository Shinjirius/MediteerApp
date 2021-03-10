using MediteerApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace MediteerApp.Tests
{
    public abstract class EFCoreIntegrationTestsBase
    {
        protected TransactionScope TransactionScope;

        public static string GetConnectionString()
        {
            var running_in_pipeline = Environment.GetEnvironmentVariable("RUNNING_IN_PIPELINE") == "True";

            return running_in_pipeline || Environment.OSVersion.Platform == PlatformID.Unix ?
                 $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MediteerTest;Integrated Security=True" :
                 $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MediteerTest;Integrated Security=True";
        }
        public static MediteerContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder()
              .UseSqlServer(GetConnectionString())
              .Options;

            var dbContext = new MediteerContext(options);
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
        public static void DisposeDbContext(DbContext context)
        {
            context.Database?.EnsureDeleted();
        }

        public virtual void TestInitialize()
        {
            TransactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        }

        public virtual void TestCleanup()
        {
            TransactionScope.Dispose();
        }

    }
}
