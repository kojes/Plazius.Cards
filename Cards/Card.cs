using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EnsureThat;
using Cards.Extensions;
namespace Cards
{
    public class Card
    {
        
        public string DepartureCity { get; }
        public string ArrivalCity { get; }
        
        public Card(string departureCity, string arrivalCity)
        {
            Ensure.That(departureCity).IsNotNullOrWhiteSpace();
            Ensure.That(arrivalCity).IsNotNullOrWhiteSpace();

            Ensure.That(departureCity.ShouldBeACityName()).IsTrue();
            Ensure.That(arrivalCity.ShouldBeACityName()).IsTrue();

            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
        }

        public override string ToString()
        {
            return DepartureCity + " => " + ArrivalCity;
        }
    }

    
}
