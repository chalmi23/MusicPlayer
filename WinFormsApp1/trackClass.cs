using TagLib;

namespace WinFormsApp1
{
    internal class trackClass
    {
        private IPicture Cover;
        private string Title = "";
        private string Artist = "";
        private string Album = "";
        private string Duration = "";
        private string Path = "";
        public trackClass()
        {
        }

        public string TitleGS { get => Title; set => Title = value; }
        public string ArtistGS { get => Artist; set => Artist = value; }
        public string AlbumGS { get => Album; set => Album = value; }
        public string DurationGS { get => Duration; set => Duration = value; }
        public IPicture CoverGS { get => Cover; set => Cover = value; }
        public string PathGS { get => Path; set => Path = value; }

        public static List<trackClass> AddNewSongs()
        {
            List<trackClass> tracks = new List<trackClass>();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Choose audio file";
            openFileDialog1.Filter = "Audio files (*.mp3, *.wav, *.mp4)|*.mp3;*.wav;*.mp4";
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

                    tracks.Add(track);

                }
            }
            return tracks;
        }
    }

}
