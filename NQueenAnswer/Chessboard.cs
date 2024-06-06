using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueenAnswer
{
    public class Chessboard
    {
        public int size { get; private set; }
        public Layout layout {  get; private set; }

        public Chessboard(int N) 
        { 
            size = N;
            layout = new Layout(Layout.Empty);
        }

        public void Mapping(int serialNumber)
        {
            layout = new Layout(serialNumber);
        }

        public List<Queen> getLocations()
        {
            return layout.Deserialize(size);
        }

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
    }
}
