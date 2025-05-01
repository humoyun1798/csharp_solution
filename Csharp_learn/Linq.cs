using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_learn
{
    public class Linq
    {
        // Program.cs
        // The Main() method

        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }

        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }

        public void a()
        {
            var startingDeck = Suits().SelectMany(suit => Ranks().Select(rank => new { Suit = suit, Rank = rank }));

            //var startingDeck2 = Suits().Select(suit => Ranks().Select(rank => new { Suit = suit, Rank = rank }));


            foreach (var item in startingDeck)
            {
                Console.WriteLine($"{item.Rank} of {item.Suit}");
            }
        }


    }
}
