namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            musicList.View = View.Details; // W³¹czenie wyœwietlania nag³ówków

            musicList.Columns.Add("Lp.", 50);
            musicList.Columns.Add("Ok³adka", 50);
            musicList.Columns.Add("Tytu³", 300);
            musicList.Columns.Add("Wykonawca", 150);
            musicList.Columns.Add("Album", 250);
            musicList.Columns.Add("Czas trwania", 96);


            // Utworzenie listy obrazów dla kontrolki ListView
            musicList.SmallImageList = new ImageList();
            musicList.SmallImageList.ImageSize = new Size(48, 48);
        }

        int lp = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            lp++;

            openFileDialog1.Title = "Wybierz plik muzyczny";
            openFileDialog1.Filter = "Pliki muzyczne (*.mp3, *.wav, *.mp4, *.flac)|*.mp3;*.wav;*.mp4;*.flac";
            openFileDialog1.Multiselect = true;

            // Wyœwietlenie okna dialogowego i sprawdzenie, czy u¿ytkownik wybra³ plik
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Pobranie metadanych z pliku MP4
                TagLib.File file = TagLib.File.Create(openFileDialog1.FileName);

                string title = file.Tag.Title;
                string artist = file.Tag.Performers.Length > 0 ? file.Tag.Performers[0] : ""; if (artist == "") artist = "unknown";
                string album = file.Tag.Album;
                string duration = file.Properties.Duration.ToString(@"mm\:ss");
                TagLib.IPicture pic = file.Tag.Pictures[0];

                trackClass track = new trackClass(title,artist,album,duration, pic);
                ListViewItem item = new ListViewItem(new string[] { lp.ToString(), "", title, artist, album, duration });
                if (file.Tag.Pictures.Length > 0)
                {



                }
                musicList.Items.Add(item);
                // Dodanie elementu do listview z wybranymi metadanymi
                musicList.Items.Add(item);
            }
        }
    }
}
