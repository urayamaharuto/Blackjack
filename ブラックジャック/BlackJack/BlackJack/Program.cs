using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
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
            player.AddCard(card);
            card = deck.Draw();
            player.AddCard(card);


            DisplayHand(player);

            //選択をさせるやつ　ヒットスタンド作る
            int sentaku = 0;
            while (sentaku != 2)
            {
                Console.WriteLine("ヒットしたいなら：1　スタンドなら：2　を入力してね");
                sentaku = int.Parse(Console.ReadLine());

                //switch (sentaku)
                //{
                //    case 0:

                //        break;

                //    default:

                //        break;
                //}

                if (sentaku == 1)
                {
                    //一枚ドロー
                    card = deck.Draw();
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
                    player.AddCard(card);

                    DisplayHand(player);
                }
                else if (sentaku == 2)
                {
                    Console.WriteLine("ターンエンド！");
                }
                else { Console.WriteLine("そうかそうか。つまり君はそんなやつなんだな。"); }
            }
        }
        static void DisplayHand(Hand h)
        {
            //foreach (Card c in h.Card)
            //{
            //    Console.WriteLine($"{c.mark} {c.nanba}");
            //}
            Console.WriteLine("合計:" + h.GetTotal());
        }
        
    }
}
