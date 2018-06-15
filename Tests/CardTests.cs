using System;
using NUnit.Framework;
using Cards;

namespace Tests
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void Card_ToString_ReturnArrowMode()
        {
            Assert.AreEqual(new Card("Moscow", "Vologda").ToString(), "Moscow => Vologda");
        }

        [Test]
        public void Card_EmptyParametersInCtor_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => { new Card(" ", " "); });
            Assert.That(ex.Message, Is.EqualTo("The string can't be left empty, null or consist of only whitespaces."));

            ex = Assert.Throws<ArgumentException>(() => { new Card("", ""); });
            Assert.That(ex.Message, Is.EqualTo("The string can't be left empty, null or consist of only whitespaces."));
        }

        [Test]
        public void Card_RegexNotMatchCitiesInCtor_ThrowArgumentException()
        {
            Assert.AreEqual(new Card("New-York", "Краснодар").ToString(), "New-York => Краснодар");

            var ex = Assert.Throws<ArgumentException>(() => { new Card("Вологда", "YY-AA9"); });
            Assert.That(ex.Message,
                Is.EqualTo("Expected an expression that evaluates to true."));
        }
    }
}
