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
    public partial class ImagePrediction : Form
    {
        private static ImagePredicted imagePredicted = new ImagePredicted();
        private static WaitPopup waitPopup = new WaitPopup();
        
        private string imageFilePath;
        private bool canPredict;
        private Image selectedImage;
        private string type;

        OpenFileDialog openFileDialog1 = new OpenFileDialog()
        {
            Filter = "Image Files(*.PNG;*.JPG;*.JPEG)|*.PNG;*.JPG;*.JPEG",
            InitialDirectory = Constants.OPEN_DIALOG_FILE
        };

        public ImagePrediction()
        {
            InitializeComponent();
        }

        public void Init(string _type)
        {
            type = _type;
            string text = File.ReadAllText(Constants.IMAGE_PREDICTION_FILE);
            textBoxDetails.Text = text;
            imageBox.Image = null;
            Select();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if(!string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                imageFilePath = openFileDialog1.FileName;
                selectedImage = Image.FromFile(openFileDialog1.FileName);
                imageBox.Image = selectedImage;
                canPredict = true;
            }
        }

        private void predictButton_Click(object sender, EventArgs e)
        {
            if (canPredict)
            {
                PrepareDataToRequest();
            }
            else
            {
                MessageBox.Show("Load an image before to predict!");
            }
        }

        private void OnServerResponse(PredictResponse  _predictedData)
        {
            waitPopup.Close();
            imagePredicted.Show();
            imagePredicted.SetData(imageFilePath, _predictedData);
            Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
            Hide();
        }

        private void PrepareDataToRequest()
        {
            Bitmap myBitmap = new Bitmap(selectedImage, 32, 32);
            // se ia coloana cu coloana
            List<List<List<float>>> data = new List<List<List<float>>>();

            for (int i = 0; i < myBitmap.Height; i++)
            {
                List<List<float>> column = new List<List<float>>();

                for (int j = 0; j < myBitmap.Width; j++)
                {
                    Color color = myBitmap.GetPixel(j, i);
                    column.Add(new List<float>() { color.R / 255f, color.G / 255f, color.B / 255f });
                }
                data.Add(column);
            }

            NetworkManager.Instance.SendImageRequest(type, data, OnServerResponse, ()  => { waitPopup.Close(); });
            waitPopup.ShowDialog(this);

        }
    }
}
