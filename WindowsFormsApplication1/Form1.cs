using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EclipseFileHelper
{
    public partial class loadingForm : Form
    {
        public loadingForm()
        {
            InitializeComponent();
        }

        private void loadingForm_Load(object sender, EventArgs e)
        {
            
        }

        // expose a method to set the ProgressBar #value
        public void SetProgressBarValue(int pbValue)
        {
            loadingProgressBar.Value = pbValue;
        }

    }
}
