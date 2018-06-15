using System;
using System.Linq;
using Cards.Extensions;
using EnsureThat;

namespace Cards
{
    public class CardGeneratorRandom : CardGenerator
    {
        private static readonly Random Random = new Random();

        private int CityNameLength { get; }

        private static string CharsetString { get; } = "abcdefghijklmnopqrstuvwxyz";

        public CardGeneratorRandom(int cityNameLength)
        {
            Ensure.That(cityNameLength).IsGte(3);
            Ensure.That(cityNameLength).IsLte(100);
            
            CityNameLength = cityNameLength;
        }


        protected override string GetCityName()
        {
            var chars =
                Enumerable.Range(0, CityNameLength).Select(x => CharsetString[Random.Next(0, CharsetString.Length)]);
            return new string(chars.ToArray());
        }

        protected override bool QuantityErrorExisting(int quantity)
        {
            return CharsetString.Length.Pow(CityNameLength) < quantity;
        }
    }
}
