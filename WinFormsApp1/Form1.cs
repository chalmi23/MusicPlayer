using NAudio.Wave;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int trackCounter = 0;
        private List<trackClass> tracks = new List<trackClass>();
        bool isPlaying = false;
        bool isPaused = false;
        AudioFileReader audioFile;
        WaveOutEvent outputDevice;
        int currentTrackIndex;
        public Form1()
        {
            InitializeComponent();

            musicList.View = View.Details; // W³¹czenie wyœwietlania nag³ówków
            musicList.SmallImageList = new ImageList();
            musicList.SmallImageList.ImageSize = new Size(48, 48);
            musicList.FullRowSelect = true;

            outputDevice = new WaveOutEvent();
        }

        private void AddNewSongs(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Choose audio file";
            openFileDialog1.Filter = "Audio files (*.mp3, *.wav, *.mp4, *.flac)|*.mp3;*.wav;*.mp4;*.flac";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    trackClass track = new trackClass();
                    TagLib.File file = TagLib.File.Create(fileName);

                    if (!string.IsNullOrEmpty(file.Tag.Title)) track.TitleGS = file.Tag.Title;
                    else track.TitleGS = "unknown";

                    if (file.Tag.Performers != null && file.Tag.Performers.Length > 0) track.ArtistGS = file.Tag.Performers[0];
                    else track.ArtistGS = "unknown";

                    if (!string.IsNullOrEmpty(file.Tag.Album)) track.AlbumGS = file.Tag.Album;
                    else track.AlbumGS = "unknown";

                    if (!string.IsNullOrEmpty(file.Properties.Duration.ToString(@"mm\:ss"))) track.DurationGS = file.Properties.Duration.ToString(@"mm\:ss");
                    else track.DurationGS = "unknown";

                    track.PathGS = fileName;

                    trackCounter++;
                    tracks.Add(track);

                    ListViewItem item = new ListViewItem(new string[] { "", trackCounter.ToString(), "brak", track.TitleGS, track.ArtistGS, track.AlbumGS, track.DurationGS });
                    musicList.Items.Add(item);
                }
            }
        }
        private void playMusic(object sender, EventArgs e)
        {
            if (musicList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = musicList.SelectedItems[0];
                int trackIndex = int.Parse(selectedItem.SubItems[1].Text) - 1;

                if (isPlaying && currentTrackIndex == trackIndex) return;

                if (isPlaying || isPaused) outputDevice.Stop();


                string filePath = tracks[trackIndex].PathGS;
                audioFile = new AudioFileReader(filePath);

                outputDevice.Init(audioFile);
                outputDevice.Play();
                isPlaying = true;
                currentTrackIndex = trackIndex;
                pictureBoxPlayMusic.Visible = false;
                pictureBoxStopMusic.Visible = true;
            }
        }
        private void playPausePictureBox_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                outputDevice.Pause();
                isPlaying = false;
                isPaused = true;
                pictureBoxPlayMusic.Visible = true;
                pictureBoxStopMusic.Visible = false;
            }
            else
            {
                outputDevice.Play();
                isPlaying = true;
                isPaused = false;
                pictureBoxPlayMusic.Visible = false;
                pictureBoxStopMusic.Visible = true;
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
            outputDevice.Play();
            isPlaying = true;
            isPaused = false;
            pictureBoxPlayMusic.Visible = false;
            pictureBoxStopMusic.Visible = true;

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
            isPlaying = true;
            isPaused = false;
            pictureBoxPlayMusic.Visible = false;
            pictureBoxStopMusic.Visible = true;

            musicList.Items[currentTrackIndex].Selected = true;
            musicList.Select();
        }
        private void ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = musicList.Columns[e.ColumnIndex].Width;
        }
    }
}
