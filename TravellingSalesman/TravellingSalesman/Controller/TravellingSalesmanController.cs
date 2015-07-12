using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravellingSalesman
{
    public class TravellingSalesmanController
    {
        private ITravellingSalesmanGui _travellingSalesmanGui;
        private Repository _repository;
        private string _filePath;

        public TravellingSalesmanController(ITravellingSalesmanGui gui)
        {
            _travellingSalesmanGui = gui;
            _repository = new Repository();
            SetEventHandlers();
        }


        private void SetEventHandlers()
        {
            _travellingSalesmanGui.OpenFile += OpenAndReadFile;
            _travellingSalesmanGui.SearchRoutes += SearchRoutes;//SearchRoutes
        }

        private void OpenAndReadFile(object sender, EventArgs e)
        {
            Reader reader = new Reader();
            string[] contentOfFile = reader.ReadCities();

            if (contentOfFile != null)
            {
                _filePath = reader.FilePath;
                _repository.PrepareData(contentOfFile);
                _travellingSalesmanGui.EnableSearchButton();
                _travellingSalesmanGui.UpdateTextBoxesAfterReadingFile(_repository.Cities.Count, _repository.FactorK);
            }       
        }

        private void SearchRoutes(object sender, EventArgs e)
        {
            SearcherOfRoutes searcher = new SearcherOfRoutes(_repository);
            FoundRoute foundRoute = searcher.SearchRoutesInManyPlaces();

            _travellingSalesmanGui.UpdateTextBoxesAfterSearching(foundRoute.BestTotalLengthOfRoute, foundRoute.NumberOfRoutes);

            Writer.WriteInformationsAboutFoundRoute(foundRoute, _filePath);
        }

        private void SearchRoutesInAllFiles(object sender, EventArgs e)
        {                    
            string path = @"C:\Users\Krzyrok\Desktop\VS\2012\SRPP\Dane\basic\";
            for (int j = 1; j <= 5; j++)
            {
                for (int i = 3; i <= 6; i++)
                {
                    RunProcesses(path + j + "00_k=" + i);
                }
            }

            path = @"C:\Users\Krzyrok\Desktop\VS\2012\SRPP\Dane\pro\1000_k=";
            for (int i = 50; i <= 300; i += 50)
            {
                RunProcesses(path + i);
            }
        }

        public void RunProcesses(string path)
        {
            Reader reader = new Reader();
            string[] contentOfFile = reader.ReadCities(path);
            if (contentOfFile != null)
            {
                _repository.PrepareData(contentOfFile);
                SearcherOfRoutes searcher = new SearcherOfRoutes(_repository);
                FoundRoute foundRoute = searcher.SearchRoutesInManyPlaces();
                Writer.WriteInformationsAboutFoundRoute(foundRoute, path);
            }
        }
    }
}
