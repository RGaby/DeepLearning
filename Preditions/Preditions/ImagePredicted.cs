using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preditions
{
    public partial class ImagePredicted : Form
    {
        public ImagePredicted()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }

        public void SetData(string _fileLocation, PredictResponse _response)
        {
            if (!string.IsNullOrEmpty(_fileLocation))
            {
                imageBox.Image = Image.FromFile(_fileLocation);
            }
            ComputeTextPredicted(_response);
        }

        private void ComputeTextPredicted(PredictResponse _response)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < _response.keys.Count; i++)
            {
                double number = double.Parse(_response.values[i], CultureInfo.InvariantCulture) * 100;
                listBox1.Items.Add(string.Format(" - {0} : {1:0.##}%", _response.keys[i], number));
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ImagePrediction mainWindow = new ImagePrediction();

            mainWindow.Show();
            Hide();
        }
    }
}
