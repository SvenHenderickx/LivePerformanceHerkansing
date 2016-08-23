using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoodschApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoodschApp.Exceptions;

namespace BoodschApp.Classes.Tests
{
    [TestClass()]
    public class BoodschappenlijstTests
    {
        [TestMethod()]
        public void VoegBoodschapToeTestSlagen()
        {
            Boodschappenlijst boodschappenlist = new Boodschappenlijst();
            boodschappenlist.VoegBoodschapToe(new Boodschap(new Product(0, "test", ""), 1));
        }

        [TestMethod()]
        [ExpectedException(typeof(BoodschapException))]
        public void VoegBoodschapToeTestFail()
        {
            Boodschappenlijst boodschappenlist = new Boodschappenlijst();
            boodschappenlist.VoegBoodschapToe(new Boodschap(new Product(0, "test", ""), 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(BoodschapException))]
        public void VoegBoodschapToeTestFail2()
        {
            Boodschappenlijst boodschappenlist = new Boodschappenlijst();
            boodschappenlist.VoegBoodschapToe(new Boodschap(new Product(0, "test", ""), 1));
            boodschappenlist.VoegBoodschapToe(new Boodschap(new Product(0, "test", ""), 1));
        }

        [TestMethod()]
        public void VoegGerechtToeTest()
        {
            Assert.Fail();
        }
    }
}