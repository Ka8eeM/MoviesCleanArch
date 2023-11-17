using Movies.Core.Entites.Base;

namespace Movies.Core.Entites;

public class Movie : Entity
{

    private Movie(
        string movieName,
        string directorName,
        string releaseYear)
    {
        MovieName = movieName;
        DirectorName = directorName;
        ReleaseYear = releaseYear;
    }

    public static Movie Create(
        string movieName,
        string directorName,
        string releaseYear)
    {
        return new Movie(movieName, directorName, releaseYear);
    }
    public string MovieName { get; private set; } = string.Empty;
    public string DirectorName { get; private set; } = string.Empty;
    public string ReleaseYear { get; private set; } = string.Empty;
}