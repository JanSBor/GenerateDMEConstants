using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateDMEConstants
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void SelectExtFile_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDlg.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = FileDlg.FileName;

                ExtensionFileName.Text = file;
            }
            else
            {
                //TODO: Add errorhandling
            }
        }

        private void SelectOutputFile_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDlg.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = FileDlg.FileName;

                OutputFileName.Text = file;
            }
            else
            {
                //TODO: Add errorhandling
            }
        }
    }
}
