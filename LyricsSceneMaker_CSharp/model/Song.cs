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
        public string SelectFile { get; set; } = string.Empty;
        public string[] Lyrics { get; set; } = null;
        public long[] Notes { get; set; } = null;

        public Song(string SongName, string Artist, string SelectFile, string[] Lyrics)
        {
            this.SongName = SongName;
            this.Artist = Artist;
            this.SelectFile = SelectFile;
            this.Lyrics = Lyrics;
        }
    }
}
