using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows.Forms;
using PathManager.Controls;
using PathManager.Utils;

namespace PathManager;

public partial class Form1 : Form
{
    public AppData AppData { get; private set; } = new();// it needs to be accessed from Controls, so needs getter


    private string GetAppDataFilename()
    {
        return System.IO.Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\appdata.json";
    }

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            AppData = JsonService.Load<AppData>(GetAppDataFilename()) ?? new();
            // Load content data
            foreach (AppData.ContentsSaveData Save in AppData.TabContentList)
            {
                AddTab(Save.TabTitle, Save.PathItemList);
            }

            // Load settings data
            if (!string.IsNullOrEmpty(AppData.Settings.AppTitleName))
            {
                Text = AppData.Settings.AppTitleName;
            }
        }
        catch (Exception Exc)
        {
            MessageBox.Show(Exc.Message);
        }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        try
        {
            AppData.TabContentList.Clear();
            foreach (TabPage Page in ContentTabControl.TabPages)
            {
                ContentTabPage? contentTabPage = Page.Controls[0] as ContentTabPage;
                if (contentTabPage is not null)
                {
                    AppData.TabContentList.Add(new()
                    {
                        TabTitle = Page.Text,
                        PathItemList = contentTabPage.PathItemList
                    });
                }
            }

            // AppData.settings are already reflected (see settingsToolStripMenuItem_Click())

            JsonService.Save(GetAppDataFilename(), AppData);
        }
        catch (Exception Exc)
        {
            MessageBox.Show(Exc.Message);
        }
    }

    private void createNewTabToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Controls.CreateTabDialog createTabDialog = new Controls.CreateTabDialog();
        if (createTabDialog.ShowDialog() == DialogResult.OK)
        {
            AddTab(createTabDialog.NewTabName, new List<PathItem>());
        }
    }

    private void AddTab(string tabTitle, List<PathItem> initialPathItemList)
    {
        if (string.IsNullOrEmpty(tabTitle))
        {
            return;
        }

        // ContentTabPage is managed by BindingSource.
        // Creating new empty TabPage and Setting ContentTabPage to the TabPage's Controls, each BindingSource can manage each Tab data.
        TabPage tabPage = new TabPage(tabTitle);
        Controls.ContentTabPage newContentTabPage = new Controls.ContentTabPage();
        newContentTabPage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        newContentTabPage.Dock = DockStyle.Fill;
        newContentTabPage.PathItemList = initialPathItemList; // set path list 
        tabPage.Controls.Add(newContentTabPage);
        ContentTabControl.TabPages.Add(tabPage);
    }

    private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Controls.SettingsForm settingsForm = new Controls.SettingsForm();
        settingsForm.AppTitleName = AppData.Settings.AppTitleName;

        if(settingsForm.ShowDialog() == DialogResult.OK)
        {
            // save settings
            if(!string.IsNullOrEmpty(settingsForm.AppTitleName))
            {
                AppData.Settings.AppTitleName = settingsForm.AppTitleName;
                Text = AppData.Settings.AppTitleName;
            }
        }
    }
}
