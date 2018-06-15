using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Extensions
{
    public static class ListExtensions
    {
        public static List<T> Shuffle<T>(this List<T> list)
        {
            var random = new Random();
            return list.OrderBy(x => random.Next()).ToList();
        }

        public static bool CardListIsCorrectChain(this List<Card> cardList)
        {
            var isChain = true;
            for (var i = 0; i < cardList.Count - 1; i++)
            {
                if (cardList[i].ArrivalCity != cardList[i + 1].DepartureCity)
                {
                    isChain = false;
                }
            }
            return isChain;
        }
    }
}
