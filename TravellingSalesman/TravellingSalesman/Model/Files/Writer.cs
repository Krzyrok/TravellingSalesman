
namespace TravellingSalesman
{
    public class Writer
    {
        public Writer()
        {

        }

        public static void WriteInformationsAboutFoundRoute(FoundRoute foundRoute, string fileName)
        {
            fileName += "_route";
            System.IO.StreamWriter file = new System.IO.StreamWriter(fileName);

            file.WriteLine(foundRoute.BestTotalLengthOfRoute);
            file.WriteLine(foundRoute.NumberOfRoutes);
            file.Write("0 ");
            for (int i = 0; i < foundRoute.BestIndexes.Length; i++)
            {
                if ( (i % foundRoute.K == 0) && (i != 0) )
                {
                    file.WriteLine("0 ");
                    file.Write("0 ");
                }
                file.Write(foundRoute.BestIndexes[i] + " ");
            }
            file.Write("0 ");
            file.Close();

        }
    }
}
