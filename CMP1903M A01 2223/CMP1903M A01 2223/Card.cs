using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        private int _value;
        private int _suit;

        public int Value
        {
            get { return _value; }
            private set { _value = ClampValue(1,13,value); }
        }
        public int Suit
        {
            get { return _suit; }
            private set { _suit = ClampValue(1,4,value); }
        }

        public Card(int value, int suit)
        {
            Value = value;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"Value: {Value}, Suit: {Suit}";
        }

        private int ClampValue(int min, int max, int value)
        {
            if (value > max)
            {
                return max;
            }
            else if (value < min)
            {
                return min;
            }
            return value;
        }
    }
}
