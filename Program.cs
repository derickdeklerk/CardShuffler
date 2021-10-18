using System;
using System.Collections.Generic;

namespace CardShuffler
{
    static class Program
    {
        private static Random rng = new Random();

        static void Main(string[] args)
        {
            List<Card> deck = GenerateDeck();          
            bool exitApp = false;
            while (!exitApp)
            {
                Console.WriteLine("Press S to shuffle and display a new deck.");
                Console.WriteLine("Press X to exit.");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.S:
                        Console.Clear();
                        deck.Shuffle();
                        foreach (Card card in deck)
                        {
                            Console.WriteLine("{0} of {1}", card.Number, card.Suit);
                        }
                        break;
                    case ConsoleKey.X:
                        exitApp = true;
                        break;
                }
            }
        }

        public static List<Card> GenerateDeck()
        {
            List<Card> deck = new List<Card>();

            string[] numbers = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            string[] suits = new string[] { "Clubs", "Spades", "Diamonds", "Hearts" };

            foreach (string number in numbers)
            {
                foreach (string suit in suits)
                {
                    Card card = new Card(number, suit);
                    deck.Add(card);
                }
            }
            return deck;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    class Card
    {
        public string Number { get; set; }
        public string Suit { get; set; }

        public Card(string number, string suit)
        {
            Number = number;
            Suit = suit;
        }
    }
}
