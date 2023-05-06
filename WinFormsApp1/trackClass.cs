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
    }
}
