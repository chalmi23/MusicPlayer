using Newtonsoft.Json;
using System.Drawing.Imaging;


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

        private void changeMode(object sender, EventArgs e)
        {
            Button buttonSettings = (Button)_form1.Controls["buttonSettings"];
            Button buttonAddSongs = (Button)_form1.Controls["buttonAddSongs"];
            Button buttonAddPlaylist = (Button)_form1.Controls["buttonAddPlaylist"];
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
            Label TimeCounter = (Label)_form1.Controls["labelTimeCounter"];
            Label TimeDuration = (Label)_form1.Controls["labelDuration"];
            Label labelArtist = (Label)_form1.Controls["labelArtist"];
            Label labelTitle = (Label)_form1.Controls["labelTitle"];
            Label labelPlayerName = (Label)_form1.Controls["labelPlayerName"];
            Label labelPlaylistName = (Label)_form1.Controls["labelPlaylistName"];
            ListView listViewSongs = (ListView)_form1.Controls["musicList"];
            ListView listViewPlaylist = (ListView)_form1.Controls["listViewPlaylist"];

            Color darkModeBackground = Color.FromArgb(35, 35, 35);
            Color lightMode = SystemColors.ButtonHighlight;

            if (isDark)
            {
                isDark = !isDark;
                labelLight.Visible = !labelLight.Visible;
                labelDark.Visible = !labelDark.Visible;
                pictureBoxLightMode.Visible = !pictureBoxLightMode.Visible;
                pictureBoxDarkMode.Visible = !pictureBoxDarkMode.Visible;
                _form1.BackColor = SystemColors.ButtonHighlight;
                buttonSettings.BackColor = SystemColors.ButtonHighlight;
                buttonAddSongs.BackColor = SystemColors.ButtonHighlight;
                buttonAddPlaylist.BackColor = SystemColors.ButtonHighlight;
                buttonSettings.ForeColor = SystemColors.ControlText;
                buttonAddSongs.ForeColor = SystemColors.ControlDarkDark;
                buttonAddPlaylist.ForeColor = SystemColors.ControlDarkDark;
                List<PictureBox> pictureBoxList = new List<PictureBox> { playMusic, stopMusic, nextSong, previousSong, Forwards, Backwards, Random, logoApp, minimizeApp, closeApp, Repeat, speakerNoSound, speaker, defaultCover };

                foreach (PictureBox pictureBox in pictureBoxList)
                {
                    InvertPictureBoxColors(pictureBox);
                }
                listViewSongs.BackColor = SystemColors.ButtonHighlight;
                listViewSongs.HeaderStyle = ColumnHeaderStyle.None;
                listViewPlaylist.BackColor = SystemColors.ButtonHighlight;
                listViewDirectories.BackColor = SystemColors.ButtonHighlight;
                buttonDeleteFolder.BackColor = SystemColors.ButtonHighlight;
                buttonAddFolder.BackColor = SystemColors.ButtonHighlight;
                buttonAddFolder.ForeColor = SystemColors.ControlText;
                listViewDirectories.ForeColor = SystemColors.ControlText;
                labelPlayerName.ForeColor = SystemColors.ControlText;
                labelPlaylistName.ForeColor = SystemColors.ControlText;
                this.BackColor = SystemColors.ButtonHighlight;
                TimeCounter.ForeColor = SystemColors.ControlText;
                TimeDuration.ForeColor = SystemColors.ControlText;
                labelDirectoryList.ForeColor = SystemColors.ControlText;
                labelTitle.ForeColor = SystemColors.ControlDarkDark;
                labelArtist.ForeColor = SystemColors.ActiveCaption;
                listViewSongs.ForeColor = SystemColors.ControlText;
                listViewPlaylist.ForeColor = SystemColors.ControlDarkDark;
                listViewSongs.HeaderStyle = ColumnHeaderStyle.Nonclickable;
                
            }
            else
            {
                isDark = !isDark;
                List<Control> toggleControls = new List<Control>
                {
                    labelLight,labelDark,pictureBoxLightMode,pictureBoxDarkMode
                };

                foreach (Control control in toggleControls)
                {
                    control.Visible = !control.Visible;
                }

                List<Control> darkModeControls = new List<Control>
                {
                    _form1,this,listViewDirectories,listViewPlaylist,buttonSettings,buttonAddSongs,buttonAddPlaylist,buttonDeleteFolder,buttonAddFolder,listViewSongs
                };

                foreach (Control control in darkModeControls)
                {
                    control.BackColor = darkModeBackground;
                }

                List<Control> lightModeControls = new List<Control>
                {
                    buttonSettings, buttonAddSongs, buttonAddPlaylist,buttonAddFolder, labelPlayerName, labelPlaylistName, listViewDirectories, TimeCounter, TimeDuration, labelTitle, labelArtist, labelDirectoryList
                };

                foreach (Control control in lightModeControls)
                {
                    control.ForeColor = lightMode;
                }

                List<PictureBox> pictureBoxList = new List<PictureBox> { playMusic, stopMusic, nextSong, previousSong, Forwards, Backwards, Random, logoApp, minimizeApp, closeApp, Repeat, speakerNoSound, speaker, defaultCover };

                foreach (PictureBox pictureBox in pictureBoxList)
                {
                    InvertPictureBoxColors(pictureBox);
                }

                listViewSongs.ForeColor = Color.White;
                listViewPlaylist.ForeColor = Color.White;
                listViewSongs.HeaderStyle = ColumnHeaderStyle.None;
            }
            _form1.LoadTracksToListView(_form1.CurrentPlaylistIndexGS);
        }
        private void InvertPictureBoxColors(PictureBox pictureBox)
        {
            if (pictureBox == null || pictureBox.Image == null)
            {
                return;
            }

            ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
                new float[] {-1, 0, 0, 0, 0},
                new float[] {0, -1, 0, 0, 0},
                new float[] {0, 0, -1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {1, 1, 1, 0, 1}
            });

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix);

            Bitmap bitmap = new Bitmap(pictureBox.Image);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, imageAttributes);
            }

            pictureBox.Image = bitmap;
        }
    }
}
