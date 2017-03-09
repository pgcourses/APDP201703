using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Data;

namespace _01Adapter.Tests
{

    /// <summary>
    /// 
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
    }
}
