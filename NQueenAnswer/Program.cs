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
        /// 座標の組み合わせを生成する。(1行に2個以上クイーンが存在する組は省く。)
        /// </summary>
        private static List<Solution> CreateAllCombinations() {

            var allComb = new List<Solution>();
            var tmpPoints = new Point[N];
            var nextX = new int[N];

            for(int pindex = 1; pindex <= N; pindex++) {
                tmpPoints[pindex - 1] = new Point(1, pindex);
                nextX[pindex - 1] = pindex % N;
            }

            for(int index = 1; index <= (int)Math.Pow(N, N); index++) {

                allComb.Add(new Solution(tmpPoints.ToList()));

                //次に追加する座標の組を生成する。
                var tmpIndex = index;
                var moveCount = 0;
                while(moveCount < N) {
                    tmpPoints[N - moveCount - 1].X = nextX[tmpPoints[N - moveCount - 1].X - 1] + 1;
                    moveCount++;
                    if(tmpIndex % N != 0) {
                        break;
                    }
                    tmpIndex /= N;
                }
            }
            return allComb;
        }

        /// <summary>
        /// 座標の組が条件を満たすか判定する。
        /// </summary>
        /// <param name="solution">座標の組</param>
        /// <returns></returns>
        public static bool IsMatch(Solution solution) {

            //Pointsの中から2つの座標を選んで、適当かどうかチェックする。(N > q > r >= 0)
            var solArray = solution.Points.ToArray();
            for(int former = 1; former <= N - 1; former++) {
                for(int latter = 0; latter < former; latter++) {
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
                for(int row = N; row >= 1; row--) {
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