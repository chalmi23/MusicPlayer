using NAudio.Wave;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int trackCounter = 0;
        private List<trackClass> tracks = new List<trackClass>();
        public Form1()
        {
            InitializeComponent();

            musicList.View = View.Details; // W��czenie wy�wietlania nag��wk�w
            musicList.SmallImageList = new ImageList();
            musicList.SmallImageList.ImageSize = new Size(48, 48);
            musicList.FullRowSelect = true;
        }
        private void AddNewSongs(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Wybierz plik muzyczny";
            openFileDialog1.Filter = "Pliki muzyczne (*.mp3, *.wav, *.mp4, *.flac)|*.mp3;*.wav;*.mp4;*.flac";
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

                    track.PathGS = fileName; // przypisanie �cie�ki do w�a�ciwo�ci PathGS

                    trackCounter++;
                    tracks.Add(track);

                    ListViewItem item = new ListViewItem(new string[] { "", trackCounter.ToString(), "brak", track.TitleGS, track.ArtistGS, track.AlbumGS, track.DurationGS });
                    musicList.Items.Add(item);
                }
            }
        }
        private void ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = musicList.Columns[e.ColumnIndex].Width;
        }

        private void playMusic(object sender, EventArgs e)
        {
            if (musicList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = musicList.SelectedItems[0];
                int trackIndex = int.Parse(selectedItem.SubItems[1].Text) - 1;
                string filePath = tracks[trackIndex].PathGS;

                var audioFile = new AudioFileReader(filePath);
                var outputDevice = new WaveOutEvent();
                
                outputDevice.Init(audioFile);
                outputDevice.Play();
                
            }
        }
    }
}
