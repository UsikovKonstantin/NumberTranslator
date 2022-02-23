using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryNumberTranslator;

namespace UnitTestsNumberTranslator {
    [TestClass]
    public class UnitTestsNumberTranslator {
        [TestMethod]
        public void FromPto10Int_ReturnsIntNumberInBase10() {
            bool test1 = NumberTranslator.FromPto10Int("101", 2) == "5";
            bool test2 = NumberTranslator.FromPto10Int("10", 2) == "2";
            Assert.IsTrue(test1 && test2);
        }

        [TestMethod]
        public void From10toQInt_ReturnIntNumberInBaseQ() {
            bool test1 = NumberTranslator.From10toQInt("5", 2) == "101";
            bool test2 = NumberTranslator.From10toQInt("2", 2) == "10";
            Assert.IsTrue(test1 && test2);
        }

        public void FromPto10Frac_ReturnFracNumberInBase10() {
            bool test1 = NumberTranslator.FromPto10Frac("1101", 2) == "0,8125";
            bool test2 = NumberTranslator.FromPto10Frac("53", 8) == "0,671875";
            Assert.IsTrue(test1 && test2);
        }

        public void From10toQFrac_ReturnsFracNumberInBaseQ() {
            bool test1 = NumberTranslator.From10toQFrac("0,8125", 2, 10) == "1101";
            bool test2 = NumberTranslator.From10toQFrac("0,671875", 8, 10) == "53";
            Assert.IsTrue(test1 && test2);
        }
    }
}
