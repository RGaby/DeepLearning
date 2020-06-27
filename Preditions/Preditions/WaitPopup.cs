using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Preditions
{
    public partial class WaitPopup : Form
    {
        private bool isWaiting = false;
        private int angle = 0;
        public WaitPopup()
        {
            InitializeComponent();
        }

    }
}
