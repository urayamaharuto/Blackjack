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

            foreach (Card ten2 in Card)
            {
                Console.WriteLine($"マーク:{ten2.mark} 数字:{ten2.nanba}");
                int v = ten2.Ten();
                total += v;
                if (ten2.nanba == 1) aceCount++; // A の数を数える
            }
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

