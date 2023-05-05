namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int trackCounter = 0;
        public Form1()
        {
            InitializeComponent();

            musicList.View = View.Details; // W³¹czenie wyœwietlania nag³ówków
            musicList.SmallImageList = new ImageList();
            musicList.SmallImageList.ImageSize = new Size(48, 48);

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

                    trackCounter++;
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
    }
}
