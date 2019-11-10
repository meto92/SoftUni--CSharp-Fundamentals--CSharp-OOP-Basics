using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        int songsToAddCount = int.Parse(Console.ReadLine());

        List<Song> playlist = new List<Song>();

        int playlistDurationInSeconds = 0;

        for (int i = 0; i < songsToAddCount; i++)
        {
            string[] songParams = Console.ReadLine().Split(';');

            string artistName = songParams[0];
            string songName = songParams[1];
            int[] songLengthParams = null;

            try
            {
                try
                {
                    songLengthParams = songParams[2]
                        .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                }
                catch (Exception)
                {
                    throw new InvalidSongLengthException();
                }

                int minutes = songLengthParams[0],
                    seconds = songLengthParams[1];

                Song song = new Song(artistName, songName, minutes, seconds);

                playlist.Add(song);
                playlistDurationInSeconds += 60 * minutes + seconds;

                Console.WriteLine("Song added.");
            }
            catch (InvalidSongException ise)
            {
                Console.WriteLine(ise.Message);
            }
        }

        TimeSpan playlistDuration = new TimeSpan(0, 0, playlistDurationInSeconds);

        Console.WriteLine($"Songs added: {playlist.Count}");
        Console.WriteLine("Playlist length: {0}h {1}m {2}s",
            playlistDuration.Hours,
            playlistDuration.Minutes,
            playlistDuration.Seconds);
    }
}