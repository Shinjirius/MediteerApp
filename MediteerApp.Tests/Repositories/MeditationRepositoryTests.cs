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
using MediteerApp.Data.Models;
using System.Transactions;
using MediteerApp.Data.Context;

namespace MediteerApp.Tests.Repositories
{
    [TestClass]
    public class MeditationRepositoryTests : EFCoreIntegrationTestsBase
    {
        private MeditationRepository _sut;
        private Collection _defaultCollection;
        private static MediteerContext _dbContext;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _dbContext = CreateDbContext();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            DisposeDbContext(_dbContext);
        }

        [TestInitialize]
        public override void TestInitialize() {
            base.TestInitialize(); 
            _sut = new MeditationRepository(_dbContext);
            
            // Default data
            _defaultCollection = new Collection() { Id = Guid.NewGuid(), Name = "" };
            _dbContext.SaveChanges();
            _dbContext.Add(_defaultCollection);
            _dbContext.SaveChanges();

        }

        [TestCleanup]
        public override void TestCleanup() => base.TestCleanup();

        [TestMethod]
        public void GetAll_UnknownCollection_ShouldReturnNull()
        {
            // arrange
            var collectionId = Guid.NewGuid();

            // act
            var result = _sut.GetAll(collectionId);

            // assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void GetAll_KnownNonEmptyCollection_ShouldReturnNonEmptyList()
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            { 
                // arrange
                var meditations = new Meditation[]{ 
                    new Meditation
                    {
                        Id = Guid.NewGuid(),
                        Name = nameof(Add_ToExistingCollection_ShouldAdd),
                        CollectionId = _defaultCollection.Id
                    },
                    new Meditation
                    {
                        Id = Guid.NewGuid(),
                        Name = nameof(Add_ToExistingCollection_ShouldAdd),
                        CollectionId = _defaultCollection.Id
                    } 
                };
                _dbContext.AddRange(meditations);
                _dbContext.SaveChanges();

                // act
                var result = _sut.GetAll(_defaultCollection.Id);

                // assert
                result.Should().BeEquivalentTo(meditations, options => options.Excluding(e => e.Collection));
            }
        }

        [TestMethod]
        public void GetAll_KnownEmptyCollection_ShouldReturnEmptyList()
        {
            // arrange
            var collectionId = Guid.NewGuid();

            // act
            var result = _sut.GetAll(collectionId);

            // assert
            result.Should().BeNull();
        }


        [TestMethod]
        public void Add_ToExistingCollection_ShouldAdd()
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                // arrange
                var expected = new Meditation
                {
                    Id = Guid.NewGuid(),
                    Name = nameof(Add_ToExistingCollection_ShouldAdd),
                    CollectionId = _defaultCollection.Id
                };

                // act
                _sut.Add(expected.Id, expected.Name, expected.CollectionId);

                // assert
                var result = _dbContext.Meditations.FirstOrDefault(m => m.Id == expected.Id);
                result.Should().BeEquivalentTo(expected, options => options.Excluding(e => e.Collection));
            }
        }

        [TestMethod]
        public void Add_ToNonExistingCollection_ShouldThrowException()
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                // arrange
                var expected = new Meditation
                {
                    Id = Guid.NewGuid(),
                    Name = nameof(Add_ToExistingCollection_ShouldAdd),
                    CollectionId = Guid.NewGuid()
                };

                // act
                _sut.Add(expected.Id, expected.Name, expected.CollectionId);

                // assert
                var result = _dbContext.Meditations.FirstOrDefault(m => m.Id == expected.Id);
                result.Should().BeNull();
            }
        }

    }
}
