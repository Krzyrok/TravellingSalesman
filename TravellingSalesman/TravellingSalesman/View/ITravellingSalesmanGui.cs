using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{
    public interface ITravellingSalesmanGui
    {
        void EnableSearchButton();
        void UpdateTextBoxesAfterReadingFile(int numberOfCities, int k);
        void UpdateTextBoxesAfterSearching(double length, int numberOfRoutes);
        event EventHandler OpenFile;
        event EventHandler SearchRoutes;
    }
}
