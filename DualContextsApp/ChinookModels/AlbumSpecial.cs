using DualContextsApp.Classes;

namespace DualContextsApp.ChinookModels;

public class AlbumSpecial
{
    /// <summary>
    /// Primary key
    /// </summary>
    public int AlbumId { get; set; }

    /// <summary>
    /// Title of album
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Identifier of artist to artist table
    /// </summary>
    public int ArtistId { get; set; }

    /// <summary>
    /// Milliseconds play time
    /// </summary>
    public int Milliseconds { get; set; }

    public int Minutes { get; set; }

    public string SongName { get; set; }

    public string Time => Milliseconds.ShowTime();


}