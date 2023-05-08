using Newtonsoft.Json;
using System.IO;

namespace WinFormsApp1
{
    public partial class Settings : UserControl
    {
        private readonly Form1 _form1;
        private List<string> folderList = new List<string>();
        int folderCount = 0;
        public Settings(Form1 form1)
        {
            InitializeComponent();
            listViewDirectories.View = View.Details;
            _form1 = form1;

            if (File.Exists("appSettings.json"))
            {
                string json = File.ReadAllText("appSettings.json");
                var appSettings = JsonConvert.DeserializeObject<AppSettingsClass>(json);
                foreach (var directory in appSettings.DirectoriesGS)
                {
                    folderList.Add(directory);
                    folderCount++;
                    ListViewItem item = new ListViewItem(new string[] { "",folderCount.ToString(), System.IO.Path.GetFileName(directory), directory });
                    listViewDirectories.Items.Add(item);
                }
            }
            else
            {
                folderList.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
                folderCount++;
                ListViewItem item = new ListViewItem(new string[] { "", folderCount.ToString(), System.IO.Path.GetFileName(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)), Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) });
                listViewDirectories.Items.Add(item);
            }
        }
        private void addFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderDialog.SelectedPath;

                if (!folderList.Any(folder => folder == folderPath))
                {
                    folderList.Add(folderPath);

                    folderCount = folderList.Count;
                    ListViewItem item = new ListViewItem(new string[] { "", folderCount.ToString(), System.IO.Path.GetFileName(folderPath), folderPath });
                    listViewDirectories.Items.Add(item);
                    _form1.LoadToListViewFromFolder(folderPath);
                    _form1.refreshJsonFile(folderList);
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

                folderList.RemoveAll(folder => folder == folderPath);
                listViewDirectories.Items.Remove(selectedItem);

                for (int i = 0; i < listViewDirectories.Items.Count; i++)
                {
                    listViewDirectories.Items[i].SubItems[1].Text = (i + 1).ToString();
                }
                _form1.DeleteSongsFromDirectory(folderPath);
                _form1.refreshJsonFile(folderList);
            }
            else
            {
                MessageBox.Show("Please select a folder to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
