using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preditions
{
    public partial class MainWindow : Form
    {
        private static ImagePrediction imagePredictionPanel = new ImagePrediction();
        private static TextPrediction textPredictionPanel = new TextPrediction();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChooseButton_Click(object sender, EventArgs e)
        {
            if(imageRadioButton.Checked)
            {
                Hide();
                imagePredictionPanel.Init(Constants.IMAGE);
                imagePredictionPanel.Show();

            }
            else if(spamRadioButton.Checked)
            {
                Hide();
                textPredictionPanel.Init(Constants.SPAM);
                textPredictionPanel.Show();
            }
            else if(imdbRadioButton.Checked)
            {
                Hide();
                textPredictionPanel.Init(Constants.IMBD);
                textPredictionPanel.Show();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }
    }
}
