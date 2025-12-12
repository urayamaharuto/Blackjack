using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {
        //新しい関数を作るやつ enum
        //関数Markにトランプのマークを入れている
        public enum Mark
        {
            heart,
            diamond,
            spade,
            clover,
        }
        //みんなで使える関数をここで作ってる
        public Mark mark;
        public int nanba = 0;
        public int ten = 0;

        //デッキのトランプカードを作るときに参照するところ
        //例えばデッキの方でspade　5になったらそれがマークとナンバに入る
        public Card(Mark _mark, int _nanba)
        {
            mark = _mark;
            nanba = _nanba;
        }
        public int Ten() 
        {
            ten = nanba;
            //エースの時
            if(ten == 1)
            {
                ten = 11;
            }
            //ジャック、クイーン、キング
            else if (ten > 10)
            {
                ten = 10;
            }
            return ten;
        }
    }
}

