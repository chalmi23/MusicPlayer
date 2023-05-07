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
    }
}
