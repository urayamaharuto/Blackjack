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
            //ランダム関数
            Random random = new Random();

            Deck deck = new Deck();
            //これでドローができる
            //カードの中のカードにデッキのドローの
            //ランダムな数字のところを入れている
            Card card = deck.Draw(random.Next(52));
            //cardの中に入ってるmarkとnanbaを入れている
            Console.WriteLine($"マーク:{card.mark} 数字:{card.nanba}");
            card = deck.Draw(random.Next(52));
            //cardの中に入ってるmarkとnanbaを入れている
            Console.WriteLine($"マーク:{card.mark} 数字:{card.nanba}"); card = deck.Draw(random.Next(52));
            //cardの中に入ってるmarkとnanbaを入れている
            Console.WriteLine($"マーク:{card.mark} 数字:{card.nanba}"); card = deck.Draw(random.Next(52));
            //cardの中に入ってるmarkとnanbaを入れている
            Console.WriteLine($"マーク:{card.mark} 数字:{card.nanba}"); card = deck.Draw(random.Next(52));
            //cardの中に入ってるmarkとnanbaを入れている
            Console.WriteLine($"マーク:{card.mark} 数字:{card.nanba}"); card = deck.Draw(random.Next(52));
            //cardの中に入ってるmarkとnanbaを入れている
            Console.WriteLine($"マーク:{card.mark} 数字:{card.nanba}"); card = deck.Draw(random.Next(52));
            //cardの中に入ってるmarkとnanbaを入れている
            Console.WriteLine($"マーク:{card.mark} 数字:{card.nanba}"); card = deck.Draw(random.Next(52));
            //cardの中に入ってるmarkとnanbaを入れている
            Console.WriteLine($"マーク:{card.mark} 数字:{card.nanba}"); card = deck.Draw(random.Next(52));
            //cardの中に入ってるmarkとnanbaを入れている
            Console.WriteLine($"マーク:{card.mark} 数字:{card.nanba}");
        }
    }
}
