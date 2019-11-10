public class Song
{
    private const int ArtistNameMinLength = 3;
    private const int ArtistNameMaxLength = 20;
    private const int SongNameMinLength = 3;
    private const int SongNameMaxLength = 30;
    private const int SongMaxMinutes = 14;

    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public string ArtistName
    {
        get => this.artistName;
        set
        {
            if (value.Length < ArtistNameMinLength || value.Length > ArtistNameMaxLength)
            {
                throw new InvalidArtistNameException();
            }

            this.artistName = value;
        }
    }

    public string SongName
    {
        get => this.songName;

        set
        {
            if (value.Length < SongNameMinLength || value.Length > SongNameMaxLength)
            {
                throw new InvalidSongNameException();
            }

            this.songName = value;
        }
    }

    public int Minutes
    {
        get => this.minutes;

        set
        {
            if (value < 0 || value > SongMaxMinutes)
            {
                throw new InvalidSongMinutesException();
            }

            this.minutes = value;
        }
    }

    public int Seconds
    {
        get => this.seconds;

        set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }

            this.seconds = value;
        }
    }
}