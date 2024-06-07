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
        public static readonly int Empty = -1;

        private readonly int serialNumber;

        public Layout(int serialNumber)
        {
            this.serialNumber = serialNumber;
        }

        public Layout(List<Queen> locations, int cardinalNumber)
        {
            this.serialNumber = Serialize(locations, cardinalNumber);
        }

        public int getSerialNumber()
        {
            if (serialNumber == Empty)
            {
                throw new MissingFieldException("locations is Empty.");
            }
            return serialNumber;
        }

        public List<Queen> Deserialize(int cardinalNumber)
        {
            return Deserialize(getSerialNumber(), cardinalNumber);
        }

        public bool Equals(Layout layout)
        {
            return (this.getSerialNumber() == layout.getSerialNumber());
        }

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
