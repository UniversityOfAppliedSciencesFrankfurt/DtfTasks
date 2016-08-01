using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Google.Apis.YouTube.Samples
{
    public partial class VideoSelector : Form
    {
        public string vedioPath { get; set; }
        public VideoSelector()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                vedioPath = openFileDialog1.FileName;
                this.Hide();
            }
           
        }
    }
}
