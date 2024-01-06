using System.Diagnostics;
using System.Text;

public class Program {
    //N=4 → 2, N=5 → 10, N=6 → 4, N=7 → 40, N=8 → 92
    //N=6 1.782s → 0.031s

    const int N = 5;                                                //クイーンの個数

    static List<int[]> numberCombinationsList = new List<int[]>();  //N個の数の組み合わせリスト
    static List<int[]> solutionList = new List<int[]>();            //解のリスト


    static void Main() {
        var sw = new Stopwatch();
        sw.Start();

        Console.WriteLine("N = " + N + "のときのクイーンの配置");

        for(int n = 1; n <= N; n++) { 
            var array = new int[N];
            array[0] = n;
            CreateCombination(array, 1);
        }

        for(int combCount = 1; combCount < numberCombinationsList.Count; combCount++) {
            if(IsSettable(numberCombinationsList[combCount])) {
                solutionList.Add(numberCombinationsList[combCount]);
            }
        }

        PrintQueens(solutionList);

        sw.Stop();

        Console.WriteLine("経過時間: " + sw.Elapsed.ToString("hh':'mm':'ss'.'fff"));
    }

    //数の組み合わせを生成する。(1行に2個以上クイーンが存在する組は省く。)
    private static void CreateCombination(int[] tmpNums, int numCount) {
        for(int k = numCount * N + 1; k <= (numCount + 1) * N; k++) {
            tmpNums[numCount] = k;
            if(numCount == N - 1) {
                var nums = tmpNums.ToArray();
                numberCombinationsList.Add(nums);
            } else {
                CreateCombination(tmpNums, numCount + 1);
            }
        }
    }

    //Nクイーンの配置として、適切かどうか判定する。
    private static bool IsSettable(int[] comb) {

        //p番目のクイーンが、何列目にあるかを保持する。
        var points = new Dictionary<int, int>();

        //q行目のクイーンを"Q"、r行目のクイーンを"R"とする。
        //"Q"、"R"(q < r)を選択し、"R"が"Q"と同じ列にないか、"R"の左斜め前、右斜め前に"Q"がないかを判定する。
        for(int q = 1; q <= N; q++) {
            points.Add(q, comb[q - 1] % N > 0 ? comb[q - 1] % N : N);
            for(int r = 1; r < q; r++) {
                if(points[r] == points[q]
                    || comb[q - 1] - comb[r - 1] == (q - r) * (N + 1)
                    || comb[q - 1] - comb[r - 1] == (q - r) * (N - 1)) {
                    return false;
                }
            }
        }

        return true;
    }

    //求めた配置を出力する。
    private static void PrintQueens(List<int[]> solutions) {

        var sbAllSolutions = new StringBuilder();

        for(var solutionIndex = 1; solutionIndex <= solutions.Count; solutionIndex++) {
            var sbSolution = new StringBuilder(new string('□', N * N));

            var tmpSolution = solutions[solutionIndex - 1];
            for(var queenIndex = 1; queenIndex <= N; queenIndex++) {
                sbSolution.Remove(tmpSolution[queenIndex - 1] - 1, 1).Insert(tmpSolution[queenIndex - 1] - 1, '■');
            }

            for(var column = N; column >= 1; column--) {
                sbSolution.Insert(column * N, '\n');
            }

            sbAllSolutions.Append(sbSolution.Insert(0, "Solution[" + solutionIndex + "] : \n").Append('\n'));
        }
        sbAllSolutions.Append("Total : " + solutionList.Count); //解の個数を表示

        Console.WriteLine(sbAllSolutions);
    }
}