using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Chapter4
{

    class LinqTests
    {
        public void init()
        {
            string[] artistNames = new string[] { "Rob Miles", "Fred Bloggs",
                                      "The Bloggs Singers", "Immy Brown" };
            string[] titleNames = new string[] { "My Way", "Your Way", "His Way", "Her Way",
                                     "Milky Way" };

            List<Artist> artists = new List<Artist>();
            List<MusicTrack> musicTracks = new List<MusicTrack>();

            Random rand = new Random(1);

            foreach (string artistName in artistNames)
            {
                Artist newArtist = new Artist { Name = artistName };
                artists.Add(newArtist);
                foreach (string titleName in titleNames)
                {
                    MusicTrack newTrack = new MusicTrack
                    {
                        Artist = newArtist,
                        Title = titleName,
                        Length = rand.Next(20, 600)
                    };
                    musicTracks.Add(newTrack);
                }
            }

            selectValue(musicTracks);
        }

        public void selectValue(List<MusicTrack> musicTracks)
        {
            IEnumerable<MusicTrack> tracks = from track in musicTracks where track.Title == "My Way" select track;

            var artistSummary = from track in musicTracks
                                group track by track.Artist
           into artistTrackSummary
                                select new
                                {
                                    ID = artistTrackSummary.Key,
                                    Length = artistTrackSummary.Sum(x => x.Length)
                                };

            foreach (MusicTrack track in tracks)
            {
                Console.WriteLine("Artist:{0} Title:{1}", track.Artist.Name, track.Title);
            }


        }

        public void LinqToXML()
        {
            XElement MusicTracks = new XElement("MusicTracks",
                new List<XElement>
                {
                    new XElement("MusicTrack",
                        new XElement("Artist", "Rob Miles"),
                        new XElement("Title", "My Way")),
                    new XElement("MusicTrack",
                        new XElement("Artist", "Immy Brown"),
                        new XElement("Title", "Her Way"))
                }
             );
        }

    }
}
