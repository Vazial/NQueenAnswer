using System.Drawing;
using System.Text;

namespace NQueenAnswer {
    /// <summary>
    /// Nクイーン問題の解を表すクラス
    /// </summary>
    internal class Solution {

        /// <summary>
        /// 解の座標の組
        /// </summary>
        private List<Point> Points { get; set; }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="points">解の座標の組</param>
        public Solution(List<Point>? points) {
            if(points == null) {
                throw new ArgumentNullException(nameof(points), "Points cannot be null.");
            }
            Points = new List<Point>();
            foreach(var point in points) {
                Points.Add(new Point(point.X, point.Y));
            }
        }

        /// <summary>
        /// 座標の組が条件を満たすか判定する。
        /// </summary>
        /// <param name="solution">座標の組</param>
        /// <returns></returns>
        public static bool IsMatch(Solution solution) {

            //座標の個数
            var pointCount = solution.Points.Count;

            //pointsの中から2つの座標を選んで、適当かどうかチェックする。(N >= q > r >= 1)
            var solArray = solution.Points.ToArray();
            for (int q = 1; q <= pointCount - 1; q++) {
                for(int r = 0; r < q; r++) {
                    var diff = q - r;
                    if(solArray[q].X == solArray[r].X           //solArray[r]がsolArray[q]と同じ列にないかチェック
                    || solArray[q].X == solArray[r].X - diff    //solArray[r]がsolArray[q]の左斜め前にないかチェック
                    || solArray[q].X == solArray[r].X + diff    //solArray[r]がsolArray[q]の右斜め前にないかチェック
                    ) {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 全ての解を出力する。
        /// </summary>
        /// <param name="solutions">解の組</param>
        public static void PrintSolution(List<Solution> solutions) {

            //座標の個数
            var N = solutions.First().Points.Count;

            //全ての要素をまとめる。
            var sbAllSolutions = new StringBuilder();

            var count = 1;
            foreach(var solution in solutions) {
                var sbSolution = new StringBuilder(new string('□', N * N));
                foreach(var ele in solution.Points) {
                    //座標の値から'□'を'■'に変更する位置を算出する。
                    var target = ele.X + (ele.Y -1) * N - 1;
                    sbSolution.Remove(target, 1).Insert(target, '■');
                }

                //行末で改行する。
                for(int row = N; row >= 1; row--) {
                    sbSolution.Insert(row * N, '\n');
                }

                //1つの解を末尾に追記する。
                sbAllSolutions.Append(sbSolution.Insert(0, "Solution[" + count + "] : \n").Append('\n'));
                count++;
            }

            //解の個数を表示する。
            sbAllSolutions.Append("Total : " + solutions.Count);

            Console.WriteLine(sbAllSolutions);
        }
    }
}
