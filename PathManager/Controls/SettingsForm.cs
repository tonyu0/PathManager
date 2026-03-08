using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathManager.Controls
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        public string AppTitleName { get { return AppTitleNameTextBox.Text; } set { AppTitleNameTextBox.Text = value; } }
    }
}
