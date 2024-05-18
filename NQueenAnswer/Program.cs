using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace NQueenAnswer {

    /// <summary>
    /// メイン処理を行うクラス
    /// </summary>
    public class Program {
        //解の個数
        //N=4 → 2, N=5 → 10, N=6 → 4, N=7 → 40, N=8 → 92

        //クイーンの個数
        const int N = 5;

        //解のリスト
        static List<Solution> solutionList = new();

        static void Main() {
            var sw = new Stopwatch();
            sw.Start();

            Console.WriteLine("N = " + N + "のときのクイーンの配置");

            //全ての座標の組合わせを生成する。
            var numberCombinationsList = CreateAllCombinations();

            //適当な配置かどうかチェックする。
            foreach(var numComb in numberCombinationsList) {
                if(IsMatch(numComb)) {
                    solutionList.Add(numComb);
                }
            }

            //解を出力する。
            PrintSolution(solutionList);

            sw.Stop();

            Console.WriteLine("経過時間: " + sw.Elapsed.ToString("hh':'mm':'ss'.'fff"));
        }

        /// <summary>
        /// 全ての座標の組み合わせを生成する。(1行に2個以上クイーンが存在する組は省く。)
        /// </summary>
        private static List<Solution> CreateAllCombinations() {

            var allCombs = new List<Solution>();
            var disit = new int[N];
            var tmpPoints = new Point[N];

            for (var ii = 0; ii < (int)Math.Pow(N, N); ++ii){
                for (var tmpRow = 1; tmpRow <= N; tmpRow++){
                    disit[tmpRow - 1] = (ii / (int)Math.Pow(N, N - tmpRow) % N) + 1;
                    tmpPoints[tmpRow - 1].X = disit[tmpRow - 1];
                    tmpPoints[tmpRow - 1].Y = tmpRow;
                }
                allCombs.Add(new Solution(tmpPoints.ToList()));
            }
            
            return allCombs;
        }

        /// <summary>
        /// 座標の組が条件を満たすか判定する。
        /// </summary>
        /// <param name="solution">座標の組</param>
        /// <returns></returns>
        public static bool IsMatch(Solution solution) {

            //Pointsの中から2つの座標を選んで、適当かどうかチェックする。(N > q > r >= 0)
            var solArray = solution.Points.ToArray();
            for(var former = 1; former <= N - 1; former++) {
                for(var latter = 0; latter < former; latter++) {
                    var diff = former - latter;
                    if(solArray[former].X == solArray[latter].X           //同じ列に存在しないかチェック
                    || solArray[former].X == solArray[latter].X - diff    //左斜め前に存在しないかチェック
                    || solArray[former].X == solArray[latter].X + diff    //右斜め前存在しにないかチェック
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

            //全ての要素をまとめる。
            var sbAllSolutions = new StringBuilder();

            var solIndex = 1;
            foreach(var solution in solutions) {
                var sbSolution = new StringBuilder(new string('□', N * N));

                var tmpRow = 1;
                foreach(var point in solution.Points) {
                    //座標の値から,、'□'を'■'に変更する位置を算出する。
                    var target = (tmpRow - 1) * N + point.X - 1;
                    sbSolution.Remove(target, 1).Insert(target, '■');
                    tmpRow++;
                }

                //行末で改行する。
                for(var row = N; row >= 1; row--) {
                    sbSolution.Insert(row * N, '\n');
                }

                //1つの解を末尾に追記する。
                sbAllSolutions.Append(sbSolution.Insert(0, "Solution[" + solIndex + "] : \n").Append('\n'));
                solIndex++;
            }

            //解の個数を表示する。
            sbAllSolutions.Append("Total : " + solutions.Count);

            Console.WriteLine(sbAllSolutions);
        }
    }
}