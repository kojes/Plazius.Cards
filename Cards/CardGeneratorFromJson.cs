using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Cards
{
    public class CardGeneratorFromJson : CardGenerator
    {
        private static readonly Random Random = new Random();

        private string Path { get; }
        private List<string> CitiesList { get; } = new List<string>();

        public CardGeneratorFromJson(string path)
        {
            this.Path = path;
            CitiesList.AddRange(
                JsonConvert.DeserializeObject<JArray>(File.ReadAllText(Path)).Select(x => (string) x["name"]).ToList());
        }

        protected override string GetCityName()
        {
            return CitiesList[Random.Next(0, CitiesList.Count)];
        }

        protected override bool QuantityErrorExisting(int quantity)
        {
            return CitiesList.Count < quantity;
        }
    }
}
