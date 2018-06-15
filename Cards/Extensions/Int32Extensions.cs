using System.Linq;

namespace Cards.Extensions
{
    public static class Int32Extensions
    {
        public static int Pow(this int basement, int exponent)
        {
            return Enumerable.Repeat(basement, exponent).Aggregate(1, (b, e) => b * e);
        }
    }
}
