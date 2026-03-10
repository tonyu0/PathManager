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
        public bool SortByLastOpened { get { return SortByLastOpenedCheckBox.Checked; } set { SortByLastOpenedCheckBox.Checked = value; } }
        public bool ShowFavoritesFirst { get { return ShowFavoritesFirstCheckBox.Checked;} set { ShowFavoritesFirstCheckBox.Checked = value; }  }
    }
}
