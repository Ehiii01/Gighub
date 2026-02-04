namespace GigHub.Dtos;

public class UserDto
{
    public string Id { get; set; }
    public string Name { get; set; }


    public static UserDto GetUserResponse(string id, string name)
    {
        return new UserDto { Id = id, Name = name };
    }
}