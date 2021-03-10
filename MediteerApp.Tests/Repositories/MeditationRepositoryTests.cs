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
        public override void TestInitialize() { base.TestInitialize(); _sut = new MeditationRepository(_dbContext); }

        [TestCleanup]
        public override void TestCleanup() => base.TestCleanup();

        [TestMethod]
        public void GetAll_UnknownCollection_ShouldReturnNullReferenceException()
        {
            // arrange
            var collectionId = Guid.NewGuid();

            // act
            var result = _sut.GetAll(collectionId);

            // assert
            result.Should().BeNull();
        }
         
        [TestMethod]
        public void GetAll_UnknownCollection_ShouldReturnNullReferenceException2()
        {
            // arrange
            var collectionId = Guid.NewGuid();

            // act
            var result = _sut.GetAll(collectionId);

            // assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void GetAll_UnknownCollection_ShouldReturnNullReferenceException3()
        {
            // arrange
            var collectionId = Guid.NewGuid();

            // act
            var result = _sut.GetAll(collectionId);

            // assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void GetAll_UnknownCollection_ShouldReturnNullReferenceException4()
        {
            // arrange
            var collectionId = Guid.NewGuid();

            // act
            var result = _sut.GetAll(collectionId);

            // assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void GetAll_UnknownCollection_ShouldReturnNullReferenceException5()
        {
            // arrange
            var collectionId = Guid.NewGuid();

            // act
            var result = _sut.GetAll(collectionId);

            // assert
            result.Should().BeNull();
        }
        [TestMethod]
        public void GetAll_UnknownCollection_ShouldReturnNullReferenceException6()
        {
            // arrange
            var collectionId = Guid.NewGuid();

            // act
            var result = _sut.GetAll(collectionId);

            // assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void GetAll_UnknownCollection_ShouldReturnNullReferenceException7()
        {
            // arrange
            var collectionId = Guid.NewGuid();

            // act
            var result = _sut.GetAll(collectionId);

            // assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void GetAll_UnknownCollection_ShouldReturnNullReferenceException8()
        {
            // arrange
            var collectionId = Guid.NewGuid();

            // act
            var result = _sut.GetAll(collectionId);

            // assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void GetAll_UnknownCollection_ShouldReturnNullReferenceException9()
        {
            // arrange
            var collectionId = Guid.NewGuid();

            // act
            var result = _sut.GetAll(collectionId);

            // assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void GetAll_UnknownCollection_ShouldReturnNullReferenceException10()
        {
            // arrange
            var collectionId = Guid.NewGuid();

            // act
            var result = _sut.GetAll(collectionId);

            // assert
            result.Should().BeNull();
        }
    }
}
