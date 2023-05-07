
namespace WinFormsApp1
{
    internal class PlaylistClass
    {
        private string Name;
        private List<trackClass> trackList;

        public string Name1 { get => Name; set => Name = value; }
        internal List<trackClass> TrackList { get => trackList; set => trackList = value; }
    }
}
