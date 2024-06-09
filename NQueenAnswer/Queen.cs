using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueenAnswer
{
    /// <summary>
    /// チェス盤上のクイーンを表現するクラス
    /// </summary>
    public class Queen
    {
        // 座標
        public int x { get; private set; }
        public int y { get; private set; }

        public Queen(int xx, int yy)
        {
            this.x = xx;
            this.y = yy;
        }
    }
}
