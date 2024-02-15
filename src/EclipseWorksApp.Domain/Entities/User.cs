using System.Collections.ObjectModel;

namespace EclipseWorksApp.Domain.Entities;

public class User : EntityBase
{
    private User() { }

    public User(string name, Profile profile)
    {
        Name = name;
        Profile = profile;
    }
    
    public string Name { get; }
    public Profile Profile { get; }

    public ICollection<Project> Projects { get; } = new HashSet<Project>();
    public ICollection<Comment> Comments{ get; } = new HashSet<Comment>();
}
