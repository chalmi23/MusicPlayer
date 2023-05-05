using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace WinFormsApp1
{
    internal class trackClass
    {
        private string Title;
        private string Artist;
        private string Album;
        private string Duration;
        private IPicture Cover;

        public trackClass(string title, string artist, string album, string duration, IPicture cover)
        {
            Title = title;
            Artist = artist;
            Album = album;
            Duration = duration;
            Cover = cover;
        }

        public string Title1 { get => Title; set => Title = value; }
        public string Artist1 { get => Artist; set => Artist = value; }
        public string Album1 { get => Album; set => Album = value; }
        public string Duration1 { get => Duration; set => Duration = value; }
        public IPicture Cover1 { get => Cover; set => Cover = value; }
    }
}
