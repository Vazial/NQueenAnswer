using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueenAnswer
{
    public interface IChessboardPrintProvider
    {
        public void PrintAll(List<Chessboard> chessboards);
    }
}
