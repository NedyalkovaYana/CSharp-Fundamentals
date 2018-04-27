using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Song> playlist = new List<Song>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            try
            {
                var songData = Console.ReadLine()
                    .Split(new[] {';', ':'}, StringSplitOptions.RemoveEmptyEntries);
                var artist = songData[0];
                var song = songData[1];
                var songMin = int.Parse(songData[2]);
                var songSecond = int.Parse(songData[3]);
                var newSong = new Song(artist, song, songMin, songSecond);
                playlist.Add(newSong);
                Console.WriteLine("Song added.");
            }
            catch (InvalidSongException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException fex)
            {
                Console.WriteLine("Invalid song length.");
            }
        }
        Console.WriteLine($"Songs added: {playlist.Count}");
        int totalMinutes = playlist.Sum(m => m.Minutes);
        var totalSeconds = playlist.Sum(s => s.Seconds);
        totalSeconds += totalMinutes * 60;
        var finalMinutes = totalSeconds / 60;
        var finalSeconds = totalSeconds % 60;
        var finalHours = finalMinutes / 60;
        finalMinutes %= 60;
        Console.WriteLine
            ($"Playlist length: {finalHours}h {finalMinutes}m {finalSeconds}s");
    }
}
