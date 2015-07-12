using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravellingSalesman
{
    public partial class TravellingSalesmanGui : Form, ITravellingSalesmanGui
    {
        public event EventHandler OpenFile = null;
        public event EventHandler SearchRoutes = null;

        public TravellingSalesmanGui()
        {
            InitializeComponent();
        }

        public void EnableSearchButton()
        {
            buttonSearchRoutes.Enabled = true;
        }

        public void UpdateTextBoxesAfterReadingFile(int numberOfCities, int k)
        {
            textBoxNumberOfCities.Text = Convert.ToString(numberOfCities);
            textBoxFactorK.Text = Convert.ToString(k);
        }

        public void UpdateTextBoxesAfterSearching(double length, int numberOfRoutes)
        {
            textBoxLengthOfRoute.Text = Convert.ToString(length);
            textBoxNumberOfRoutes.Text = Convert.ToString(numberOfRoutes);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFile != null)
            {
                OpenFile(sender, e);
            }
        }

        private void buttonSearchRoutes_Click(object sender, EventArgs e)
        {
            if (SearchRoutes != null)
            {
                SearchRoutes(sender, e);
            }
        }

    }
}
