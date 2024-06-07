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

        static void Main()
        {
            var sw = new Stopwatch();
            sw.Start();

            Console.WriteLine("N = " + N + "のときのクイーンの配置");

            //全ての座標の組合わせを生成する。
            var solutionList = NQueenGenerator.Generate(N);

            //解を出力する。
            new ChessboardDebugPrinter().PrintAll(solutionList);

            sw.Stop();

            Console.WriteLine("経過時間: " + sw.Elapsed.ToString("hh':'mm':'ss'.'fff"));
        }
    }
}