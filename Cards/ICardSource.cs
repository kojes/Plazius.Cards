using System.Collections.Generic;

namespace Cards
{
    public interface ICardSource
    {
         List<Card> GetShuffledCardsList(int cardQuantity);
    }
}