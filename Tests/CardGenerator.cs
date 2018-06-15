using System;
using System.IO;
using System.Linq;
using Cards;
using Cards.Extensions;
using NUnit.Framework;


namespace Tests
{
    [TestFixture]
    public class CardGenerator
    {
        [Test]
        public void CardGeneratorRandom_GetCardsList_ThrowOutOfRangeExceptions()
        {
            const int cardLowerQuantity = 1;
            const int cityNameLowerLength = 1;
            const int cityNameGreaterLength = 1000;
            const int cardGreaterQuantity = 40000000;

            var ex =
                Assert.Throws<ArgumentOutOfRangeException>(() => { new Cards.CardGeneratorRandom(10).GetShuffledCardsList(cardLowerQuantity); });

            Assert.That(ex.Message,
                Is.EqualTo(
                    $"Value '{cardLowerQuantity}' is not greater than or equal to limit '2'.\r\nActual value was {cardLowerQuantity}."));

            ex = Assert.Throws<ArgumentOutOfRangeException>(() => { new Cards.CardGeneratorRandom(cityNameLowerLength).GetShuffledCardsList(10); });
            Assert.That(ex.Message,
                Is.EqualTo(
                    $"Value '{cityNameLowerLength}' is not greater than or equal to limit '3'.\r\nActual value was {cityNameLowerLength}."));

            ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new Cards.CardGeneratorRandom(10).GetShuffledCardsList(cardGreaterQuantity);
            });
            Assert.That(ex.Message,
                Is.EqualTo(
                    $"Value '{cardGreaterQuantity}' is not lower than or equal to limit '4000000'.\r\nActual value was {cardGreaterQuantity}."));

            ex =
                Assert.Throws<ArgumentOutOfRangeException>(
                    () => { new Cards.CardGeneratorRandom(cityNameGreaterLength).GetShuffledCardsList(100); });
            Assert.That(ex.Message,
                Is.EqualTo(
                    $"Value '{cityNameGreaterLength}' is not lower than or equal to limit '100'.\r\nActual value was {cityNameGreaterLength}."));
        }

        [Test]
        public void CardGeneratorRandom_GetCardsList_ThrowQuantityErrorException()
        {
            var exception = Assert.Throws<Exception>(() => { new Cards.CardGeneratorRandom(4).GetShuffledCardsList(500000); });
            Assert.That(exception.Message, Is.EqualTo("Not enough cities names to create list without duplicates"));
        }

        [Test]
        public void CardGeneratorJson_GetCardsList_ThrowQuantityErrorException()
        {
            var exception = Assert.Throws<Exception>(() => { new Cards.CardGeneratorRandom(4).GetShuffledCardsList(500000); });
            Assert.That(exception.Message, Is.EqualTo("Not enough cities names to create list without duplicates"));
        }

        [Test]
        public void CardGeneratorRandom_GetCardsList_ReturnCardsListWithCorrectCapacity()
        {
            const int cardQuantity = 1024;
            const int cityNameLength = 10;
            Cards.CardGenerator cardGenerator = new Cards.CardGeneratorRandom(cityNameLength);
            var cardList = cardGenerator.GetShuffledCardsList(cardQuantity);
            Assert.AreEqual(cardList.Count, cardQuantity);
        }

        [Test]
        public void CardGeneratorRandom_GetCardsList_ReturnCardsListWithCorrectCityNameLength()
        {
            const int cardQuantity = 1024;
            const int cityNameLength = 10;
            Cards.CardGenerator cardGenerator = new Cards.CardGeneratorRandom(cityNameLength);
            var cardList = cardGenerator.GetShuffledCardsList(cardQuantity);

            Assert.AreEqual(
                cardList.Count(
                    x => x.DepartureCity.Length == cityNameLength && x.ArrivalCity.Length == cityNameLength),
                cardQuantity);
        }

        [Test]
        public void CardGeneratorRandom_ShuffleCardsList_ReturnShuffledList()
        {
            Cards.CardGenerator cardGenerator = new CardGeneratorRandom(10);
            var cardList = cardGenerator.GetShuffledCardsList(1000);
            Assert.IsFalse(cardList.CardListIsCorrectChain());
        }

        [Test]
        public void CardGeneratorFromJson_ShuffleCardsList_ReturnShuffledList()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"TestData\cities.json");
            Cards.CardGenerator cardGenerator = new CardGeneratorFromJson(path);
            var cardList = cardGenerator.GetShuffledCardsList(1000);
            Assert.IsFalse(cardList.CardListIsCorrectChain());
        }

    }
}
