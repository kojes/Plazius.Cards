using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    public class DictionaryChainListSorting : ICardListSorting
    {
        private List<Card> GetOrderedCardsList(Dictionary<string, Card> shuffledcardsDictionary)
        {
            var orderedList = new List<Card>(shuffledcardsDictionary.Count);
            do
            {
                var singlechainList = new List<Card>(shuffledcardsDictionary.Count);
                var entryCard = shuffledcardsDictionary.FirstOrDefault().Value;
                do
                {
                    singlechainList.Add(entryCard);
                    Card nextCard;
                    shuffledcardsDictionary.TryGetValue(entryCard.ArrivalCity, out nextCard);
                    shuffledcardsDictionary.Remove(entryCard.DepartureCity);
                    entryCard = nextCard;
                } while (entryCard != null);

                orderedList.InsertRange(0, singlechainList);
            } while (shuffledcardsDictionary.Count > 0);

            return orderedList;
        }

        public List<Card> GetOrderedCardsList(List<Card> shuffledcardsList)
        {
            var sortingDictionary = new Dictionary<string, Card>(shuffledcardsList.Count);
            foreach (var card in shuffledcardsList)
            {
                sortingDictionary.Add(card.DepartureCity, card);
            }
            return GetOrderedCardsList(sortingDictionary);
        }
    }
}
