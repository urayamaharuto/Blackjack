using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ka = 0;

            while (true)
            {
                PlayGame();

                Console.WriteLine();
                Console.WriteLine("もう一回やるぅ？ 1:はい / 2:いいえ");

                int retry;
                while (!int.TryParse(Console.ReadLine(), out retry) || (retry != 1 && retry != 2))
                {
                    Console.WriteLine("1 か 2 を入力してね");
                }

                if (retry == 2)
                {
                    Console.WriteLine("ゲーム終了！");
                    break;
                }

                Console.Clear(); // 画面リセット（任意）
            }
        }


static void PlayGame()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("- - - Player Turn - - -");
            Console.ForegroundColor = ConsoleColor.Green;

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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("- - - Dealer Turn - - -");
            Console.ForegroundColor = ConsoleColor.Green;

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
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Yellow;
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

            Console.ForegroundColor = ConsoleColor.Cyan;
            if (H_noisi == D_noisi)
            {
                Console.WriteLine("機械相手に引き分けって恥ずかしくないんですか？ww");
            }
            else if (H_noisi > D_noisi)
            {
                Console.WriteLine("わぁ！勝てたんだぁ！勝ててよかったねぇ！...ｗ");

                //kati = kati + 1;
            }
            else
            {
                Console.WriteLine("負けちゃったんだぁwwwチー牛だからしょうがないかぁwww");
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine($"おまえは今{kati}回勝ってまーす！");
            //if (kati < 3)
            //{
            //    Console.WriteLine("もっと頑張れーｗ");
            //}
            //else { Console.WriteLine("そんなにたのしかった？ｗ"); }

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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("合計:" + h.GetTotal());
            Console.ForegroundColor = ConsoleColor.Green;
            //バーストしてるかをみる
            if (h.IsBust())
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("------------------------------");
                Console.WriteLine("おまえはもう、バーストしている");
                Console.WriteLine("------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }
        static void DisplayDealer(Dealer h2)
        {
            //先生作
            Thread.Sleep(1000);
            foreach (Card ten2 in h2.D_Card)
            {
                Console.WriteLine($"マーク:{ten2.mark} 数字:{ten2.nanba}");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("合計:" + h2.GetTotal());
            Console.ForegroundColor = ConsoleColor.Green;

            if (h2.IsBust())
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("------------------------------");
                Console.WriteLine("このオレが...バーストだと...！");
                Console.WriteLine("------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }
    }
}
