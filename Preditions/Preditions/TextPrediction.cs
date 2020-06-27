using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preditions
{
    public partial class TextPrediction : Form
    {
        private static TextPredicted textPredicted = new TextPredicted();
        private static WaitPopup waitPopup = new WaitPopup();
        private string textToPredict;
        private string type;

        OpenFileDialog openFileDialog1 = new OpenFileDialog()
        {
            Filter = "Text files (*.txt;*.doc)|*.txt;*.doc;",
            InitialDirectory = Constants.OPEN_DIALOG_FILE
        };

        public TextPrediction()
        {
            InitializeComponent();
            
        }

        public void Init(string _type)
        {
            type = _type;
            string text = string.Empty;
            if (type.CompareTo(Constants.IMBD) == 0)
            {
                text = File.ReadAllText(Constants.IMBD_PREDICTION_FILE);
            }
            else
            {
                text = File.ReadAllText(Constants.SPAM_PREDICTION_FILE);
            }
            textBoxDetails.Text = text;
            textBox1.Clear();
            Select();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                string text = File.ReadAllText(openFileDialog1.FileName);
                textBox1.Text = text;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }

        private void predictButton_Click(object sender, EventArgs e)
        {
            textToPredict = textBox1.Text;
            if (!string.IsNullOrEmpty(textToPredict))
            {
                NetworkManager.Instance.SendTextRequest(type, textToPredict, OnServerResponse, () => { waitPopup.Close(); });
                waitPopup.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Write or load a text before to predict!");
            }
        }

        private void OnServerResponse(PredictResponse _predictedData)
        {
            waitPopup.Close();
            textPredicted.Init(type);
            textPredicted.Show();
            textPredicted.SetDataPredicted(textToPredict, _predictedData);
            Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
            Hide();
        }
    }
}
