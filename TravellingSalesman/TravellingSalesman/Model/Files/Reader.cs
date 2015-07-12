using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravellingSalesman
{
    public class Reader
    {
        public string FilePath { get; private set; }
        public Reader()
        {
        }

        public string[] ReadCities()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                FilePath = openFileDialog.FileName;
                try
                {
                    return File.ReadAllLines(FilePath);
                }
                catch (IOException)
                {                
                }
            }
            return null;
        }

        public string[] ReadCities(string path)
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (IOException)
            {
                return null;
            }
            
        }
    }
}
