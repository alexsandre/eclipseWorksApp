namespace EclipseWorksApp.Domain.Entities;

public class User : EntityBase
{
    public User(string name, Profile profile)
    {
        Name = name;
        Profile = profile;
    }
    
    public string Name { get; }
    public Profile Profile { get; }
}
