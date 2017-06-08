using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _13CommandPelda;
using System.Linq;

namespace _14CommandPelda.Tests
{
    ///  - új (megrendelés) felvitele
    ///  - meglévő törlése
    ///  - meglévő módosítása
    ///  - ha nem adunk meg semmit, akkor kiírja a használati útmutatót
    ///  - ha pedig rossz parancsot adunk meg, akkor jelzi, hogy ismeretlen a parancs
    
    [TestClass]
    public class AlkalmazasTests
    {
        [TestMethod]
        public void _CommandHaUjMegrendelestAdunkMegAkkorAFelvitelrolKellKapnunkErtesitest()
        {
            //Arrange
            var sut = new Alkalmazas();

            //Act
            var eredmeny = sut.Bevitel(new string[] { MagicValues.CommandTextNew });

            Console.WriteLine(eredmeny);

            //Assert
            Assert.AreEqual(MagicValues.CommandResponseNew, eredmeny);
        }

        [TestMethod]
        public void _CommandHaMeglevotAkarunkTorolniAkkorATorlesrolKellKapnunkErtesitest()
        {
            //Arrange
            var sut = new Alkalmazas();
            var parameter = "2";

            //Act
            var eredmeny = sut.Bevitel(new string[] { MagicValues.CommandTextDelete, parameter }); //adunk valami paramétert, egyelőre az érték nem számít

            Console.WriteLine(eredmeny);

            var elvart = string.Format(MagicValues.CommandResponseDelete, parameter);

            //Assert
            Assert.AreEqual(elvart, eredmeny);
        }

        //[TestMethod]
        //public void _CommandHaOlyatAkarunkTorolniAmiNincsAkkorAHibarolKellKapnunkErtesitest()
        //{
        //}

        [TestMethod]
        public void _CommandHaMeglevotAkarunkModositaniAkkorAModositasrolKellKapnunkErtesitest()
        {
            //Arrange
            var sut = new Alkalmazas();
            var parameter = "2";

            //Act
            var eredmeny = sut.Bevitel(new string[] { MagicValues.CommandTextModify, parameter }); //adunk valami paramétert, egyelőre az érték nem számít

            Console.WriteLine(eredmeny);

            var elvart = string.Format(MagicValues.CommandResponseModify, parameter);
            //Assert
            Assert.AreEqual(elvart, eredmeny);
        }

        //[TestMethod]
        //public void _CommandHaOlyatAkarunkModositaniAmiNincsAkkorAHibarolKellKapnunkErtesitest()
        //{
        //}

        [TestMethod]
        public void _CommandHaIsmeretlenParancsotAdunkAHibarolKellKapnunkErtesitest()
        {
            //Arrange
            var sut = new Alkalmazas();

            //Act
            var eredmeny = sut.Bevitel(new string[] { MagicValues.CommandTextInvalid });

            Console.WriteLine(eredmeny);

            var elvart = string.Format(MagicValues.CommandResponseInvalid, MagicValues.CommandTextInvalid);

            //Assert
            Assert.AreEqual(elvart, eredmeny);
        }

        [TestMethod]
        public void _CommandHaNemAdunkMegSemmitAkkorMegKellKapnunkAHasznalatiLeirast()
        {
            //Arrange
            var sut = new Alkalmazas();

            //Act
            var eredmeny = sut.Bevitel(new string[] { });

            Console.WriteLine(eredmeny);

            //Assert
            var sorok = eredmeny.Count(x => x == '\n'); //a karakterek közül a soremelés karakterek száma
            Assert.AreEqual(4, sorok);

            var hUtasitas = sut.HasznalatiUtasitas();
            Assert.AreEqual(hUtasitas, eredmeny);

        }
    }
}
