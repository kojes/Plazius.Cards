using Cards;
using Cards.Extensions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CardSorting
    {
        [Test]
        public void DictionaryChainListSorting_TryToOrderShuffledCardsList_ReturnOrderedCardsList()
        {
            const int cardQuantity = 1000;
            const int cityNameLength = 10;
            Cards.CardGenerator cardGenerator = new CardGeneratorRandom(cityNameLength);
            var cardList = cardGenerator.GetShuffledCardsList(cardQuantity);
            ICardListSorting cardListSorting = new DictionaryChainListSorting();
            Assert.IsTrue(cardListSorting.GetOrderedCardsList(cardList).CardListIsCorrectChain());
        }
    }
}
