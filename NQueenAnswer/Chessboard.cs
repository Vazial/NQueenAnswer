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
        public List<Queen> locations;

        public Chessboard(int N) 
        { 
            size = N;
            locations = new List<Queen>();
        }

        public void Mapping(int serialNumber)
        {
            var layout = new Layout(serialNumber);
            locations = layout.Deserialize(size);
        }

        public List<Queen> getLocations()
        {
            if (locations.Count == 0)
            {
                throw new MissingFieldException("locations is Empty. >> call Mapping()");
            }
            return locations;
        }
    }
}
