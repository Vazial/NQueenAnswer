using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueenAnswer
{
    public static class NQueenGenerator
    {
        public static List<Chessboard> Generate(int nn)
        {
            var numberCombinationsList = new List<Chessboard>();
            var solutionList = new List<Chessboard>();
            var combination = (int)Math.Pow(nn, nn);

            for (var count = 0; count < combination; ++count)
            {
                var chessboard = new Chessboard(nn);
                chessboard.Mapping(count);
                numberCombinationsList.Add(chessboard);
            }

            //適当な配置かどうかチェックする。
            foreach (var numComb in numberCombinationsList)
            {
                if (IsMatch(numComb))
                {
                    solutionList.Add(numComb);
                }
            }

            return solutionList;
        }

        /// <summary>
        /// 座標の組が条件を満たすか判定する。
        /// </summary>
        /// <param name="solution">座標の組</param>
        /// <returns></returns>
        private static bool IsMatch(Chessboard solution)
        {

            //Pointsの中から2つの座標を選んで、適当かどうかチェックする。(N > q > r >= 0)
            var solArray = solution.getLocations().ToArray();
            for (var former = 1; former <= solution.size - 1; former++)
            {
                for (var latter = 0; latter < former; latter++)
                {
                    var diff = former - latter;
                    if (solArray[former].x == solArray[latter].x           //同じ列に存在しないかチェック
                    || solArray[former].x == solArray[latter].x - diff    //左斜め前に存在しないかチェック
                    || solArray[former].x == solArray[latter].x + diff    //右斜め前存在しにないかチェック
                    )
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
