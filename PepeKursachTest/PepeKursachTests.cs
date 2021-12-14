using Microsoft.VisualStudio.TestTools.UnitTesting;
using PepeKursach;
using System;

namespace PepeKursachTest
{
    [TestClass]
    public class PepeKursachTests
    {
        [TestMethod]
        public void EncodeExampleTextReturned()
        {
            string text = "Привет, это unit тест для зашифровки!";
            string key = "тест";
            string expected = "Вхъфчч, оеб unit чцде иэс ъейыжхафэн!";

            Coderator coderator = new Coderator();
            string actual = coderator.Encode(text, key);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecodeExampleTextReturned()
        {
            string text = "Unit ейге ёцбчкта вгуыцчт!";
            string key = "Тест";
            string expected = "Unit тест успешно пройден!";

            Coderator coderator = new Coderator();
            string actual = coderator.Decode(text, key);

            Assert.AreEqual(expected, actual);
        }
    }
}
