using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    class CreateJSON
    {
        public void test()
        {
            MusicTrack track = new MusicTrack(artist: "Rob Miles", title: "My Way",
                                              length: 150);
            string json = JsonConvert.SerializeObject(track);
            Console.Write("JSON: ");
            Console.WriteLine(json);

            MusicTrack trackRead = JsonConvert.DeserializeObject<MusicTrack>(json);
            Console.Write("Read back: ");
            Console.WriteLine(trackRead);

            List<MusicTrack> album = new List<MusicTrack>();

            string[] trackNames = new[] { "My Way", "Your Way", "Their Way",
                                          "The Wrong Way" };

            foreach (string trackName in trackNames)
            {
                MusicTrack newTrack = new MusicTrack(artist: "Rob Miles",
                                                      title: trackName, length: 150);
                album.Add(newTrack);
            }

            string jsonArray = JsonConvert.SerializeObject(album);
            Console.Write("JSON: ");
            Console.WriteLine(jsonArray);

            List<MusicTrack> albumRead = JsonConvert.DeserializeObject<List<MusicTrack>>
            (jsonArray);

            Console.WriteLine("Read back: ");
            foreach (MusicTrack readTrack in albumRead)
            {
                Console.WriteLine(readTrack);
            }
            Console.ReadKey();

        }
    }
}
