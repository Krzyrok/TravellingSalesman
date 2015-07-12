using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{
    public class FoundRoute
    {
        public double BestTotalLengthOfRoute { get; private set; }
        public int[] BestIndexes { get; private set; }
        public int NumberOfRoutes { get; private set; }
        public int K { get; private set; }

        public FoundRoute(double totalLength, int[] indexes, int numberOfRoutes, int k)
        {
            BestTotalLengthOfRoute = totalLength;
            BestIndexes = indexes;
            NumberOfRoutes = numberOfRoutes;
            K = k;
        }
    }
}
