using GigHub.Models;

namespace GigHub.Dtos;

public class GenreDto
{
    public byte Id { get; set; }

    public string Name { get; set; }


    public static GenreDto GetGenreResponse(Genre genreResult)
    {
        return new GenreDto
        {
            Id = genreResult.Id,
            Name = genreResult.Name,
        };
    }
}