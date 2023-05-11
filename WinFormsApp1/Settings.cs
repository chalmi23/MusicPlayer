using Newtonsoft.Json;

namespace WinFormsApp1
{
    public partial class Settings : UserControl
    {
        private readonly Form1 _form1;
        private int folderCount = 0;
        private bool isDark = false;
        private List<string> folderList = new List<string>();
        public List<string> FolderList { get => folderList; set => folderList = value; }

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
                    ListViewItem item = new ListViewItem(new string[] { "", folderCount.ToString(), System.IO.Path.GetFileName(directory), directory });
                    listViewDirectories.Items.Add(item);
                }
            }
            InvertPictureBoxColors(pictureBoxLightMode);
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
                    MessageBox.Show("This directory is already on the list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void changeMode(object sender, EventArgs e)
        {
            PictureBox playMusic = (PictureBox)_form1.Controls["pictureBoxPlayMusic"];
            PictureBox stopMusic = (PictureBox)_form1.Controls["pictureBoxStopMusic"];
            PictureBox nextSong = (PictureBox)_form1.Controls["pictureBoxNextTrack"];
            PictureBox previousSong = (PictureBox)_form1.Controls["pictureBoxPreviousTrack"];
            PictureBox Forwards = (PictureBox)_form1.Controls["pictureBoxForwards"];
            PictureBox Backwards = (PictureBox)_form1.Controls["pictureBoxBackwards"];
            PictureBox Random = (PictureBox)_form1.Controls["pictureBoxRandom"];
            PictureBox Repeat = (PictureBox)_form1.Controls["pictureBoxRepeat"];
            PictureBox speakerNoSound = (PictureBox)_form1.Controls["pictureBoxSpeakerNoSound"];
            PictureBox speaker = (PictureBox)_form1.Controls["pictureBoxSpeaker"];
            PictureBox defaultCover = (PictureBox)_form1.Controls["defaultCover"];
            PictureBox closeApp = (PictureBox)_form1.Controls["pictureBoxCloseApp"];
            PictureBox minimizeApp = (PictureBox)_form1.Controls["pictureBoxMinimizeApp"];
            PictureBox logoApp = (PictureBox)_form1.Controls["pictureBoxLogo"];
            Button buttonSettings = (Button)_form1.Controls["buttonSettings"];
            Label TimeCounter = (Label)_form1.Controls["labelTimeCounter"];
            Label TimeDuration = (Label)_form1.Controls["labelDuration"];
            Label labelArtist = (Label)_form1.Controls["labelArtist"];
            Label labelTitle = (Label)_form1.Controls["labelTitle"];
            Label labelPlayerName = (Label)_form1.Controls["labelPlayerName"];
            Label labelPlaylistName = (Label)_form1.Controls["labelPlaylistName"];
            ListView listViewSongs = (ListView)_form1.Controls["musicList"];
            Button buttonAddSongs = (Button)_form1.Controls["buttonAddSongs"];
            Button buttonAddPlaylist = (Button)_form1.Controls["buttonAddPlaylist"];
            //test3
            ListView listViewPlaylist = (ListView)_form1.Controls["listViewPlaylist"];

            Color darkModeBackground = Color.FromArgb(35, 35, 35);
            Color lightMode = SystemColors.ButtonHighlight;

            if (isDark)
            {
                isDark = !isDark;

                List<Control> toggleControls = new List<Control> { labelLight,labelDark,pictureBoxLightMode,pictureBoxDarkMode };
                foreach (Control control in toggleControls) control.Visible = !control.Visible;
               
                List<Control> lightModeControls = new List<Control> { _form1, buttonSettings, buttonAddSongs, buttonAddPlaylist, this, buttonAddFolder, listViewSongs, listViewPlaylist, listViewDirectories, buttonDeleteFolder};
                foreach (Control control in lightModeControls) control.BackColor = lightMode;
                
                List<PictureBox> pictureBoxList = new List<PictureBox> { playMusic, stopMusic, nextSong, previousSong, Forwards, Backwards, Random, logoApp, minimizeApp, closeApp, Repeat, speakerNoSound, speaker, defaultCover };
                foreach (PictureBox pictureBox in pictureBoxList) InvertPictureBoxColors(pictureBox);

                List<Control> toggleControlsControlText = new List<Control> { buttonAddFolder, listViewDirectories, labelPlayerName, labelPlaylistName, TimeCounter, TimeDuration, labelDirectoryList, listViewSongs };
                foreach (Control control in toggleControlsControlText) control.ForeColor = SystemColors.ControlText;

                buttonSettings.ForeColor = SystemColors.ControlText;
                buttonAddSongs.ForeColor = SystemColors.ControlDarkDark;
                buttonAddPlaylist.ForeColor = SystemColors.ControlDarkDark;
                labelTitle.ForeColor = SystemColors.ControlDarkDark;
                labelArtist.ForeColor = SystemColors.ActiveCaption;
                listViewPlaylist.ForeColor = SystemColors.ControlDarkDark;              
            }
            else
            {
                isDark = !isDark;
                List<Control> toggleControls = new List<Control> { labelLight,labelDark,pictureBoxLightMode,pictureBoxDarkMode };
                foreach (Control control in toggleControls) control.Visible = !control.Visible;


                List<Control> darkModeControls = new List<Control> { _form1,this,listViewDirectories,listViewPlaylist,buttonSettings,buttonAddSongs,buttonAddPlaylist,buttonDeleteFolder,buttonAddFolder,listViewSongs};
                foreach (Control control in darkModeControls) control.BackColor = darkModeBackground;

                List<Control> lightModeControls = new List<Control>{ buttonSettings, buttonAddSongs, buttonAddPlaylist,buttonAddFolder, labelPlayerName, labelPlaylistName, listViewDirectories, TimeCounter, TimeDuration, labelTitle, labelArtist, labelDirectoryList};
                foreach (Control control in lightModeControls) control.ForeColor = lightMode;

                List<PictureBox> pictureBoxList = new List<PictureBox> { playMusic, stopMusic, nextSong, previousSong, Forwards, Backwards, Random, logoApp, minimizeApp, closeApp, Repeat, speakerNoSound, speaker, defaultCover };
                foreach (PictureBox pictureBox in pictureBoxList) InvertPictureBoxColors(pictureBox);

                listViewSongs.ForeColor = Color.White;
                listViewPlaylist.ForeColor = Color.White;
            }
            listViewSongs.HeaderStyle = ColumnHeaderStyle.None;
            _form1.LoadTracksToListView(_form1.CurrentPlaylistIndexGS);
        }
        private void InvertPictureBoxColors(PictureBox pictureBox)
        {
            if (pictureBox == null || pictureBox.Image == null)
            {
                return;
            }

            Bitmap bitmap = new Bitmap(pictureBox.Image);
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);

                    if (pixelColor.A != 0)
                    {
                        int newR = 255 - pixelColor.R;
                        int newG = 255 - pixelColor.G;
                        int newB = 255 - pixelColor.B;

                        Color newColor = Color.FromArgb(pixelColor.A, newR, newG, newB);

                        bitmap.SetPixel(x, y, newColor);
                    }
                }
            }
            pictureBox.Image = bitmap;
        }
    }
}
