using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    class MusicTrack
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }

        // ToString that overrides the behavior in the base class
        public override string ToString()
        {
            return Artist + " " + Title + " " + Length.ToString() + "seconds long";
        }

        public MusicTrack(string artist, string title, int length)
        {
            Artist = artist;
            Title = title;
            Length = length;
        }
    }
}
