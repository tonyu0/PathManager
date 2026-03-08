using System.ComponentModel;
using PathManager.Utils;

namespace PathManager.Controls;

public partial class ContentTabPage : UserControl
{
    public List<PathItem> PathItemList // To make it easier to load data from JSON
    {
        get
        {
            //return PathItemBindingSource.List.Cast<PathItem>().ToList();
            return _fullList;
        }

        set
        {
            if (value is null)
            {
                return;
            }

            //PathItemBindingSource.Clear();
            _fullList.Clear();
            _displayList.Clear();
            foreach (PathItem pathItem in value)
            {
                //PathItemBindingSource.Add(Path);
                _fullList.Add(pathItem);
                _displayList.Add(pathItem);
            }
            _displayList.ResetBindings();
        }
    }

    // Lists for filtering: _fullList has all data of this tab, and _displayList has displayed data.
    // As implementing path filter, it becomes necessary to manage two lists because not all data is necessarily displayed
    private List<PathItem> _fullList = new();
    private BindingList<PathItem> _displayList = new();


    public ContentTabPage()
    {
        InitializeComponent();
    }

    private void AddRowButton_Click(object sender, EventArgs e)
    {
        //PathItemBindingSource.Add(new Utils.PathItem());
        var newItem = new PathItem();
        _fullList.Add(newItem);
        _displayList.Add(newItem);
        _displayList.ResetBindings();
    }

    private void RemoveRowButton_Click(object sender, EventArgs e)
    {
        if (DataGridView.CurrentRow?.DataBoundItem is PathItem selectedItem)
        {
            // Be careful to delete the target data even while filtering
            _fullList.Remove(selectedItem);
            _displayList.Remove(selectedItem);
            _displayList.ResetBindings();
        }
    }

    private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        DataGridView dataGridView = (DataGridView)sender;
        if (dataGridView != null)
        {
            if (dataGridView.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell))
            {
                //PathItem pathItem = ((Utils.PathItem)PathItemBindingSource[e.RowIndex]);
                var pathItem = _displayList[e.RowIndex];

                OpenPath(pathItem.Path);
            }
        }
    }

    private void OpenPath(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            MessageBox.Show("empty path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (Directory.Exists(path))
        {
            System.Diagnostics.Process.Start("explorer.exe", path);
        }
        else
        {
            MessageBox.Show("cannot find the specified path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        string filterText = FilterTextBox.Text.ToLower();

        // 1. Clear the list for display
        _displayList.RaiseListChangedEvents = false; // Pause drawing update to speed up
        _displayList.Clear();

        // 2. filtering and add to the list for display again
        var filtered = _fullList.Where(item =>
            item.Path.ToLower().Contains(filterText) ||
            item.Note.ToLower().Contains(filterText)
        );

        foreach (var item in filtered)
        {
            _displayList.Add(item);
        }

        _displayList.RaiseListChangedEvents = true;
        _displayList.ResetBindings(); // reflesh for drawing
    }

    private void ContentTabPage_Load(object sender, EventArgs e)
    {
        DataGridView.DataSource = _displayList;
    }
}
