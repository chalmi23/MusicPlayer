using NAudio.Wave;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int trackCounter = 0;
        int currentTrackIndex;
        int playStatus = 0; //0 - jednorazowe odtworzenie, 1 - powtarzanie jednej piosenki, 2 - powtarzanie wszystkich piosenek
        float previousVolume = 1;

        bool isPlaying = false;
        bool isPaused = false;
        bool isRandom = false;

        Settings settings = new Settings();
        AudioFileReader audioFile;
        WaveOutEvent outputDevice;

        private List<trackClass> tracks = new List<trackClass>();
        private List<int> availableTrackIndexes = new List<int>();

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();

            musicList.View = View.Details;
            musicList.SmallImageList = new ImageList();

            outputDevice = new WaveOutEvent();

            outputDevice.PlaybackStopped += SongIsOver;
            trackBar.Scroll += TrackBar_Scroll;

            Controls.Add(trackBar);

            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }
        private List<Image> albumCovers = new List<Image>();

        private void AddNewSongsButtonClick(object sender, EventArgs e)
        {
            List<trackClass> tracksAdded = trackClass.AddNewSongs();
            ImageList imageList = musicList.SmallImageList ?? new ImageList();
            imageList.ImageSize = new Size(48, 48);

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
                        Image coverImage = Image.FromStream(ms);
                        index = albumCovers.FindIndex(img => img.RawFormat.Equals(coverImage.RawFormat) && img.Size.Equals(coverImage.Size));
                        if (index == -1)
                        {
                            index = albumCovers.Count;
                            albumCovers.Add(coverImage);
                            imageList.Images.Add(coverImage);
                        }
                    }
                }
                item.ImageIndex = index;
            }
            musicList.SmallImageList = imageList;
        }

        private int timerCounterTitle = 0;
        private int timerCounterArtist = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                try
                {
                    trackBar.Value = (int)(audioFile.CurrentTime.TotalMilliseconds * 1000);
                    labelTimeCounter.Text = audioFile.CurrentTime.ToString(@"mm\:ss");
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
        private void playSelectedTrack(object sender, EventArgs e)
        {
            if (musicList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = musicList.SelectedItems[0];
                int trackIndex = int.Parse(selectedItem.SubItems[1].Text) - 1;

                if (isPlaying || isPaused) outputDevice.Stop();

                string filePath = tracks[trackIndex].PathGS;
                audioFile = new AudioFileReader(filePath);

                outputDevice.Init(audioFile);
                currentTrackIndex = trackIndex;

                if (isRandom) initializeAvailableTrackIndexes();
                playingNewSongInfo(sender, e);
                DisplayCoverImage();
            }
        }
        private void playingNewSongInfo(object sender, EventArgs e)
        {
            trackBar.Value = 0;
            trackBar.Maximum = (int)(audioFile.TotalTime.TotalMilliseconds * 1000);
            audioFile.Volume = (float)trackBarVolume.Value / 100;
            labelDuration.Text = audioFile.TotalTime.ToString(@"mm\:ss");

            DisplayCoverImage();
            setStatusSongPlaying(sender, e);
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

        private void previousSong_Click(object sender, EventArgs e)
        {
            if (tracks.Count == 0)
            {
                MessageBox.Show("Brak piosenek na li�cie.", "B��d");
                return;
            }

            outputDevice.Stop();

            currentTrackIndex--;
            if (currentTrackIndex < 0) currentTrackIndex = tracks.Count - 1;

            string filePath = tracks[currentTrackIndex].PathGS;
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
                MessageBox.Show("Brak piosenek na li�cie.", "B��d");
                return;
            }

            outputDevice.Stop();

            if (playStatus == 2)
            {
                if (isRandom)
                {
                    if (availableTrackIndexes.Count == 0) // je�li brak dost�pnych utwor�w
                    {
                        MessageBox.Show("Wszystkie piosenki z listy zosta�y ju� odtworzone.", "Koniec listy");
                        if (isRandom) initializeAvailableTrackIndexes();
                        playPausePictureBox_Click(sender, e);
                        return;
                    }

                    Random rnd = new Random();
                    int randomIndex = rnd.Next(availableTrackIndexes.Count); // losowy indeks z listy dost�pnych utwor�w
                    currentTrackIndex = availableTrackIndexes[randomIndex]; // ustawienie aktualnego indeksu
                    availableTrackIndexes.RemoveAt(randomIndex); // usuni�cie wybranego indeksu z listy dost�pnych utwor�w
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
                audioFile.Volume = (float)trackBarVolume.Value / 100;
            }
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
        private void SongIsOver(object sender, StoppedEventArgs e)
        {
            if (audioFile != null && labelTimeCounter.Text == audioFile.TotalTime.ToString(@"mm\:ss"))
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

                if (playStatus == 1)
                {
                    playSelectedTrack(sender, e);
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

        private void DisplayCoverImage()
        {
            byte[] pictureData = tracks[currentTrackIndex].CoverGS?.Data?.Data;

            Image image = null;
            if (pictureData != null)
            {
                using (var ms = new MemoryStream(pictureData))
                {
                    image = Image.FromStream(ms);
                }
            }
            pictureBoxCover.Image = image;
            labelTitle.Text = tracks[currentTrackIndex].TitleGS + " ";
            labelArtist.Text = tracks[currentTrackIndex].ArtistGS + " ";
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
        private void ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = musicList.Columns[e.ColumnIndex].Width;
        }
        private void panelSettingsPaint(object sender, PaintEventArgs e)
        {
            settings.Dock = DockStyle.Fill;
            panelSettings.Controls.Add(settings);
        }
        private void openSettings(object sender, EventArgs e)
        {
            panelSettings.Visible = !panelSettings.Visible;
        }
    }
}
