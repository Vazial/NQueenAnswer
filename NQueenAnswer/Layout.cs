using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueenAnswer
{
    public class Layout
    {
        public int serialNumber {  get; private set; }

        public Layout(int serialNumber)
        {
            this.serialNumber = serialNumber;
        }

        public List<Queen> Deserialize(int cardinalNumber)
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
    }
}
