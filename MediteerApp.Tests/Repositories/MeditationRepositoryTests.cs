using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediteerApp.Data.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MediteerApp.Tests.Repositories
{
    [TestClass]
    public class MeditationRepositoryTests
    {
        private static MeditationRepository _sut;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            DbContextOptions options = new DbContextOptionsBuilder()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Mediteer;Integrated Security=True")
                .Options;
            var dbContext = new Data.Context.MediteerContext(options);
            var count = dbContext.Collections.Count();
            dbContext.Collections.Add(new Data.Models.Collection { Id = Guid.NewGuid(), Name = "DDDD" });
            dbContext.SaveChanges();
            _sut = new MeditationRepository(dbContext);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetAll_UnknownCollection_ShouldReturnNullReferenceException()
        {
            // arrange
            var collectionId = Guid.Parse("74E1ABD2-9143-41B2-8704-A4C77B6B6300");

            // act
            var result = _sut.GetAll(collectionId);

            // assert
            Assert.Fail();
        }
    }
}
