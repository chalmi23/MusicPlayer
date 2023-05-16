using NAudio.Wave;
using Newtonsoft.Json;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Settings settings;

        private int trackCounter = 0;
        private int playlistCounter = 0;

        private int currentTrackIndex;
        private int currentPlaylistIndex = -1;

        private int playStatus = 0;
        private float previousVolume = 1;

        private bool isPlaying = false;
        private bool isPaused = false;
        private bool isRandom = false;
        private bool isFadingOut = false;

        private int timerCounterTitle = 0;
        private int timerCounterArtist = 0;

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        AudioFileReader audioFile;
        WaveOutEvent outputDevice;

        private List<trackClass> tracks = new List<trackClass>();
        private List<int> availableTrackIndexes = new List<int>();
        private List<PlaylistClass> playLists = new List<PlaylistClass>();
        private List<Image> albumCovers = new List<Image>();

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public int CurrentPlaylistIndexGS { get => currentPlaylistIndex; set => currentPlaylistIndex = value; }

        public Form1()
        {
            InitializeComponent();

            musicList.View = View.Details;
            listViewPlaylist.View = View.Details;
            musicList.SmallImageList = new ImageList();
            musicList.ForeColor = Color.FromArgb(40, 40, 40);

            outputDevice = new WaveOutEvent();

            outputDevice.PlaybackStopped += SongIsOver;
            trackBar.Scroll += TrackBar_Scroll;

            Controls.Add(trackBar);

            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            settings = new Settings(this);

            if (System.IO.File.Exists("appSettings.json"))
            {
                string json = System.IO.File.ReadAllText("appSettings.json");
                AppSettingsClass appSettings = JsonConvert.DeserializeObject<AppSettingsClass>(json);
                if (appSettings.PlaylistsGS != null)
                {
                    bool mainPlaylistExists = false;
                    foreach (var playList in appSettings.PlaylistsGS)
                    {
                        if (playList.NameGS == "Main playlist")
                        {
                            mainPlaylistExists = true;
                        }
                        playlistCounter++;
                        ListViewItem item = new ListViewItem(new string[] { "", playlistCounter.ToString(), playList.NameGS });
                        listViewPlaylist.Items.Add(item);
                        playLists.Add(playList);
                    }
                    if (!mainPlaylistExists)
                    {
                        var mainPlaylist = new PlaylistClass { NameGS = "Main playlist", TrackListGS = tracks };
                        appSettings.PlaylistsGS.Add(mainPlaylist);
                        ListViewItem item = new ListViewItem(new string[] { "", (++playlistCounter).ToString(), mainPlaylist.NameGS });
                        listViewPlaylist.Items.Add(item);
                        playLists.Add(mainPlaylist);
                    }
                }
                if (appSettings.DirectoriesGS != null)
                {
                    foreach (var dir in appSettings.DirectoriesGS)
                    {
                        AddNewSongs(trackClass.LoadFromDirectory(dir));
                    }
                }
                currentPlaylistIndex = 0;
            }
            else
            {
                var appSettings = new AppSettingsClass
                {
                    DirectoriesGS = new List<string> { },
                    PlaylistsGS = new List<PlaylistClass> { new PlaylistClass { NameGS = "Main playlist", TrackListGS = tracks } }
                };
                var json = JsonConvert.SerializeObject(appSettings, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("appSettings.json", json);
                foreach (var playList in appSettings.PlaylistsGS)
                {
                    playlistCounter++;
                    ListViewItem item = new ListViewItem(new string[] { "", playlistCounter.ToString(), playList.NameGS });
                    listViewPlaylist.Items.Add(item);
                    playLists.Add(playList);
                }
                currentPlaylistIndex = 0;
            }
        }
        private void AddNewSongs(List<trackClass> tracksAdded)
        {
            ImageList imageList = musicList.SmallImageList ?? new ImageList();
            imageList.ImageSize = new Size(48, 48);

            List<string> existingTracks = tracks.Select(t => $"{t.TitleGS} {t.ArtistGS}").ToList();
            List<trackClass> newTracks = new List<trackClass>();

            foreach (trackClass track in tracksAdded)
            {
                string trackIdentifier = $"{track.TitleGS} {track.ArtistGS}";
                if (!existingTracks.Contains(trackIdentifier))
                {
                    existingTracks.Add(trackIdentifier);
                    newTracks.Add(track);
                }
            }

            if (tracksAdded.Count > newTracks.Count)
            {
                MessageBox.Show("Some songs are already on the list.", "Music Player");
            }

            tracksAdded = newTracks;
            PlaylistClass selectedPlaylist = new PlaylistClass();
            if (currentPlaylistIndex != -1) selectedPlaylist = playLists[currentPlaylistIndex];

            foreach (trackClass track in tracksAdded)
            {
                trackCounter++;
                ListViewItem item = new ListViewItem(new string[] { "", trackCounter.ToString(), track.TitleGS, track.ArtistGS, track.AlbumGS, track.DurationGS });
                musicList.Items.Add(item);
                tracks.Add(track);

                int index = -1;
                byte[] pictureData = track.CoverGS?.Data?.Data;
                if (pictureData != null)
                {
                    using (var ms = new MemoryStream(pictureData))
                    {
                        Image coverImage = System.Drawing.Image.FromStream(ms);
                        index = albumCovers.FindIndex(img => img.RawFormat.Equals(coverImage.RawFormat) && img.Size.Equals(coverImage.Size));
                        if (index == -1)
                        {
                            index = albumCovers.Count;
                            albumCovers.Add(coverImage);
                            imageList.Images.Add(coverImage);
                        }
                    }
                }
                else
                {
                    index = albumCovers.FindIndex(img => img.RawFormat.Equals(defaultCover.Image.RawFormat) && img.Size.Equals(defaultCover.Image.Size));
                    if (index == -1)
                    {
                        index = albumCovers.Count;
                        albumCovers.Add(defaultCover.Image);
                        imageList.Images.Add(defaultCover.Image);
                    }
                }
                item.ImageIndex = index;
                if (currentPlaylistIndex != -1) selectedPlaylist.TrackListGS.Add(track);
            }
            musicList.SmallImageList = imageList;
            if (currentPlaylistIndex != -1) LoadTracksToListView(currentPlaylistIndex);
            refreshJsonFile(settings.FolderList);
        }

        private void listViewPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPlaylist.SelectedItems.Count > 0)
            {
                PlaylistClass selectedPlaylist = playLists[listViewPlaylist.SelectedIndices[0]];
                currentPlaylistIndex = listViewPlaylist.SelectedIndices[0];
                LoadTracksToListView(currentPlaylistIndex);
            }
        }
        public void LoadTracksToListView(int playlistIndex)
        {
            musicList.Items.Clear();
            tracks.Clear();
            availableTrackIndexes.Clear();
            trackCounter = 0;

            List<trackClass> tracksToDisplay = new List<trackClass>();
            tracksToDisplay = playLists[playlistIndex].TrackListGS;

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(48, 48);

            if (tracksToDisplay != null)
            {
                foreach (trackClass track in tracksToDisplay)
                {
                    trackCounter++;
                    tracks.Add(track);
                    availableTrackIndexes.Add(trackCounter - 1);

                    imageList.Images.Add(GetAlbumCoverFromPath(track.PathGS));
                    ListViewItem item = new ListViewItem(new string[] { "", trackCounter.ToString(), track.TitleGS, track.ArtistGS, track.AlbumGS, track.DurationGS });
                    musicList.Items.Add(item);
                    item.ImageIndex = trackCounter - 1;
                }
            }
            musicList.SmallImageList = imageList;
            labelPlaylistName.Text = playLists[playlistIndex].NameGS;
        }
        private void AddNewPlaylist(object sender, EventArgs e)
        {
            Form prompt = new Form();
            prompt.Width = 300;
            prompt.Height = 150;
            prompt.Text = "Add new playlist";

            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Enter name:" };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200, MaxLength = 18 };
            Button confirmation = new Button() { Text = "Dodaj", Left = 110, Width = 70, Top = 80 };

            confirmation.Click += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text) && textBox.Text != "Main playlist")
                {
                    playlistCounter++;
                    PlaylistClass newPlaylist = new PlaylistClass { NameGS = textBox.Text, TrackListGS = new List<trackClass>() };
                    playLists.Add(newPlaylist);
                    ListViewItem item = new ListViewItem(new string[] { "", playlistCounter.ToString(), newPlaylist.NameGS });
                    listViewPlaylist.Items.Add(item);

                    prompt.Close();
                }
                else
                {
                    MessageBox.Show("Enter a valid playlist name", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);

            prompt.ShowDialog();
            refreshJsonFile(settings.FolderList);
        }
        private void playSelectedTrack(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pictureBoxPlayMusic.Enabled = true;
                pictureBoxForwards.Enabled = true;

                pictureBoxBackwards.Enabled = true;
                if (musicList.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = musicList.SelectedItems[0];
                    int trackIndex = int.Parse(selectedItem.SubItems[1].Text) - 1;

                    if (isPlaying || isPaused) outputDevice.Stop();

                    if (CheckAndRemoveNonexistentTrack(trackIndex))
                    {
                        if (currentTrackIndex >= trackIndex && currentTrackIndex > 0)
                        {
                            currentTrackIndex--;
                        }

                        selectedItem = musicList.Items[currentTrackIndex];
                        trackIndex = int.Parse(selectedItem.SubItems[1].Text) - 1;
                        LoadTracksToListView(currentPlaylistIndex);
                        MessageBox.Show("The file has been deleted or is corrupted.", "Message");
                    }

                    string filePath = tracks[trackIndex].PathGS;

                    if (!File.Exists(filePath))
                    {
                        return;
                    }
                    audioFile = new AudioFileReader(filePath);

                    outputDevice.Init(audioFile);
                    currentTrackIndex = trackIndex;

                    if (isRandom) initializeAvailableTrackIndexes();
                    playingNewSongInfo(sender, e);
                }
            }
            if(e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menuPlaylist = new ContextMenuStrip();
                ListViewItem item = musicList.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    menuPlaylist.Items.Add("Add to playlist", null, addToPlaylist);
                    menuPlaylist.Items.Add("Remove from playlist", null, RemoveFromPlaylist_Click);
                    if(settings.isDarkGS == false)
                    {
                        menuPlaylist.ForeColor = SystemColors.ControlText;
                        menuPlaylist.BackColor = SystemColors.ButtonHighlight;
                    }
                    else
                    {
                        menuPlaylist.ForeColor = SystemColors.ButtonHighlight;
                        menuPlaylist.BackColor = Color.FromArgb(35, 35, 35);
                    }
                    menuPlaylist.Font = new Font("Bahnschrift Condensed", 13);
                    musicList.ContextMenuStrip = menuPlaylist;
                    musicList.ContextMenuStrip.Show(musicList, new Point(e.X, e.Y));
                }
            }
        }
        private void addToPlaylist(object sender, EventArgs e)
        {
            if (musicList.SelectedItems.Count > 0)
            {
                ContextMenuStrip menuAddToPlaylist = new ContextMenuStrip();
                ListViewItem selectedItem = musicList.SelectedItems[0];
                int selectedTrackIndex = int.Parse(selectedItem.SubItems[1].Text) - 1;
                menuAddToPlaylist.Font = new Font("Bahnschrift Condensed", 13);

                if (settings.isDarkGS == false)
                {
                    menuAddToPlaylist.ForeColor = SystemColors.ControlText;
                    menuAddToPlaylist.BackColor = SystemColors.ButtonHighlight;
                }
                else 
                {
                    menuAddToPlaylist.ForeColor = SystemColors.ButtonHighlight;
                    menuAddToPlaylist.BackColor = Color.FromArgb(35, 35, 35);
                }
                ToolStripMenuItem playlistMenuItem;

                foreach (PlaylistClass playlist in playLists)
                {
                    playlistMenuItem = new ToolStripMenuItem(playlist.NameGS);
                    playlistMenuItem.Click += (s, ev) =>
                    {
                        trackClass selectedTrack = tracks[selectedTrackIndex];
                        bool trackExists = playlist.TrackListGS.Any(t => t.TitleGS == selectedTrack.TitleGS && t.ArtistGS == selectedTrack.ArtistGS);
                        if (!trackExists)
                        {
                            playlist.TrackListGS.Add(selectedTrack);
                            refreshJsonFile(settings.FolderList);
                        }
                        else
                        {
                            MessageBox.Show("Song is already on the playlist.", "Music Player");
                        }
                    };
                    menuAddToPlaylist.Items.Add(playlistMenuItem);
                }
                menuAddToPlaylist.Show(Cursor.Position);
            }
        }

        private void RemoveFromPlaylist_Click(object sender, EventArgs e)
        {
            if (musicList.SelectedItems.Count > 0 && currentPlaylistIndex>0)
            {
                ListViewItem selectedItem = musicList.SelectedItems[0];
                int selectedTrackIndex = int.Parse(selectedItem.SubItems[1].Text) - 1;

                PlaylistClass selectedPlaylist = playLists[currentPlaylistIndex];
                selectedPlaylist.TrackListGS.RemoveAll(track => track.TitleGS == tracks[selectedTrackIndex].TitleGS && track.ArtistGS == tracks[selectedTrackIndex].ArtistGS);
                refreshJsonFile(settings.FolderList);
                LoadTracksToListView(currentPlaylistIndex);
            }
            else
            {
                MessageBox.Show("Cannot remove track from main playlist. It stores all tracks from folders.", "Music Player");
            }
        }
        private void playingNewSongInfo(object sender, EventArgs e)
        {
            trackBar.Value = 0;
            trackBar.Maximum = (int)(audioFile.TotalTime.TotalMilliseconds * 1000);
            audioFile.Volume = (float)trackBarVolume.Value / 100;
            labelDuration.Text = audioFile.TotalTime.ToString(@"mm\:ss");

            Image image = GetAlbumCoverFromPath(tracks[currentTrackIndex].PathGS);
            pictureBoxCover.Image = image;
            setStatusSongPlaying(sender, e);
        }

        private bool CheckAndRemoveNonexistentTrack(int trackIndex)
        {
            if (!File.Exists(tracks[trackIndex].PathGS))
            {
                string deletedTitle = tracks[trackIndex].TitleGS;
                string deletedArtist = tracks[trackIndex].ArtistGS;

                foreach (PlaylistClass playlist in playLists)
                {
                    List<trackClass> tracksInPlaylist = playlist.TrackListGS;
                    int trackIndexInPlaylist = tracksInPlaylist.FindIndex(t => t.PathGS == tracks[trackIndex].PathGS);
                    if (trackIndexInPlaylist != -1)
                    {
                        tracksInPlaylist.RemoveAt(trackIndexInPlaylist);
                        playlist.TrackListGS = tracksInPlaylist;
                    }
                }
                tracks.RemoveAt(trackIndex);

                foreach (ListViewItem item in musicList.Items)
                {
                    if (item.SubItems[2].Text == deletedTitle && item.SubItems[3].Text == deletedArtist)
                    {
                        musicList.Items.Remove(item);
                        break;
                    }
                }
                trackCounter--;

                for (int i = 0; i < musicList.Items.Count; i++)
                {
                    musicList.Items[i].SubItems[1].Text = (i + 1).ToString();
                }
                refreshJsonFile(settings.FolderList);
                return true;
            }
            return false;
        }
        private void playPausePictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (isPlaying)
                {
                    outputDevice.Pause();
                    isPlaying = false;
                    isPaused = true;
                    pictureBoxPlayMusic.Visible = true;
                    pictureBoxStopMusic.Visible = false;
                    timer.Stop();
                }
                else
                {
                    setStatusSongPlaying(sender, e);
                }
            }
            catch (System.InvalidOperationException)
            {
                return;
            }
        }

        private async void FadeOutCurrentSong()
        {
            isFadingOut = true;
            float initialVolume = audioFile.Volume;
            float targetVolume = 0.0f;
            float fadeDuration = 5.0f; 
            float fadeStep = (initialVolume - targetVolume) / (fadeDuration * 10); 

            while (audioFile.Volume > targetVolume)
            {
                audioFile.Volume -= fadeStep;
                await Task.Delay(10000); 
            } 
        }
        private async void FadeInNewSong()
        {
            isFadingOut = false;
            float initialVolume = 0.0f;
            float targetVolume = (float)trackBarVolume.Value / 100;
            float fadeDuration = 5.0f; 
            float fadeStep = (targetVolume - initialVolume) / (fadeDuration * 10); 

            audioFile.Volume = initialVolume;
            outputDevice.Play();

            while (audioFile.Volume < targetVolume)
            {
                audioFile.Volume += fadeStep;
                await Task.Delay(100); 
            }
        }


        private void previousSong_Click(object sender, EventArgs e)
        {
            if (tracks.Count == 0)
            {
                MessageBox.Show("Brak piosenek na liœcie.", "B³¹d");
                return;
            }
            pictureBoxPlayMusic.Enabled = true;
            pictureBoxForwards.Enabled = true;
            pictureBoxBackwards.Enabled = true;

            outputDevice.Stop();

            currentTrackIndex--;
            if (currentTrackIndex < 0) currentTrackIndex = tracks.Count - 1;

            string filePath = tracks[currentTrackIndex].PathGS;

            if (!File.Exists(filePath))
            {
                CheckAndRemoveNonexistentTrack(currentTrackIndex);
                if (currentTrackIndex >= tracks.Count)
                {
                    currentTrackIndex = tracks.Count - 1;
                }
                filePath = tracks[currentTrackIndex].PathGS;
                LoadTracksToListView(currentPlaylistIndex);
                MessageBox.Show("The file has been deleted or is corrupted.", "Message");
            }

            audioFile = new AudioFileReader(filePath);

            outputDevice.Init(audioFile);
            playingNewSongInfo(sender, e);

            musicList.Items[currentTrackIndex].Selected = true;
            musicList.Select();
        }

        private void nextSong_Click(object sender, EventArgs e)
        {
            if (tracks.Count == 0)
            {
                MessageBox.Show("No songs on the list.", "B³¹d");
                return;
            }
            pictureBoxPlayMusic.Enabled = true;
            pictureBoxForwards.Enabled = true;
            pictureBoxBackwards.Enabled = true;

            outputDevice.Stop();

            if (playStatus == 2)
            {
                if (isRandom)
                {
                    if (availableTrackIndexes.Count == 0)
                    {
                        MessageBox.Show("All the songs have been played.", "End of the list");
                        if (isRandom) initializeAvailableTrackIndexes();
                        playPausePictureBox_Click(sender, e);
                        return;
                    }

                    Random rnd = new Random();
                    int randomIndex = rnd.Next(availableTrackIndexes.Count);
                    currentTrackIndex = availableTrackIndexes[randomIndex];
                    availableTrackIndexes.RemoveAt(randomIndex);
                }
                else
                {
                    currentTrackIndex++;
                    if (currentTrackIndex >= tracks.Count) currentTrackIndex = 0;
                }
            }

            string filePath = tracks[currentTrackIndex].PathGS;
            audioFile = new AudioFileReader(filePath);

            outputDevice.Init(audioFile);
            playingNewSongInfo(sender, e);

            musicList.Items[currentTrackIndex].Selected = true;
            musicList.Select();
        }
        private void setVolume(object sender, EventArgs e)
        {
            bool isAudioFileNotNull = (audioFile != null);
            bool isVolumeZero = (trackBarVolume.Value == 0);

            pictureBoxSpeakerNoSound.Visible = isVolumeZero;
            pictureBoxSpeaker.Visible = !isVolumeZero;

            if (isAudioFileNotNull)
            {
                if (isFadingOut)
                {
                    float targetVolume = (float)trackBarVolume.Value / 100;
                    audioFile.Volume = targetVolume;
                }
                else
                {
                    audioFile.Volume = (float)trackBarVolume.Value / 100;
                }
            }
        }
        private void rewindSong(object sender, EventArgs e)
        {
            if (outputDevice.PlaybackState == PlaybackState.Playing || outputDevice.PlaybackState == PlaybackState.Paused)
            {
                TimeSpan currentTime = audioFile.CurrentTime;
                currentTime = currentTime.Subtract(TimeSpan.FromSeconds(15));
                if (currentTime.TotalMilliseconds < 0)
                {
                    currentTime = TimeSpan.Zero;
                }
                audioFile.CurrentTime = currentTime;
                setStatusSongPlaying(sender, e);
            }
        }

        private void fastForwardSong(object sender, EventArgs e)
        {
            if (outputDevice.PlaybackState == PlaybackState.Playing || outputDevice.PlaybackState == PlaybackState.Paused)
            {
                TimeSpan currentTime = audioFile.CurrentTime;
                currentTime = currentTime.Add(TimeSpan.FromSeconds(15));
                if (currentTime.TotalMilliseconds > audioFile.TotalTime.TotalMilliseconds)
                {
                    currentTime = audioFile.TotalTime;
                }
                audioFile.CurrentTime = currentTime;
                setStatusSongPlaying(sender, e);
            }
        }
        private void SetDefaultInformations()
        {
            if (audioFile != null)
            {
                audioFile.Position = 0;
                outputDevice.Stop();
                isPlaying = false;
                isPaused = false;
                timer.Stop();
                pictureBoxPlayMusic.Visible = true;
                pictureBoxStopMusic.Visible = false;
                labelTimeCounter.Text = "00:00";
                trackBar.Value = 0;
            }
            else return;
        }
        private void SongIsOver(object sender, EventArgs e)
        {
            if (audioFile != null && labelTimeCounter.Text == audioFile.TotalTime.ToString(@"mm\:ss"))
            {
                if (playStatus == 0) SetDefaultInformations();
                if (playStatus == 1)
                {
                    System.Windows.Forms.MouseEventArgs me = null;
                    playSelectedTrack(sender, me);
                }
                if (playStatus == 2)
                {
                    nextSong_Click(sender, e);
                }
            }
        }

        private void changeStatus(object sender, EventArgs e)
        {
            if (playStatus == 0)
            {
                pictureBoxRepeatOne.Visible = true;
                pictureBoxRepeat.Visible = false;
            }
            if (playStatus == 1)
            {
                pictureBoxRepeatAll.Visible = true;
                pictureBoxRepeatOne.Visible = false;
            }
            if (playStatus == 2)
            {
                pictureBoxRepeatAll.Visible = false;
                pictureBoxRepeat.Visible = true;
                playStatus = 0;
                return;
            }
            else playStatus++;
            return;
        }
        private void changeRandomPlay(object sender, EventArgs e)
        {
            isRandom = !isRandom;
            pictureBoxRandom.Visible = !isRandom;
            pictureBoxRandomGreen.Visible = isRandom;

            if (isRandom)
            {
                initializeAvailableTrackIndexes();
            }
        }
        private void setStatusSongPlaying(object sender, EventArgs e)
        {
            outputDevice.Play();
            isPlaying = true;
            isPaused = false;
            pictureBoxPlayMusic.Visible = false;
            pictureBoxStopMusic.Visible = true;
            labelTitle.Text = tracks[currentTrackIndex].TitleGS + " ";
            labelArtist.Text = tracks[currentTrackIndex].ArtistGS + " ";
            timer.Start();
        }

        private void ScrollLabelIfTooLong(Label label, int maxLength, ref int timerCounter)
        {
            if (label.Text.Length > maxLength)
            {
                timerCounter++;
                if (timerCounter == 25)
                {
                    timerCounter = 0;
                    label.Text = label.Text.Substring(1) + label.Text.Substring(0, 1);
                }
            }
        }
        private Image GetAlbumCoverFromPath(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return defaultCover.Image;
            }

            byte[] pictureData;
            using (TagLib.File file = TagLib.File.Create(filePath))
            {
                pictureData = file.Tag.Pictures.FirstOrDefault()?.Data?.Data;
            }

            if (pictureData != null)
            {
                using (var ms = new MemoryStream(pictureData))
                {
                    return System.Drawing.Image.FromStream(ms);
                }
            }
            else
            {
                return defaultCover.Image;
            }
        }

        private void initializeAvailableTrackIndexes()
        {
            availableTrackIndexes.Clear();
            for (int i = 0; i < tracks.Count; i++)
            {
                availableTrackIndexes.Add(i);
                availableTrackIndexes.Remove(currentTrackIndex);
            }
        }

        public void DeleteSongsFromDirectory(string folderPath)
        {
            List<trackClass> tracksToDelete = trackClass.LoadFromDirectory(folderPath);
            foreach (trackClass trackToDelete in tracksToDelete)
            {
                if (tracks[currentTrackIndex].PathGS.ToString() == trackToDelete.PathGS.ToString())
                {
                    SetDefaultInformations();
                    labelDuration.Text = "00:00";
                    labelArtist.Text = "artist";
                    labelTitle.Text = "title";
                    pictureBoxCover.Image = defaultCover.Image;
                    pictureBoxPlayMusic.Enabled = false;
                    pictureBoxForwards.Enabled = false;
                    pictureBoxBackwards.Enabled = false;
                }
            }
            foreach (trackClass trackToDelete in tracksToDelete)
            {
                int index = tracks.FindIndex(track => track.PathGS == trackToDelete.PathGS);
                if (index != -1)
                {
                    tracks.RemoveAt(index);

                    foreach (PlaylistClass playlist in playLists)
                    {
                        if (playlist.NameGS == "Main playlist")
                        {
                            List<trackClass> tracksInPlaylist = playlist.TrackListGS;
                            int trackIndex = tracksInPlaylist.FindIndex(t => t.PathGS == trackToDelete.PathGS);
                            if (trackIndex != -1)
                            {
                                tracksInPlaylist.RemoveAt(trackIndex);

                                foreach (ListViewItem item in musicList.Items)
                                {
                                    if (item.SubItems[2].Text == trackToDelete.TitleGS && item.SubItems[3].Text == trackToDelete.ArtistGS)
                                    {
                                        musicList.Items.Remove(item);
                                        trackCounter--;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < musicList.Items.Count; i++)
            {
                musicList.Items[i].SubItems[1].Text = (i + 1).ToString();
            }
        }

        public void refreshJsonFile(List<string> DirectoriesList)
        {
            AppSettingsClass appSettings;
            if (File.Exists("appSettings.json"))
            {
                appSettings = JsonConvert.DeserializeObject<AppSettingsClass>(File.ReadAllText("appSettings.json"));
                appSettings.DirectoriesGS = DirectoriesList;
                appSettings.PlaylistsGS = playLists;
            }
            else
            {
                appSettings = new AppSettingsClass
                {
                    DirectoriesGS = DirectoriesList,
                    PlaylistsGS = new List<PlaylistClass> { new PlaylistClass { NameGS = "", TrackListGS = new List<trackClass>() } }
                };
            }

            foreach (var playlist in appSettings.PlaylistsGS)
            {
                var existingPlaylist = playLists.FirstOrDefault(p => p.NameGS == playlist.NameGS);
                if (existingPlaylist != null)
                {
                    playlist.TrackListGS = existingPlaylist.TrackListGS.Select(track => new trackClass { PathGS = track.PathGS, AlbumGS = track.AlbumGS, ArtistGS = track.ArtistGS, DurationGS = track.DurationGS, TitleGS = track.TitleGS }).ToList();
                }
                else
                {
                    playLists.Add(playlist);
                }
            }

            var json = JsonConvert.SerializeObject(appSettings, Formatting.Indented);
            File.WriteAllText("appSettings.json", json);
        }
        private void setVolumeBySpeaker(object sender, EventArgs e)
        {
            if (audioFile != null)
            {
                if (audioFile.Volume > 0)
                {
                    previousVolume = audioFile.Volume;
                    trackBarVolume.Value = 0;
                    audioFile.Volume = 0;
                    pictureBoxSpeakerNoSound.Visible = true;
                    pictureBoxSpeaker.Visible = false;
                }
                else
                {
                    trackBarVolume.Value = (int)(previousVolume * 100);
                    audioFile.Volume = previousVolume;
                    pictureBoxSpeakerNoSound.Visible = false;
                    pictureBoxSpeaker.Visible = true;
                }
            }
            else
            {
                if (trackBarVolume.Value > 0)
                {
                    previousVolume = (float)trackBarVolume.Value / 100;
                    trackBarVolume.Value = 0;
                    pictureBoxSpeakerNoSound.Visible = true;
                    pictureBoxSpeaker.Visible = false;
                }
                else
                {
                    trackBarVolume.Value = (int)(previousVolume * 100);
                    pictureBoxSpeakerNoSound.Visible = false;
                    pictureBoxSpeaker.Visible = true;
                }
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                try
                {
                    trackBar.Value = (int)(audioFile.CurrentTime.TotalMilliseconds * 1000);
                    labelTimeCounter.Text = audioFile.CurrentTime.ToString(@"mm\:ss");

                    double remainingTime = audioFile.Length - audioFile.Position;

                    if (remainingTime <= 500000*5)
                    {
                        FadeOutCurrentSong();
                        //FadeInNewSong();
                    }
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    trackBar.Value = trackBar.Maximum;
                }
            }

            ScrollLabelIfTooLong(labelTitle, 20, ref timerCounterTitle);
            ScrollLabelIfTooLong(labelArtist, 16, ref timerCounterArtist);
        }
        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            if (audioFile != null) audioFile.CurrentTime = TimeSpan.FromMilliseconds(trackBar.Value / 1000);
        }
        private void openSettings(object sender, EventArgs e)
        {
            panelSettings.Visible = !panelSettings.Visible;
        }
        private void ColumnWidthChangingMusicList(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = musicList.Columns[e.ColumnIndex].Width;
        }
        private void ColumnWidthChangingPlaylist(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewPlaylist.Columns[e.ColumnIndex].Width;
        }
        private void panelSettingsPaint(object sender, PaintEventArgs e)
        {
            settings.Dock = DockStyle.Fill;
            panelSettings.Controls.Add(settings);
        }
        private void AddNewSongsButtonClick(object sender, EventArgs e)
        {
            AddNewSongs(trackClass.AddNewSongs());
        }
        public void LoadToListViewFromFolder(string folderPath)
        {
            AddNewSongs(trackClass.LoadFromDirectory(folderPath));
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void MinimizeWindow(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void CloseApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

