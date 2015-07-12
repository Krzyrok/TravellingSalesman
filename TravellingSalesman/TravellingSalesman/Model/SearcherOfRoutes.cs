using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{
    public class SearcherOfRoutes
    {
        private Repository _repository;

        public SearcherOfRoutes(Repository repo)
        {
            _repository = repo;
        }

        public FoundRoute SearchRoutes()
        {
            int numberOfCities = _repository.Cities.Count - 1; // without store house
            int k = _repository.FactorK;
            int numberOfRoutes = numberOfCities / k + (numberOfCities % k == 0 ? 0 : 1);
            int[] citiesIndexes = new int[numberOfCities]; //int[] citiesIndexes = new int[numberOfCities + NumberOfRoutes + 1]; <- for second version
            int[] bestIndexes = new int[numberOfCities];
            double bestLength = double.MaxValue;

            FindFinalRouteByTheNearestCities(citiesIndexes, numberOfCities, k);

            for (int loop = 0; loop < 1000000; loop++)
            {
                MutateAndCheckLength(citiesIndexes, k);
            }
            bestLength = CountDistanceWithK(citiesIndexes, k);

            for (int i = 0; i < bestIndexes.Length; i++)
            {
                bestIndexes[i] = citiesIndexes[i];
            }
            //for (int loop = 0; loop < 1000; loop++)
            //{
            //    MutateWithoutCheckingLength(citiesIndexes, k, 100);
            //    double totalDistance = CountDistanceWithK(citiesIndexes, k);
            //    if (totalDistance < bestLength)
            //    {
            //        bestLength = totalDistance;
            //        for (int i = 0; i < bestIndexes.Length; i++)
            //        {
            //            bestIndexes[i] = citiesIndexes[i];
            //        }
            //    }
            //}
            return new FoundRoute(bestLength, bestIndexes, numberOfRoutes, k);
        }

        public FoundRoute SearchRoutesInManyPlaces()
        {
            int numberOfCities = _repository.Cities.Count - 1;
            int k = _repository.FactorK;
            
            List<int[]> listOfRoutesIndexes = new List<int[]>();
            int[] citiesIndexes;

            for (int i = 0; i < 1; i++)
            {
                citiesIndexes = new int[numberOfCities];
                FindFinalRouteByTheNearestCities(citiesIndexes, numberOfCities, k);
                listOfRoutesIndexes.Add(citiesIndexes);
            }
            for (int i = 0; i < 1; i++)
            {
                citiesIndexes = new int[numberOfCities];
                FindFinalRouteByTheNearestCitiesHavingReturnsToStorehouse(citiesIndexes, numberOfCities, k);
                listOfRoutesIndexes.Add(citiesIndexes);
            }
            for (int i = 0; i < 1000; i++)
            {
                citiesIndexes = new int[numberOfCities];
                FindFinalRouteRandomWithoutStorehouse(citiesIndexes, numberOfCities);
                listOfRoutesIndexes.Add(citiesIndexes);
            }

            // transforms
            List<FoundRoute> listOfResults = new List<FoundRoute>();
            List<FoundRoute> allResults = new List<FoundRoute>();
            foreach(int[]indexes in listOfRoutesIndexes)
            {
                allResults.Add(SearchRoute(indexes, 5000));
            }
            for (int j = 0; j < 100; j++)
            {
                double minLentgh = double.MaxValue;
                int indexOfMinLength = 0;
                for (int i = 0; i < allResults.Count; i++)
                {
                    if (allResults[i].BestTotalLengthOfRoute < minLentgh)
                    {
                        minLentgh = allResults[i].BestTotalLengthOfRoute;
                        indexOfMinLength = i;
                    }
                }
                listOfResults.Add(allResults[indexOfMinLength]);
                allResults.RemoveAt(indexOfMinLength);
            }

            allResults = new List<FoundRoute>();
            foreach (FoundRoute route in listOfResults)
            {
                allResults.Add(SearchRoute(route.BestIndexes, 10000));
            }
            listOfResults = new List<FoundRoute>();
            for (int j = 0; j < 10; j++)
            {
                double minLentgh = double.MaxValue;
                int indexOfMinLength = 0;
                for (int i = 0; i < allResults.Count; i++)
                {
                    if (allResults[i].BestTotalLengthOfRoute < minLentgh)
                    {
                        minLentgh = allResults[i].BestTotalLengthOfRoute;
                        indexOfMinLength = i;
                    }
                }
                listOfResults.Add(allResults[indexOfMinLength]);
                allResults.RemoveAt(indexOfMinLength);
            }
            

            allResults = new List<FoundRoute>();
            foreach (FoundRoute route in listOfResults)
            {
                allResults.Add(SearchRoute(route.BestIndexes, 10000));
            }
            listOfResults = new List<FoundRoute>();
            for (int j = 0; j < 1; j++)
            {
                double minLentgh = double.MaxValue;
                int indexOfMinLength = 0;
                for (int i = 0; i < allResults.Count; i++)
                {
                    if (allResults[i].BestTotalLengthOfRoute < minLentgh)
                    {
                        minLentgh = allResults[i].BestTotalLengthOfRoute;
                        indexOfMinLength = i;
                    }
                }
                listOfResults.Add(allResults[indexOfMinLength]);
                allResults.RemoveAt(indexOfMinLength);
            }

            return listOfResults[0];
        }

        private FoundRoute SearchRoute(int[] citiesIndexes, int howMany)
        {
            int numberOfCities = _repository.Cities.Count - 1; // without store house
            int k = _repository.FactorK;
            int numberOfRoutes = numberOfCities / k + (numberOfCities % k == 0 ? 0 : 1);
            int[] bestIndexes = new int[numberOfCities];
            double bestLength = double.MaxValue;

            bestLength = CountDistanceWithK(citiesIndexes, k);

            for (int i = 0; i < bestIndexes.Length; i++)
            {
                bestIndexes[i] = citiesIndexes[i];
            }
            for (int loop = 0; loop < 100; loop++)
            {
                MutateWithoutCheckingLength(citiesIndexes, k, 10);
                double totalDistance = CountDistanceWithK(citiesIndexes, k);
                if (totalDistance < bestLength)
                {
                    bestLength = totalDistance;
                    for (int i = 0; i < bestIndexes.Length; i++)
                    {
                        bestIndexes[i] = citiesIndexes[i];
                    }
                }
            }

            for (int loop = 0; loop < howMany; loop++)
            {
                MutateAndCheckLength(citiesIndexes, k);
            }

            double actualDistance = CountDistanceWithK(citiesIndexes, k);
            if (actualDistance < bestLength)
            {
                bestLength = actualDistance;
                for (int i = 0; i < bestIndexes.Length; i++)
                {
                    bestIndexes[i] = citiesIndexes[i];
                }
            }
            
            for (int loop = 0; loop < 100; loop++)
            {
                MutateWithoutCheckingLength(citiesIndexes, k, 10);
                double totalDistance = CountDistanceWithK(citiesIndexes, k);
                if (totalDistance < bestLength)
                {
                    bestLength = totalDistance;
                    for (int i = 0; i < bestIndexes.Length; i++)
                    {
                        bestIndexes[i] = citiesIndexes[i];
                    }
                }
            }

            return new FoundRoute(bestLength, bestIndexes, numberOfRoutes, k);
        }

        private void MutateAndCheckLength(int[] indexes, int k)
        {
            int size = indexes.Length;
            if (size - 1 <= 1)
            {
                return;
            }

            Random random = new Random();
            int firstIndex = random.Next(1, size - 1);
            int secondIndex = random.Next(1, size - 1);

            double originalLength = ShortLength(firstIndex, secondIndex, indexes, k);
            int buffor = indexes[firstIndex];
            indexes[firstIndex] = indexes[secondIndex];
            indexes[secondIndex] = buffor;

            double newLength = ShortLength(firstIndex, secondIndex, indexes, k);

            if (newLength > originalLength)
            {
                buffor = indexes[firstIndex];
                indexes[firstIndex] = indexes[secondIndex];
                indexes[secondIndex] = buffor;
            }
        }

        private void MutateWithoutCheckingLength(int[] indexes, int k, int howMany)
        {
            int size = indexes.Length;

            Random random = new Random();
            for (int i = 0; i < howMany; i++)
            {
                int firstIndex = random.Next(0, size );
                int secondIndex = random.Next(0, size);

                int buffor = indexes[firstIndex];
                indexes[firstIndex] = indexes[secondIndex];
                indexes[secondIndex] = buffor;
            }
        }

        private double ShortLength(int index1, int index2, int[] indexes, int k)
        {
            double length = 0;
            if (index1 % k == 0)
            {
                length = DistanceBetweenTwoCities(_repository.Cities[0], _repository.Cities[indexes[index1]]);
                length += DistanceBetweenTwoCities(_repository.Cities[indexes[index1]], _repository.Cities[indexes[index1 + 1]]);
            }
            else if ((index1 + 1) % k == 0)
            {
                length = DistanceBetweenTwoCities(_repository.Cities[indexes[index1 - 1]], _repository.Cities[indexes[index1]]);
                length += DistanceBetweenTwoCities(_repository.Cities[indexes[index1]], _repository.Cities[0]);
            }
            else
            {
                length = DistanceBetweenTwoCities(_repository.Cities[indexes[index1 - 1]], _repository.Cities[indexes[index1]]);
                length += DistanceBetweenTwoCities(_repository.Cities[indexes[index1]], _repository.Cities[indexes[index1 + 1]]);
            }

            if (index2 % k == 0)
            {
                length += DistanceBetweenTwoCities(_repository.Cities[0], _repository.Cities[indexes[index2]]);
                length += DistanceBetweenTwoCities(_repository.Cities[indexes[index2]], _repository.Cities[indexes[index2 + 1]]);
            }
            else if ((index2 + 1) % k == 0)
            {
                length += DistanceBetweenTwoCities(_repository.Cities[indexes[index2 - 1]], _repository.Cities[indexes[index2]]);
                length += DistanceBetweenTwoCities(_repository.Cities[indexes[index2]], _repository.Cities[0]);
            }
            else
            {
                length += DistanceBetweenTwoCities(_repository.Cities[indexes[index2 - 1]], _repository.Cities[indexes[index2]]);
                length += DistanceBetweenTwoCities(_repository.Cities[indexes[index2]], _repository.Cities[indexes[index2 + 1]]);
            }

            return length;
        }

        private void FindFinalRouteByTheNearestCities(int[] indexes, int numberOfCities, int k)
        {
            for (int i = 0; i < numberOfCities; i++)
            {
                indexes[i] = i + 1;
            }

            Position actualCity = _repository.Cities[0];

            for (int i = 0; i < numberOfCities - 1; i++)
            {
                if ((i % k == 0) && (i != 0))
                {
                    actualCity = _repository.Cities[0];
                }
                int bestIndex = 0;
                double bestLength = double.MaxValue;
                for (int j = i; j < numberOfCities; j++)
                {
                    Position checkingCity = _repository.Cities[indexes[j]];
                    double actualLength = DistanceBetweenTwoCities(actualCity, checkingCity);
                    if (actualLength < bestLength)
                    {
                        bestIndex = j;
                        bestLength = actualLength;
                    }
                }
                

                int buffor = indexes[i];
                indexes[i] = indexes[bestIndex];
                indexes[bestIndex] = buffor;
                actualCity = _repository.Cities[indexes[i]];
            }
        }

        private void FindFinalRouteByTheNearestCitiesHavingReturnsToStorehouse(int[] indexes, int numberOfCities, int k)
        {
            for (int i = 0; i < numberOfCities; i++)
            {
                indexes[i] = i + 1;
            }

            Position actualCity = _repository.Cities[0];

            for (int i = 0; i < numberOfCities - 1; i++)
            {
                if ((i % k == 0) && (i != 0))
                {
                    actualCity = _repository.Cities[0];
                }
                int bestIndex = 0;
                double bestLength = double.MaxValue;
                if ((i + 1) % k == 0)
                {
                    for (int j = i; j < numberOfCities; j++)
                    {
                        Position checkingCity = _repository.Cities[indexes[j]];
                        double actualLength = DistanceBetweenTwoCities(actualCity, checkingCity);
                        actualLength += DistanceBetweenTwoCities(checkingCity, _repository.Cities[0]);
                        if (actualLength < bestLength)
                        {
                            bestIndex = j;
                            bestLength = actualLength;
                        }
                    }
                }
                else
                {
                    for (int j = i; j < numberOfCities; j++)
                    {
                        Position checkingCity = _repository.Cities[indexes[j]];
                        double actualLength = DistanceBetweenTwoCities(actualCity, checkingCity);
                        if (actualLength < bestLength)
                        {
                            bestIndex = j;
                            bestLength = actualLength;
                        }
                    }
                }


                int buffor = indexes[i];
                indexes[i] = indexes[bestIndex];
                indexes[bestIndex] = buffor;
                actualCity = _repository.Cities[indexes[i]];
            }
        }

        public void FindFinalRouteRandomWithoutStorehouse(int[] indexes, int numberOfCities)
        {
            for (int i = 0; i < numberOfCities; i++)
            {
                indexes[i] = i + 1;
            }

            Random rand = new Random();
            for (int i = numberOfCities - 1; i > 0; i--)
            {
                int index = rand.Next(0, i + 1);
                int tmp = indexes[i];
                indexes[i] = indexes[index];
                indexes[index] = tmp;
            }
        }



        private double CountDistanceWithK(int[] citiesIndexes, int k)
        {
            Position lastCity = _repository.Cities[0];
            double length = 0;
            int numberOfCities = _repository.Cities.Count - 1;
            for (int i = 0; i < numberOfCities; i++)
            {
                Position actualCity;
                if (i % k == 0 && i != 0)
                {
                    actualCity = _repository.Cities[0];
                    length += DistanceBetweenTwoCities(lastCity, actualCity);
                    lastCity = actualCity;
                }
                int index = citiesIndexes[i];
                actualCity = _repository.Cities[index];
                length += DistanceBetweenTwoCities(actualCity, lastCity);

                lastCity = actualCity;
            }
            Position storeHouse = _repository.Cities[0];
            length += DistanceBetweenTwoCities(lastCity, storeHouse);
            return length;
        }

        private double DistanceBetweenTwoCities(Position city1, Position city2)
        {
            return Math.Sqrt(Math.Pow((city2.X - city1.X), 2) + Math.Pow((city2.Y - city1.Y), 2));
        }

        //public void FindFinalRouteRandom(int[] indexes, int numberOfCities, int k)
        //{
        //    int[] tmpArray = new int[numberOfCities];
        //    for (int i = 0; i < numberOfCities; i++)
        //    {
        //        tmpArray[i] = i + 1;
        //    }

        //    Random rand = new Random();
        //    int indexOfCurrentCity = 0;
        //    bool wasStorehouse = false;
        //    for (int i = 0; i < indexes.Length; i++)
        //    {
        //        if ((indexOfCurrentCity % k != 0 || wasStorehouse) && (numberOfCities != indexOfCurrentCity))
        //        {
        //            int index = rand.Next(0, numberOfCities - indexOfCurrentCity);
        //            indexes[i] = tmpArray[index];
        //            tmpArray[index] = tmpArray[numberOfCities - indexOfCurrentCity - 1];
        //            indexOfCurrentCity++;
        //            wasStorehouse = false;
        //        }
        //        else
        //        {
        //            indexes[i] = 0;
        //            wasStorehouse = true;
        //        }

        //    }
        //}

        //private double CountDistance(int[] citiesIndexes)
        //{
        //    Position lastCity = _repository.Cities[citiesIndexes[0]]; // always should be cities[0]
        //    double length = 0;
        //    for (int i = 1; i < citiesIndexes.Length; i++)
        //    {
        //        int index = citiesIndexes[i];
        //        Position actualCity = _repository.Cities[index];
        //        length += DistanceBetweenTwoCities(actualCity, lastCity);

        //        lastCity = actualCity;
        //    }

        //    return length;
        //}
    }
}
