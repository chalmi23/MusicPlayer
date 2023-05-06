using NAudio.Wave;
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


        AudioFileReader audioFile;
        WaveOutEvent outputDevice;

        private List<trackClass> tracks = new List<trackClass>();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();

            musicList.View = View.Details;
            musicList.SmallImageList = new ImageList();
            musicList.SmallImageList.ImageSize = new Size(48, 48);

            outputDevice = new WaveOutEvent();

            outputDevice.PlaybackStopped += SongIsOver;
            trackBar.Scroll += TrackBar_Scroll;

            Controls.Add(trackBar);

            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        private void AddNewSongsButtonClick(object sender, EventArgs e)
        {
            List<trackClass> tracksAdded = trackClass.AddNewSongs();
            foreach (trackClass track in tracksAdded)
            {
                trackCounter++;
                ListViewItem item = new ListViewItem(new string[] { "", trackCounter.ToString(), "brak", track.TitleGS, track.ArtistGS, track.AlbumGS, track.DurationGS });
                musicList.Items.Add(item);
                tracks.Add(track);
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
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    trackBar.Value = trackBar.Maximum;
                }
            }
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            audioFile.CurrentTime = TimeSpan.FromMilliseconds(trackBar.Value / 1000);
        }
        private void playMusic(object sender, EventArgs e)
        {
            if (musicList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = musicList.SelectedItems[0];
                int trackIndex = int.Parse(selectedItem.SubItems[1].Text) - 1;

                if (isPlaying || isPaused) outputDevice.Stop();

                string filePath = tracks[trackIndex].PathGS;
                audioFile = new AudioFileReader(filePath);

                outputDevice.Init(audioFile);
                outputDevice.Play();
                playingNewSongInfo(sender, e);
                currentTrackIndex = trackIndex;
            }
        }
        private void playingNewSongInfo(object sender, EventArgs e)
        {
            trackBar.Value = 0;
            trackBar.Maximum = (int)(audioFile.TotalTime.TotalMilliseconds * 1000);
            audioFile.Volume = (float)trackBarVolume.Value / 100;
            labelDuration.Text = audioFile.TotalTime.ToString(@"mm\:ss");
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
                MessageBox.Show("Brak piosenek na liœcie.", "B³¹d");
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
                MessageBox.Show("Brak piosenek na liœcie.", "B³¹d");
                return;
            }

            outputDevice.Stop();

            currentTrackIndex++;
            if (currentTrackIndex >= tracks.Count) currentTrackIndex = 0;

            string filePath = tracks[currentTrackIndex].PathGS;
            audioFile = new AudioFileReader(filePath);

            outputDevice.Init(audioFile);
            outputDevice.Play();
            playingNewSongInfo(sender, e);

            musicList.Items[currentTrackIndex].Selected = true;
            musicList.Select();
        }
        private void ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = musicList.Columns[e.ColumnIndex].Width;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            audioFile.CurrentTime = TimeSpan.FromMilliseconds(300);
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
                    playMusic(sender, e);
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

        private void setStatusSongPlaying(object sender, EventArgs e)
        {
            outputDevice.Play();
            isPlaying = true;
            isPaused = false;
            pictureBoxPlayMusic.Visible = false;
            pictureBoxStopMusic.Visible = true;
            timer.Start();
        }
    }
}
