
namespace WinFormsApp1
{
    internal class PlaylistClass
    {
        private string Name;
        private List<trackClass> trackList;

        public string NameGS { get => Name; set => Name = value; }
        internal List<trackClass> TrackListGS { get => trackList; set => trackList = value; }
    }
}
