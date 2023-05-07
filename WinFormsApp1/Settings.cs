﻿using Newtonsoft.Json;
using System.IO;

namespace WinFormsApp1
{
    public partial class Settings : UserControl
    {
        private readonly Form1 _form1;
        private List<DirectoryClass> folderList = new List<DirectoryClass>();
        int folderCount = 0;
        public Settings(Form1 form1)
        {
            InitializeComponent();
            listViewDirectories.View = View.Details;
            _form1 = form1;

            if (System.IO.File.Exists("appSettings.json"))
            {
                string json = System.IO.File.ReadAllText("appSettings.json");
                List<DirectoryClass> directories = JsonConvert.DeserializeObject<List<DirectoryClass>>(json);

                foreach (var dir in directories)
                {
                    folderList.Add(dir);
                    folderCount = folderList.Count;
                    ListViewItem item = new ListViewItem(new string[] { "", folderCount.ToString(), dir.FolderNameGS, dir.PathGS });
                    listViewDirectories.Items.Add(item);
                }
            }
        }




        private void addFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderDialog.SelectedPath;

                if (!folderList.Any(folder => folder.PathGS == folderPath))
                {
                    var directory = new DirectoryClass();
                    directory.PathGS = folderPath;
                    directory.FolderNameGS = System.IO.Path.GetFileName(folderPath);
                    folderList.Add(directory);

                    folderCount = folderList.Count;
                    ListViewItem item = new ListViewItem(new string[] { "", folderCount.ToString(), directory.FolderNameGS, directory.PathGS });
                    listViewDirectories.Items.Add(item);
                    _form1.LoadToListViewFromFolder(directory.PathGS);
                    refreshJsonFile();
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

                folderList.RemoveAll(folder => folder.PathGS == folderPath);
                listViewDirectories.Items.Remove(selectedItem);

                for (int i = 0; i < listViewDirectories.Items.Count; i++)
                {
                    listViewDirectories.Items[i].SubItems[1].Text = (i + 1).ToString();
                }
                _form1.DeleteSongsFromDirectory(folderPath);
                refreshJsonFile();
            }
            else
            {
                MessageBox.Show("Please select a folder to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshJsonFile()
        {
            string json = JsonConvert.SerializeObject(folderList, Formatting.Indented);
            File.WriteAllText("appSettings.json", json);
        }
    }
}
