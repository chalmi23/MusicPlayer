using System.IO;
namespace WinFormsApp1
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
            listViewDirectories.View = View.Details;
        }
        private List<string> folderList = new List<string>();

        private void addFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderDialog.SelectedPath;
                folderList.Add(folderPath);

                int folderCount = folderList.Count;
                ListViewItem item = new ListViewItem(new string[] { "", folderCount.ToString(), System.IO.Path.GetFileName(folderPath), folderPath });
                listViewDirectories.Items.Add(item);
            }
        }
    }
}
