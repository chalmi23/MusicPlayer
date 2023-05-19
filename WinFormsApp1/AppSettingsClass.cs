using WinFormsApp1;

internal class AppSettingsClass
{
    public List<string> DirectoriesGS { get; set; }
    public List<PlaylistClass> PlaylistsGS { get; set; }
    public AppSettingsClass()
    {
        DirectoriesGS = new List<string>();
        PlaylistsGS = new List<PlaylistClass>();
    }
}