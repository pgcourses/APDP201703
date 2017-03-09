using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Data;
using _01Adapter.Resource;
using System.Data.OleDb;

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
        public void AddressDbDataAdapterRepositoryShouldReturnMockData()
        {
            //Arrange
            var adapter = new MockDbDataAdapter(MockDataTableFactory.GetCreateDataTable());
            var sut = new AddressDbDataAdapterRepository(adapter);

            //Act
            var list = sut.GetAddresses();

            //Assert
            list.Should().HaveCount(1, "mivel egy elemet küldtünk a repoba")
                //.And
                //.Should().Equals(new Address { EMail = GlobalStrings.TesztEmailAddress })
            ;

        }

        [TestMethod]
        public void AddressDbDataAdapterRepositoryShouldReturnSQLData()
        {
            //Arrange
            var adapter = new OleDbDataAdapter();
            adapter.SelectCommand = new OleDbCommand($"SELECT * FROM {GlobalStrings.TableName}");
            adapter.SelectCommand.Connection = new OleDbConnection("Provider=sqloledb;Data Source=.\\SQLEXPRESS;Initial Catalog=_00Data.AddressContext;Integrated Security = SSPI;");

            var sut = new AddressDbDataAdapterRepository(adapter);

            //Act
            var list = sut.GetAddresses();

            //Assert
            list.Should().HaveCount(1, "mivel egy elemet küldtünk a repoba")
                //.And
                //.Should().Equals(new Address { EMail = GlobalStrings.TesztEmailAddress })
                ;

            list.Should().Equals(new Address { EMail = GlobalStrings.TesztEmailAddress });

        }

    }
}
