using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck
    {
        Card[] TDeck = new Card[52];

        //フォーだの数式を入れるときはパブリックなんちゃらを作る
        public Deck()
        {
            //if (i < 13)
            //{
            //    Console.WriteLine("♡" + TDeck[i]);
            //}
            //else if (i < 26)
            //{
            //    Console.WriteLine("♢" + TDeck[i]);
            //}
            //else if (i < 39)
            //{
            //    Console.WriteLine("♤" + TDeck[i]);
            //}
            //else
            //{
            //    Console.WriteLine("♧" + TDeck[i]);
            //}

            //TDeckの中身に1から13までの数字を入れる
            //カードのところにあるmarkとnanabの中身をCardの中に入れている
            for (int i = 0; i < 13; i++)
            { 
                TDeck[i * 4 + 0] = new Card(Card.Mark.clover,  i + 1);
                TDeck[i * 4 + 1] = new Card(Card.Mark.diamond, i + 1);
                TDeck[i * 4 + 2] = new Card(Card.Mark.heart,   i + 1);
                TDeck[i * 4 + 3] = new Card(Card.Mark.spade,   i + 1);
            }
        }
        public Card Draw()
       {
            // 山札が空か確認

            // ラムダ式()=>{};
            if (TDeck.All(c => c == null))
            {
                return null;    // 引けない
            }
            Random random = new Random();
            int doro;

            do 
            {
                doro = random.Next(52);
            }
            //ドローしたカードを無視
            while (TDeck[doro] == null);

            Card ikinokori = TDeck[doro];

            //ドローしたカードを無力化する
            TDeck[doro] = null;

            return ikinokori;
        }
    }
}
