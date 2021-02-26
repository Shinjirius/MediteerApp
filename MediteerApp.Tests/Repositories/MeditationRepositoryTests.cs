using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediteerApp.Data.Repositories;
using FluentAssertions;

namespace MediteerApp.Tests.Repositories
{
    [TestClass]
    public class MeditationRepositoryTests
    {
        private static MeditationRepository _sut;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            _sut = new MeditationRepository();
        }

        [TestMethod]
        public void GetAll_KnownCollection_ShouldReturnInCollection()
        {
            // arrange
            var collectionId = Guid.Parse("74E1ABD2-9143-41B2-8704-A4C77B6B6300");

            // act
            var result = _sut.GetAll(collectionId);

            // assert
            result.Should().HaveCount(2);
        }
    }
}
