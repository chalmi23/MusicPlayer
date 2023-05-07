namespace WinFormsApp1
{
    public partial class Settings : UserControl
    {
        private readonly Form1 _form1;
        public Settings(Form1 form1)
        {
            InitializeComponent();
            listViewDirectories.View = View.Details;
            _form1 = form1;
        }
        private List<string> folderList = new List<string>();

        private void addFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderDialog.SelectedPath;

                if (!folderList.Contains(folderPath))
                {
                    folderList.Add(folderPath);

                    int folderCount = folderList.Count;
                    ListViewItem item = new ListViewItem(new string[] { "", folderCount.ToString(), System.IO.Path.GetFileName(folderPath), folderPath });
                    listViewDirectories.Items.Add(item);
                    _form1.LoadToListViewFromFolder(folderPath);
                }
                else
                {
                    MessageBox.Show("Ten folder został już dodany.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void deleteFolder(object sender, EventArgs e)
        {
            if (listViewDirectories.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewDirectories.SelectedItems[0];
                string folderPath = selectedItem.SubItems[3].Text;

                // Remove the folder from folderList
                folderList.Remove(folderPath);

                // Remove the item from the listView
                listViewDirectories.Items.Remove(selectedItem);

                // Update the remaining items' IDs in the listView
                for (int i = 0; i < listViewDirectories.Items.Count; i++)
                {
                    listViewDirectories.Items[i].SubItems[1].Text = (i + 1).ToString();
                }
                _form1.DeleteSongsFromDirectory(folderPath);
            }
            else
            {
                MessageBox.Show("Please select a folder to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
