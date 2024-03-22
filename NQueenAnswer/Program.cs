using System.Diagnostics;
using System.Drawing;

namespace NQueenAnswer {

    /// <summary>
    /// メイン処理を行うクラス
    /// </summary>
    public class Program {
        //N=4 → 2, N=5 → 10, N=6 → 4, N=7 → 40, N=8 → 92

        const int N = 4;                                                //クイーンの個数

        static List<Solution> numberCombinationsList = new();  //N個の座標の組み合わせリスト
        static List<Solution> solutionList = new();            //解のリスト

        static void Main() {

            var sw = new Stopwatch();
            sw.Start();

            Console.WriteLine("N = " + N + "のときのクイーンの配置");

            //全ての座標の組合わせを生成する。
            CreateAllCombination(new List<Point>(), 1);

            //適当な配置かどうかチェックする。
            foreach(var numComb in numberCombinationsList) {
                if(Solution.IsMatch(numComb)) {
                    solutionList.Add(numComb);
                }
            }

            //解を出力する。
            Solution.PrintSolution(solutionList);

            sw.Stop();

            Console.WriteLine("経過時間: " + sw.Elapsed.ToString("hh':'mm':'ss'.'fff"));
        }

        /// <summary>
        /// 数の組み合わせを生成する。(1行に2個以上クイーンが存在する組は省く。)
        /// </summary>
        /// <param name="tmpPoints">現在の座標の組</param>
        /// <param name="rowCount">現在作成する座標のyの値</param>
        private static void CreateAllCombination(List<Point> tmpPoints, int rowCount) {
            for(int row = 1; row <= N; row++) {
                tmpPoints.Add(new Point(row, rowCount));
                if(rowCount == N) {
                    var copiedPoints = new Solution(CopyList(tmpPoints));
                    numberCombinationsList.Add(copiedPoints);
                } else {
                    //rowCountがNになるまで呼び出す。
                    CreateAllCombination(tmpPoints, rowCount + 1);
                }
                tmpPoints.Remove(tmpPoints.Find(p => p.Y == rowCount));
            }
        }

        /// <summary>
        /// Listの中身のみをコピーする。
        /// </summary>
        /// <param name="list">コピーするList</param>
        /// <returns>コピーしたList</returns>
        private static List<Point> CopyList(List<Point> list) {
            var cList = new List<Point>();
            foreach(var element in list) {
                cList.Add(new Point(element.X, element.Y));
            }
            return cList;
        }
    }
}