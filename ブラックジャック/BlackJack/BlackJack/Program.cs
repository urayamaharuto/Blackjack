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
            Console.WriteLine("- - - Player Turn - - -");

            Deck deck = new Deck();
            Hand dealer = new Hand();

            //これでドローができる
            //カードの中のカードにデッキのドローの
            //ランダムな数字のところを入れている
            Random random = new Random();

            Hand player = new Hand();
            Dealer oya = new Dealer();

            int D_noisi = oya.GetTotal();
            int H_noisi = player.GetTotal();

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
                if (player.GetTotal() > 21)
                {
                    break;
                }
                if (player.GetTotal() == 21)
                {
                    Console.WriteLine("ブラックジャック達成！");
                    Console.WriteLine("カカロット！お前がナンバーワンだ！");
                    break;
                }

                Console.WriteLine("ヒットしたいなら：1　スタンドなら：2　を入力してね");

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out sentaku) && (sentaku == 1 || sentaku == 2))
                    {
                        break;
                    }
                    Console.WriteLine("文字読める?");
                }

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

                if (sentaku == 2)
                {
                    card = deck.Draw();
                    if (card == null)
                    {
                        if (deck != null)
                        {
                            oya.AddCard(card);

                            Console.WriteLine("山札がありません！");
                            return; // ゲーム停止
                        }
                    }

                }
            }

            //親のターン
            Console.WriteLine("ターンエンド！");
            Console.WriteLine("親のターンだぜ！");
            Console.WriteLine();
            Console.WriteLine("- - - Dealer Turn - - -");

            //cardの中に入ってるmarkとnanbaを入れている
            oya.AddCard(card);
            card = deck.Draw();
            oya.AddCard(card);
            DisplayDealer(oya);

            //引かなきゃいけないときにもう一枚引く
            D_noisi = oya.GetTotal();
            H_noisi = player.GetTotal();
            while (D_noisi < 16)
            {
                card = deck.Draw();
                oya.AddCard(card);
                D_noisi = oya.GetTotal();
                DisplayDealer(oya);
            }

            while (H_noisi > D_noisi && H_noisi <= 21)
            {
                card = deck.Draw();
                oya.AddCard(card);
                D_noisi = oya.GetTotal();
                DisplayDealer(oya);
            }
         

            //結果発表
            Console.WriteLine();
            Console.WriteLine("☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆");
            Console.WriteLine("結果発表！！！！！！！！！！！！！！！！");
            Console.WriteLine($"おまえが{H_noisi}点で、パソコン君が{D_noisi}でした！");

            if (H_noisi >= 22)
            {
                H_noisi = 0;
            }
            if (D_noisi >= 22)
            {
                D_noisi = 0;
            }

            if (H_noisi == D_noisi)
            {
                Console.WriteLine("機械相手に引き分けって恥ずかしくないんですか？ww");
            }
            else if (H_noisi > D_noisi)
            {
                Console.WriteLine("わぁ！勝てたんだぁ！勝ててよかったねぇ！...ｗ");
            }
            else
            {
                Console.WriteLine("負けちゃったんだぁwwwチー牛だからしょうがないかぁwww");
            }
            Console.WriteLine("☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆");
        }
        static void DisplayHand(Hand h)
        {
            //foreach (Card c in h.Card)
            //{
            //    Console.WriteLine($"{c.mark} {c.nanba}");
            //}
            //ごめんちょっと使った
            foreach (Card ten2 in h.Card)
            {
                Console.WriteLine($"マーク:{ten2.mark} 数字:{ten2.nanba}");
            }
            //点数を表示するやつ
            Console.WriteLine("合計:" + h.GetTotal());
            //バーストしてるかをみる
            if (h.IsBust())
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("おまえはもう、バーストしている");
                Console.WriteLine("------------------------------");
            }
        }
        static void DisplayDealer(Dealer h2)
        {
            foreach (Card ten2 in h2.D_Card)
            {
                Console.WriteLine($"マーク:{ten2.mark} 数字:{ten2.nanba}");
            }
            Console.WriteLine("合計:" + h2.GetTotal());

            if (h2.IsBust())
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("このオレが...バーストだと...！");
                Console.WriteLine("------------------------------");
            }
        }
    }
}
