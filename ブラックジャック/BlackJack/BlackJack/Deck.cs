using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck
    {
        int[] TDeck = new int[52];
        public Deck()
        {
            for (int i = 0; i < TDeck.Length; i++)
            {
                TDeck[i] = i + 1;
            }

        }
       
    }
}
