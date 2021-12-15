using Microsoft.VisualStudio.TestTools.UnitTesting;
using PepeKursach;

namespace PepeKursachTest
{
    [TestClass]
    public class PepeKursachTests
    {
        [TestMethod]
        public void EncodeExample1TextReturned()
        {
            string text = "Привет, это unit тест для зашифровки!";
            string key = "тест";
            string expected = "Вхъфчч, оеб unit чцде иэс ъейыжхафэн!";

            Coderator coderator = new Coderator();
            string actual = coderator.Encode(text, key);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EncodeExample2TextReturned()
        {
            string text = "This text should not change )0)0))";
            string key = "тест";
            string expected = "This text should not change )0)0))";

            Coderator coderator = new Coderator();
            string actual = coderator.Encode(text, key);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecodeExample1TextReturned()
        {
            string text = "Unit ейге ёцбчкта вгуыцчт!";
            string key = "Тест";
            string expected = "Unit тест успешно пройден!";

            Coderator coderator = new Coderator();
            string actual = coderator.Decode(text, key);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecodeExample2TextReturned()
        {
            string text = "This text should not change )0)0))";
            string key = "Тест";
            string expected = "This text should not change )0)0))";

            Coderator coderator = new Coderator();
            string actual = coderator.Decode(text, key);

            Assert.AreEqual(expected, actual);
        }
    }
}
