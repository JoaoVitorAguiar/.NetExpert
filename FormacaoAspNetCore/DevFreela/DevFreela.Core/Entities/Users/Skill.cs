namespace DevFreela.Core.Entities.Users;

public class Skill : BaseEntity
{

    public Skill(string description)
    {
        Description = description;
        CreatedAt = DateTime.Now;
    }

    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
}
