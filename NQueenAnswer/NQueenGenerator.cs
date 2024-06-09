using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueenAnswer
{
    /// <summary>
    /// NQueenの解を生成するサービスクラス
    /// </summary>
    public static class NQueenGenerator
    {
        /// <summary>
        /// NQueenの解となる座標を生成する
        /// </summary>
        /// <param name="nn">N</param>
        /// <returns>NQueenの解のリスト</returns>
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
        /// NQueenの解として適切であるか判定する。
        /// </summary>
        /// <param name="solution">NQueen座標の組</param>
        /// <returns>NQueenの解として適切であればtrue</returns>
        private static bool IsMatch(Chessboard solution)
        {

            //Pointsの中から2つの座標を選んで、適当かどうかチェックする。(N > q > r >= 0)
            var solArray = solution.GetLocations().ToArray();
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

        /// <summary>
        /// NQueenの解から重複を削除する（回転・反転で一致するもの）
        /// </summary>
        /// <param name="solutionList">NQueenの解のリスト</param>
        /// <returns>重複を削除したNQueenの解のリスト</returns>
        public static List<Chessboard> DeleteDuplicate(List<Chessboard> solutionList)
        {
            var checkedSolutions = new List<Chessboard>();

            foreach (var solution2 in solutionList)
            {
                var isDuplicate = false;
                foreach (var solution1 in checkedSolutions)
                {
                    if (IsEqual(solution1, solution2))
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (isDuplicate == false)
                {
                    checkedSolutions.Add(solution2);
                }
            }
            return checkedSolutions;
        }

        /// <summary>
        /// NQueenの解を回転・反転させ、一致しているか判定する
        /// </summary>
        /// <param name="solution1">比較される解</param>
        /// <param name="solution2">比較する解</param>
        /// <returns>一致しているかどうか</returns>
        private static bool IsEqual(Chessboard solution1, Chessboard solution2)
        {
            // 上下左右
            const int Direction = 4;

            var rotateSolution = solution2.Copy();

            for (int direction = 0; direction < Direction; ++direction)
            {
                rotateSolution.RotateRight();
                if (solution1.Equals(rotateSolution))
                {
                    return true;
                }

                var invertSolution = rotateSolution.Copy();
                invertSolution.InvertMirror();
                if (solution1.Equals(invertSolution))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
