using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Dealer
    {
        //　ハンドの方にあったやつリストの名前だけ変えてパクった
        public List<Card> D_Card = new List<Card>();

        // 手札にカード追加
        public void AddCard(Card card)
        {
            D_Card.Add(card);
        }

        // 手札の合計点（A の 11 → 1 に変換も対応）
        public int GetTotal()
        {
            int D_total = 0;
            int aceCount = 0;

            foreach (Card ten2 in D_Card)
            {
                Console.WriteLine($"マーク:{ten2.mark} 数字:{ten2.nanba}");
                int v = ten2.Ten();
                D_total += v;
                if (ten2.nanba == 1) aceCount++; // A の数を数える
            }
            // A が 11 で合計が21を超えたら、1として扱う
            while (D_total > 21 && aceCount > 0)
            {
                D_total -= 10; // 11 → 1 に変換
                aceCount--;
            }
            return D_total;
        }
    }
}
