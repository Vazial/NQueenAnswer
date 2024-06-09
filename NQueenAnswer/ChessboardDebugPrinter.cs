using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueenAnswer
{
    /// <summary>
    /// NQueenの解をデバッグ出力するサービスクラス
    /// </summary>
    public static class ChessboardDebugPrinter
    {
        public static void PrintAll(List<Chessboard> chessboards)
        {
            //解の個数を表示する。
            Console.WriteLine("Total : " + chessboards.Count);

            for (int count = 0; count < chessboards.Count; count++)
            {
                Console.WriteLine();
                Console.WriteLine("Solution[" + (count + 1) + "] : ");
                Print(chessboards[count]);

            }
        }

        public static void Print(Chessboard chessboard)
        {
            var locations = chessboard.GetLocations();

            foreach (var location in locations)
            {
                for(int xx = 0; xx < locations.Count; xx++) 
                {
                    if (location.x == xx) 
                    {
                        Console.Write('■');
                    }
                    else
                    {
                        Console.Write('□');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
