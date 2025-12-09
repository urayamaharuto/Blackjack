using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Hand
    {
        public List<Card> Card = new List<Card>();


        // 手札にカード追加
        public void AddCard(Card card)
        {
            Card.Add(card);
        }

        // 手札の合計点（A の 11 → 1 に変換も対応）
        public int GetTotal()
        {
            int total = 0;
            int aceCount = 0;

          
            
            foreach (Card c in Card)
            {

                Console.WriteLine($"マーク:{c.mark} 数字:{c.nanba}");
                int v = c.Ten();
                total += v;
                if (c.nanba == 1) aceCount++; // A の数を数える
            }
            Console.WriteLine($"合計:{Player.GetTotal()}");
            // A が 11 で合計が21を超えたら、1として扱う
            while (total > 21 && aceCount > 0)
            {
                total -= 10; // 11 → 1 に変換
                aceCount--;
            }

            return total;

        }
    }
}

