using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    internal class Testing
    {
        public Testing()
        {
            Pack pack = Pack.Instance;

            Pack.shuffleCardPack(1);
            Pack.shuffleCardPack((int)ShuffleType.FisherYates);
            Pack.shuffleCardPack(2);
            Pack.shuffleCardPack(3);

            List<Card> hand1 = Pack.dealCard(5);
            Console.WriteLine(Pack.deal());

            Console.WriteLine("Hand Cards: ");
            foreach (Card item in hand1)
            {
                Console.WriteLine(item);
            }

        }
    }
}
