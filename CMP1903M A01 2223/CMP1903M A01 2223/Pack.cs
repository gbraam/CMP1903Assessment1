using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        private static Pack _instance = null;
        private static List<Card> _pack = new List<Card>();

        public static Pack Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Pack();
                }
                return _instance;
            }
        }

        private Pack()
        {
            _pack.Clear();
            InitialisePack();
            Console.WriteLine(_pack.Count);
        }

        // Could use an enum to represent type of shuffle
        // Add min number of cards check before shuffling
        // Shuffles should return bool
        public static bool shuffleCardPack(int typeOfShuffle)
        {
            if (_pack.Count <= 1) return false;
            if (typeOfShuffle == 1)
            {
                FisherYatesShuffle();
                return true;
            }
            else if (typeOfShuffle == 2)
            {
                RiffleShuffle();
                return true;
            }
            return false;
        }
        public static Card deal()
        {
            if (_pack.Count >= 1)
            {
                Card firstCard = _pack.First();
                _pack.Remove(firstCard);
                return firstCard;
            }
            // Pack has no cards remaining, what to do?
            // Create new instance and return cards?
            throw new NotImplementedException();
        }
        public static List<Card> dealCard(int amount)
        {
            if (_pack.Count >= amount)
            {
                List<Card> cards = _pack.Take(amount).ToList();
                _pack = _pack.Except(cards).ToList();
                return cards;
            }
            // Pack does not have enough cards
            throw new NotImplementedException();
        }

        private void InitialisePack()
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int x = 1; x <= 13; x++)
                {
                    Card card = new Card(x, i);
                    _pack.Add(card);
                }
            }
        }

        private static void FisherYatesShuffle()
        {
            Random random = new Random();
            for (int i = _pack.Count; i > 1; i--)
            {
                int j = random.Next(0,i);
                Card card1 = _pack[j];
                Card card2 = _pack[i-1];
                _pack[j] = card2;
                _pack[i-1] = card1;
            }
        }

        private static void RiffleShuffle()
        {
            Random random = new Random();
            List<Card> shuffledPack = new List<Card>();
            List<Card> pack1;
            List<Card> pack2;

            // Split the pack into 2
            pack1 = _pack.GetRange(0, _pack.Count / 2);
            pack2 = _pack.Except(pack1).ToList();

            // DEAD CODE
            //pack1 = _pack.Take(_pack.Count / 2).ToList();
            //pack2 = _pack.Skip(_pack.Count / 2).Take((_pack.Count / 2)+1).ToList();

            // Add a card from either pack chosen at random to the shuffled pack
            while (pack1.Count >= 1 && pack2.Count >= 1)
            {
                if (random.NextDouble() < 0.5)
                {
                    Card cardToAdd = pack1.First();
                    pack1.Remove(cardToAdd);
                    shuffledPack.Add(cardToAdd);
                }
                else
                {
                    Card cardToAdd = pack2.First();
                    pack2.Remove(cardToAdd);
                    shuffledPack.Add(cardToAdd);
                }
            }

            // Add remaining cards to shuffleld pack if there are any
            if (pack1.Count >= 1)
            {
                shuffledPack.AddRange(pack1);
            }
            if (pack2.Count >= 1)
            {
                shuffledPack.AddRange(pack2);
            }
            _pack = shuffledPack;

        }

        public static void PrintPack()
        {
            foreach (Card item in _pack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
