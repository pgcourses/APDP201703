using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Data;
using _01Adapter.Resource;

namespace _01Adapter.Tests
{

    /// <summary>
    /// 
    ///    Repository ----()------> Adatok(adatbázis)
    ///    ebből indirekcióval
    ///    Repository ----> IDbDataAdapter ------> Adatbázis
    /// 
    /// </summary>

    [TestClass]
    public class AddressDbDataAdapterRepositoryTests
    {
        [TestMethod]
        public void AddressDbDataAdapterRepositoryShouldThrowIfArgumentNull()
        {
            //Arrange
            AddressDbDataAdapterRepository sut;

            //Act
            Action todo = () => sut = new AddressDbDataAdapterRepository(null);

            //Assert
            todo.ShouldThrow<ArgumentNullException>();

        }

        [TestMethod]
        public void AddressDbDataAdapterRepositoryShouldReturnData()
        {
            //Arrange
            var adapter = new MockDbDataAdapter(MockDataTableFactory.GetCreateDataTable());
            var sut = new AddressDbDataAdapterRepository(adapter);

            //Act
            var list = sut.GetAddresses();

            //Assert
            list.Should().HaveCount(1, "mivel egy elemet küldtünk a repoba")
                .And
                .Should().Equals(new Address { EMail = GlobalStrings.TesztEmailAddress });

        }
    }
}
