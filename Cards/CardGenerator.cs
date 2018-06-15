using System;
using System.Collections.Generic;
using Cards.Extensions;
using EnsureThat;

namespace Cards
{
    public abstract class CardGenerator : ICardSource
    {
        private HashSet<string> DuplicatesPreventionHashSet { get; } = new HashSet<string>();

        protected int CardQuantity { get; set; }

        public List<Card> GetShuffledCardsList(int cardQuantity)
        {
            CardQuantity = cardQuantity;
            if (QuantityErrorExisting(CardQuantity))
            {
                throw new Exception("Not enough cities names to create list without duplicates");
            }
            return GenerateCardsList().Shuffle();
        }

        private List<Card> GenerateCardsList()
        {
            Ensure.That(CardQuantity).IsGte(2);
            Ensure.That(CardQuantity).IsLte(4000000);
            
            DuplicatesPreventionHashSet.Clear();

            var cardsList = new List<Card>();
            var departureCity = string.Empty;
            for (var i = 0; i < CardQuantity; i++)
            {
                var generatedcard = GenerateCard(departureCity);
                cardsList.Add(generatedcard);
                departureCity = generatedcard.ArrivalCity;
            }
            return cardsList;
        }

        private Card GenerateCard(string departureCity)
        {
            if (string.IsNullOrEmpty(departureCity))
                departureCity = GenerateCityWithoutDuplicateAndIncorrectNames();
            var arrivalCity = GenerateCityWithoutDuplicateAndIncorrectNames();
            return new Card(departureCity, arrivalCity);
        }

        private void FillDuplicateHashSet(string addedcity)
        {
            DuplicatesPreventionHashSet.Add(addedcity);
        }

        private string GenerateCityWithoutDuplicateAndIncorrectNames()
        {
            string cityName;
            do
            {
                cityName = GetCityName();
            } while (DuplicatesPreventionHashSet.Contains(cityName) || !cityName.ShouldBeACityName());

            FillDuplicateHashSet(cityName);
            return cityName;
        }

        protected abstract string GetCityName();
        protected abstract bool QuantityErrorExisting(int quantity);
    }
}
