using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Data;
using _01Adapter.Resource;

namespace _01Adapter.Tests
{
    [TestClass]
    public class MockDbDataAdapterTests
    {
        [TestMethod]
        public void MockDbDataAdapterRepositoryShouldThrowIfArgumentNull()
        {
            //Arrange
            var sut = new MockDbDataAdapter();

            //Act
            Action todo = () => sut.Fill(null);

            //Assert
            todo.ShouldThrow<ArgumentNullException>();

        }

        [TestMethod]
        public void MockDbDataAdapterShouldReturnOneTable()
        {
            //Arrange
            var sut = new MockDbDataAdapter();
            var dataSet = new DataSet();
            //Act
            sut.Fill(dataSet);

            //Assert
            dataSet.Tables.Should().HaveCount(1);
        }

        [TestMethod]
        public void MockDbDataAdapterShouldReturnData()
        {
            //Arrange
            var sut = new MockDbDataAdapter();
            var dataSet = new DataSet();
            //Act
            sut.Fill(dataSet);

            //Assert
            dataSet.Tables.Should().HaveCount(1, "Mivel egy táblával kell visszatérni");

            var table = dataSet.Tables[0];
            table.Rows.Should().HaveCount(1, "Mivel a táblában kell lennie egy sornak");
            table.Columns[GlobalStrings.TableColumnEMailAddress].Should().NotBeNull();
            table.Rows[0][GlobalStrings.TableColumnEMailAddress].Should().Be(GlobalStrings.TesztEmailAddress);

        }

    }
}
