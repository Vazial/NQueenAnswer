using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueenAnswer
{
    public class ChessboardDebugPrinter : IChessboardPrintProvider
    {
        public void Print(List<Chessboard> chessboards)
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

        public void Print(Chessboard chessboard)
        {
            var locations = chessboard.getLocations();

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
