using System;
using System.Collections.Generic;
using System.Linq;
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

        public static bool shuffleCardPack(int typeOfShuffle)
        {
            //Shuffles the pack based on the type of shuffle
            throw new NotImplementedException();
        }
        public static Card deal()
        {
            //Deals one card
            throw new NotImplementedException();
        }
        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            throw new NotImplementedException();
        }

        private void InitialisePack()
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int x = 1; x <= 13; x++)
                {
                    Card card = new Card(i, x);
                    _pack.Add(card);
                }
            }
        }
    }
}
