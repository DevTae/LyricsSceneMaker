using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LyricsSceneMaker_CSharp.model
{
    class Song
    {
        public string SongName { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public string YoutubeURL { get; set; } = string.Empty;
        public List<string> Lyrics { get; set; } = null;

        public Song(string SongName, string Artist, string YoutubeURL, List<string> Lyrics)
        {
            this.SongName = SongName;
            this.Artist = Artist;
            this.YoutubeURL = YoutubeURL;

        }
    }
}
