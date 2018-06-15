using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Cards;
using Cards.Extensions;

namespace CardsBenchmark
{
    public class SortingCardBenchmark
    {
        [ParamsSource(nameof(BenchmarkQuantityArray))]
        public int CardQuantity { get; set; }

        public static List<Card> CardShuffledList { get; set; }

        public static ICardListSorting CardListSorting { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            CardShuffledList = new CardGeneratorRandom(10).GetShuffledCardsList(CardQuantity);
        }


        [Benchmark]
        public void BenchmarkListChainSorting()
        {
            new DictionaryChainListSorting().GetOrderedCardsList(CardShuffledList);
        }


        public static IEnumerable<int> BenchmarkQuantityArray()
        {
            var benchmarkArray = new List<int>();
            for (var i = 1; i < 10; i++)
            {
                benchmarkArray.Add(5.Pow(i));
            }
            return benchmarkArray;
        }
    }
}
