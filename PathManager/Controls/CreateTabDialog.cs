using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathManager.Controls;

public partial class CreateTabDialog : Form
{
    public CreateTabDialog()
    {
        InitializeComponent();
    }
    public string NewTabName { get { return NewTabNameTextBox.Text; } set { NewTabNameTextBox.Text = value; } }
}
