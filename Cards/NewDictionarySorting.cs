using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class NewDictionarySorting : ICardListSorting
    {
        private List<Card> GetOrderedCardsList(Dictionary<string, Card> shuffledcardsDictionary)
        {
            string chainstartCity;
            var dictionaryCapacity = shuffledcardsDictionary.Count;
            var orderedList = new List<Card>(dictionaryCapacity);
            var notavaliableKeys = new HashSet<string>();
            do
            {
                var entryCard = shuffledcardsDictionary.FirstOrDefault(x => !notavaliableKeys.Contains(x.Key)).Value;
                chainstartCity = entryCard.DepartureCity;
                do
                {
                    Card nextCard;
                    shuffledcardsDictionary.TryGetValue(entryCard.ArrivalCity, out nextCard);
                    notavaliableKeys.Add(entryCard.DepartureCity);
                    entryCard = nextCard;
                } while (entryCard != null);
                
            } while (notavaliableKeys.Count < dictionaryCapacity - 1);


            Card currentCard;
            shuffledcardsDictionary.TryGetValue(chainstartCity, out currentCard);

            do
            {
                Card nextCard;
                shuffledcardsDictionary.TryGetValue(currentCard.ArrivalCity, out nextCard);
                orderedList.Add(currentCard);
                currentCard = nextCard;
            } while (currentCard != null);



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
