using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{
    public class Repository
    {
        public List<Position> Cities { get; private set; }
        public int FactorK { get; private set; }

        public Repository()
        {
        }

        public void PrepareData(string[] cities)
        {
            List<Position> citiesFromFile = new List<Position>();

            foreach (string oneLine in cities)
            {
                string[] positions = oneLine.Split(' ');
                if (positions.Length == 2)              
                {
                    positions[0] = positions[0].Trim();
                    positions[1] = positions[1].Trim();
                    int xPosition = Convert.ToInt32(positions[0]);
                    int yPosition = Convert.ToInt32(positions[1]);
                    Position citie = new Position(xPosition, yPosition);
                    citiesFromFile.Add(citie);
                }
                else if (positions.Length == 1)
                {
                    positions[0] = positions[0].Trim();
                    int k = Convert.ToInt32(positions[0]);
                    FactorK = k;
                }
            }

            Cities = citiesFromFile;
        }

    }
}
