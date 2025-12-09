using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Hand pldyer = new Hand();
            Hand dealer = new Hand();

            //これでドローができる
            //カードの中のカードにデッキのドローの
            //ランダムな数字のところを入れている
            Random random = new Random();

            Hand player = new Hand();



            Card card = deck.Draw();

            if (card == null)
            {

                if (deck != null)
                {
                    player.AddCard(card);

                    Console.WriteLine("山札がありません！");
                    return; // ゲーム停止
                }
            }

            //cardの中に入ってるmarkとnanbaを入れている
            Console.WriteLine($"マーク:{card.mark} 数字:{card.nanba}");
            card = deck.Draw();

            player.AddCard(card);

            //cardの中に入ってるmarkとnanbaを入れている
            Console.WriteLine($"マーク:{card.mark} 数字:{card.nanba}");

        }

        static void DisplayHand(Hand h)
        {

            foreach (Card c in h.Card)
            {
                Console.WriteLine($"{c.mark} {c.nanba}");
            }
            Console.WriteLine("合計:" + h.GetTotal());

        }
    }
}
