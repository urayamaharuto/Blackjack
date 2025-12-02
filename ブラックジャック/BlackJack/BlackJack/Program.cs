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
            //これでドローができる
            //カードの中のカードにデッキのドローの
            //ランダムな数字のところを入れている
           Random random = new Random();

            Hand plsyer = new Hand();
            
            Card card = deck.Draw();
            //cardの中に入ってるmarkとnanbaを入れている
            Console.WriteLine($"マーク:{card.mark} 数字:{card.nanba}");
            card = deck.Draw();
            //cardの中に入ってるmarkとnanbaを入れている
            Console.WriteLine($"マーク:{card.mark} 数字:{card.nanba}");

        }

    }
}
