using GigHub.Models;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Dtos;

public class GigDto
{
    public int Id { get; set; }
    public bool IsCancelled { get; set; }

    public UserDto Artist { get; set; }

    public DateTime DateTime { get; set; }

    public string Venue { get; set; }

    public GenreDto Genre { get; set; }


    public static GigDto GetGigResponse(Gig result)
    {
        UserDto artist = UserDto.GetUserResponse(result.Artist.Id, result.Artist.Name);

        GenreDto genre = GenreDto.GetGenreResponse(result.Genre);

        GigDto gigDto = new GigDto
        {
            DateTime = result.DateTime,
            Venue = result.Venue,
            IsCancelled = result.IsCanceled,
            Id = result.Id,
            Artist = artist,
            Genre = genre

        };
        return gigDto;
    }
}