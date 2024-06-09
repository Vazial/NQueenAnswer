using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueenAnswer
{
    /// <summary>
    /// チェス盤を表現するクラス
    /// </summary>
    public class Chessboard
    {
        // 大きさ(縦横)
        public int size { get; private set; }
        // クイーンの位置
        public Layout layout {  get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="N">チェス盤のサイズ</param>
        public Chessboard(int N) 
        { 
            size = N;
            layout = new Layout(Layout.Empty);
        }

        /// <summary>
        /// チェス盤にクイーンの位置を設定する
        /// </summary>
        /// <param name="serialNumber">serialNumber(クイーンの位置を表現する一意な値)</param>
        public void Mapping(int serialNumber)
        {
            layout = new Layout(serialNumber);
        }

        /// <summary>
        /// チェス盤からクイーンの位置を取得する
        /// </summary>
        /// <returns>クイーンの位置</returns>
        public List<Queen> GetLocations()
        {
            return layout.Deserialize(size);
        }

        /// <summary>
        /// チェス盤を右に90度回転する
        /// </summary>
        public void RotateRight()
        {
            var newLocations = new List<Queen>();

            foreach (var location in layout.Deserialize(size))
            {
                var newLocation = new Queen(size - (location.y + 1), location.x);
                newLocations.Add(newLocation);
            }

            layout = new Layout(newLocations, size);
        }

        /// <summary>
        /// チェス盤を左右反転する
        /// </summary>
        public void InvertMirror()
        {
            var newLocations = new List<Queen>();

            foreach (var location in layout.Deserialize(size))
            {
                var newLocation = new Queen(size - (location.x + 1), location.y);
                newLocations.Add(newLocation);
            }

            layout = new Layout(newLocations, size);
        }

        public bool Equals(Chessboard chessboard)
        {
            return (size == chessboard.size && layout.Equals(chessboard.layout));
        }

        public Chessboard Copy()
        {
            var copyChessboard = new Chessboard(size);
            copyChessboard.Mapping(layout.GetSerialNumber());
            return copyChessboard;
        }
    }
}
