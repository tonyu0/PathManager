using System.ComponentModel;
using System.Data;
using PathManager.Utils;

namespace PathManager.Controls;

public partial class ContentTabPage : UserControl
{
    public List<PathItem> PathItemList // To make it easier to load data from JSON
    {
        get
        {
            // Use LINQ
            List<PathItem> fullList = _displayDataTable.AsEnumerable().Select(row => new PathItem
            {
                Path = row.Field<string>("Path") ?? string.Empty,
                Note = row.Field<string>("Note") ?? string.Empty,
                LastOpenedAt = row.Field<DateTime>("LastOpenedAt"),
                IsFavorite = row.Field<bool>("IsFavorite")
            }).ToList();

            return fullList;
        }

        set
        {
            if (value is null)
            {
                return;
            }

            _displayDataTable = ToDataTable(value);
        }
    }

    // Helper: make use of reflection to convert List<T> to DataTable
    public static DataTable ToDataTable<T>(List<T> items)
    {
        DataTable dt = new DataTable(typeof(T).Name);
        var properties = typeof(T).GetProperties();

        // Create columns
        properties.ToList().ForEach(x => dt.Columns.Add(x.Name, x.PropertyType));

        // Add rows
        foreach (var item in items)
        {
            var values = new object[properties.Length];
            for (int i = 0; i < properties.Length; i++)
            {
                values[i] = properties[i].GetValue(item) ?? DBNull.Value;
            }
            dt.Rows.Add(values);
        }
        return dt;
    }

    public void UpdateDataGridViewSettings(AppData.SettingsSaveData settings)
    {
        string sortMode = "";
        if (settings.ShowFavoritesFirst && settings.SortByLastOpened)
        {
            sortMode = "IsFavorite DESC, LastOpenedAt DESC";
        }
        else if (settings.ShowFavoritesFirst)
        {
            sortMode = "IsFavorite DESC";
        }
        else if (settings.SortByLastOpened)
        {
            sortMode = "LastOpenedAt DESC";
        }

        if (DataGridView.DataSource is DataTable dt)
        {
            dt.DefaultView.Sort = sortMode;
        }
    }

    DataTable _displayDataTable = new();


    public ContentTabPage()
    {
        InitializeComponent();
    }

    private void AddRowButton_Click(object sender, EventArgs e)
    {
        // nearly same as adding row part of ToDataTable() (need to make another function?)
        // need to create a row from PathItem because LastOpenedAt(DateTime) is non-nullable
        var newPathItem = new PathItem();
        var properties = typeof(PathItem).GetProperties();

        var values = new object[properties.Length];
        for (int i = 0; i < properties.Length; i++)
        {
            values[i] = properties[i].GetValue(newPathItem) ?? DBNull.Value;
        }

        _displayDataTable.Rows.Add(values);
    }

    private void RemoveRowButton_Click(object sender, EventArgs e)
    {
        if (DataGridView.CurrentRow?.DataBoundItem is DataRowView row)
        {
            row.Delete();
        }
    }

    private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        DataGridView dataGridView = (DataGridView)sender;
        if (dataGridView != null)
        {
            if (dataGridView.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell))
            {
                if (DataGridView.CurrentRow?.DataBoundItem is DataRowView rowView)
                {
                    //var row = _displayDataTable.Rows[e.RowIndex]; // if using search filter, e.RowIndex is misaligned with the displayed order
                    var row = rowView.Row;
                    string path = row.Field<string>("Path") ?? string.Empty;

                    if (OpenPath(path))
                    {
                        row["LastOpenedAt"] = DateTime.Now;
                    }
                }
            }
        }
    }

    private bool OpenPath(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            MessageBox.Show("empty path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (Directory.Exists(path))
        {
            System.Diagnostics.Process.Start("explorer.exe", path);
            return true;
        }
        else
        {
            MessageBox.Show("cannot find the specified path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
    }

    private void DeleteTabButton_Click(object sender, EventArgs e)
    {
        if (Parent?.Parent is TabControl contentTabControl)
        {
            if (contentTabControl.SelectedTab is not null)
            {
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete this tab (tab index: {contentTabControl.SelectedIndex}) ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    contentTabControl.TabPages.Remove(contentTabControl.SelectedTab);
                    MessageBox.Show("Deleted.");
                }
            }
        }
    }

    private void RenameTabButton_Click(object sender, EventArgs e)
    {
        if (Parent?.Parent is TabControl contentTabControl)
        {
            if (contentTabControl.SelectedTab is not null)
            {
                using (CreateTabDialog dlg = new CreateTabDialog())
                {
                    dlg.Text = "Rename Tab";
                    dlg.NewTabName = contentTabControl.SelectedTab.Text;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        contentTabControl.SelectedTab.Text = dlg.NewTabName;
                    }
                }
            }
        }
    }

    private void FilterTextBox_TextChanged(object sender, EventArgs e)
    {
        string filterText = string.Format("Path LIKE '%{0}%'", FilterTextBox.Text.ToLower().Replace("'", "")); // crash if single quotation exists
        _displayDataTable.DefaultView.RowFilter = filterText;
    }

    private void ContentTabPage_Load(object sender, EventArgs e)
    {
        DataGridView.DataSource = _displayDataTable;
        DataGridView.Columns["LastOpenedAt"].ReadOnly = true;
        DataGridView.Columns["LastOpenedAt"].FillWeight = 5.0f;
        DataGridView.Columns["IsFavorite"].FillWeight = 2.0f;
        DataGridView.Columns["IsFavorite"].HeaderText = "★";
        DataGridView.Columns["IsFavorite"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        DataGridView.Columns["Note"].FillWeight = 7.0f;
        DataGridView.Columns["Path"].FillWeight = 25.0f;

        if (ParentForm is Form1 form)
        {
            UpdateDataGridViewSettings(form.AppData.Settings);
        }
    }

    private void MoveTabRight_Click(object sender, EventArgs e)
    {
        if (Parent?.Parent is TabControl contentTabControl)
        {
            // Check if selected index is not rightmost and a tab is selected (!= -1)
            if (contentTabControl.SelectedIndex < contentTabControl.TabCount - 1 && contentTabControl.SelectedIndex != -1)
            {
                if (contentTabControl.SelectedTab is TabPage selectedTab)
                {
                    int selectedTabIndex = contentTabControl.SelectedIndex;

                    contentTabControl.TabPages.Remove(selectedTab);
                    contentTabControl.TabPages.Insert(selectedTabIndex + 1, selectedTab);
                    contentTabControl.SelectedIndex = selectedTabIndex + 1;
                }
            }
        }
    }

    private void MoveTabLeft_Click(object sender, EventArgs e)
    {
        if (Parent?.Parent is TabControl contentTabControl)
        {
            // Check if selected index is not leftmost and a tab is selected (!= -1)
            if( contentTabControl.SelectedIndex > 0 )
            {
                if(contentTabControl.SelectedTab is TabPage selectedTab)
                {
                    int selectedTabIndex = contentTabControl.SelectedIndex;

                    contentTabControl.TabPages.Remove(selectedTab);
                    contentTabControl.TabPages.Insert(selectedTabIndex - 1, selectedTab);
                    contentTabControl.SelectedIndex = selectedTabIndex - 1;
                }
            }
        }
    }
}
