using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{

    public enum ShuffleType
    {
        FisherYates = 1,
        Riffle = 2,
        NoShuffle = 3
    }
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

        public static bool shuffleCardPack(int typeOfShuffle)
        {
            if (_pack.Count <= 1) return false;

            ShuffleType shuffleType = (ShuffleType)typeOfShuffle;
            switch (shuffleType)
            {
                case ShuffleType.FisherYates:
                    return FisherYatesShuffle();
                case ShuffleType.Riffle:
                    return RiffleShuffle();
                case ShuffleType.NoShuffle:
                    return true;
                default:
                    return false;
            }
        }
        public static Card deal()
        {
            // Error handling if the pack is empty
            if (_pack.Count <= 0) return null;

            Card firstCard = _pack.First();
            _pack.Remove(firstCard);
            return firstCard;
        }
        public static List<Card> dealCard(int amount)
        {
            List<Card> cards;
            // If there are more than enough cards to deal, proceed
            if (_pack.Count >= amount)
            {
                cards = _pack.Take(amount).ToList();
                _pack = _pack.Except(cards).ToList();
                return cards;
            }
            // Otherwise there are not "amount" cards
            cards = new List<Card>(_pack);
            _pack.Clear();
            return cards;
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

        private static bool FisherYatesShuffle()
        {
            Random random = new Random();
            for (int i = _pack.Count; i > 1; i--)
            {
                // Swap the ith card with the randomly generated jth card
                int j = random.Next(0,i);
                Card card1 = _pack[j];
                Card card2 = _pack[i-1];
                _pack[j] = card2;
                _pack[i-1] = card1;
            }
            return true;
        }

        private static bool RiffleShuffle()
        {
            Random random = new Random();
            List<Card> shuffledPack = new List<Card>();
            List<Card> pack1;
            List<Card> pack2;

            // Split the pack into 2
            pack1 = _pack.GetRange(0, _pack.Count / 2);
            pack2 = _pack.Except(pack1).ToList();

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

            // Add remaining cards to shuffleld pack
            shuffledPack.AddRange(pack1);
            shuffledPack.AddRange(pack2);
            _pack = shuffledPack;
            return true;
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
