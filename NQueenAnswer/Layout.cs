using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueenAnswer
{
    /// <summary>
    /// チェス盤上のクイーンの位置(配置)を表現するクラス
    /// </summary>
    public class Layout
    {
        // クイーンが配置されていない場合の値
        public static readonly int Empty = -1;

        // クイーンの位置を表現する一意な値
        private readonly int serialNumber;

        /// <summary>
        /// コンストラクタ１
        /// </summary>
        /// <param name="serialNumber">serialNumber</param>
        public Layout(int serialNumber)
        {
            this.serialNumber = serialNumber;
        }

        /// <summary>
        /// コンストラクタ２
        /// </summary>
        /// <param name="locations">クイーンの位置</param>
        /// <param name="cardinalNumber">基数(N)</param>
        public Layout(List<Queen> locations, int cardinalNumber)
        {
            this.serialNumber = Serialize(locations, cardinalNumber);
        }

        /// <summary>
        /// クイーンの位置を表現する一意な値を返す
        /// </summary>
        /// <returns>serialNumber</returns>
        /// <exception cref="MissingFieldException">クイーンが配置されていない場合</exception>
        public int GetSerialNumber()
        {
            if (serialNumber == Empty)
            {
                throw new MissingFieldException("locations is Empty.");
            }
            return serialNumber;
        }

        public List<Queen> Deserialize(int cardinalNumber)
        {
            return Deserialize(GetSerialNumber(), cardinalNumber);
        }

        public bool Equals(Layout layout)
        {
            return (this.GetSerialNumber() == layout.GetSerialNumber());
        }

        /// <summary>
        /// serialNumberをクイーンの位置に変換する
        /// </summary>
        /// <param name="serialNumber">serialNumber</param>
        /// <param name="cardinalNumber">基数N</param>
        /// <returns>クイーンの位置</returns>
        public static List<Queen> Deserialize(int serialNumber, int cardinalNumber)
        {
            var queenLocations = new List<Queen>();

            for (var digits = 0; digits < cardinalNumber; ++digits)
            {
                var gain = (int)Math.Pow(cardinalNumber, digits);
                var xx = (((serialNumber / gain) % cardinalNumber));
                var queen = new Queen(xx, digits);

                queenLocations.Add(queen);
            }
            return queenLocations;
        }

        /// <summary>
        /// クイーンの位置をserialNumberに変換する
        /// </summary>
        /// <param name="locations">クイーンの位置</param>
        /// <param name="cardinalNumber">基数N</param>
        /// <returns></returns>
        public static int Serialize(List<Queen> locations, int cardinalNumber)
        {
            int number = 0;

            foreach (var location in locations)
            {
                var gain = (int)Math.Pow(cardinalNumber, location.y);
                number += (location.x * gain);
            }

            return number;
        }
    }
}
