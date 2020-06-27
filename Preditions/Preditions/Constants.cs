using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preditions
{
    public class Constants
    {
        public const string IMBD = "imdb";
        public const string IMAGE = "image";
        public const string SPAM = "spam";

        public static string IMAGE_PREDICTION_FILE { get { return Path.Combine(Application.StartupPath, "imageClassificationDescription.txt"); } }
        public static string IMBD_PREDICTION_FILE { get { return Path.Combine(Application.StartupPath, "imbdClassificationDescription.txt"); } }
        public static string SPAM_PREDICTION_FILE { get { return Path.Combine(Application.StartupPath, "spamClassificationDescription.txt");} }

        public static string OPEN_DIALOG_FILE { get { return Path.Combine(Application.StartupPath); } }
    }
}
