using DevFreela.Core.Entities.Projects;

namespace DevFreela.Core.Entities.Users;

public class User : BaseEntity
{
    public User(string fisrtName, string lastName, string email, string passwordHash, string role, DateTime birthDate)
    {
        FisrtName = fisrtName;
        LastName = lastName;
        Email = email;
        BirthDate = birthDate;
        PasswordHash = passwordHash;
        Role = role;

        CreatedAt = DateTime.Now;
        Active = true;
        Skills = [];
        FreelanceProject = [];
        OwnedProject = [];
    }

    public string FisrtName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash{ get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool Active { get; private set; }
    public string Role { get; private set; }

    public List<UserSkill> Skills { get; private set; }
    public List<Project> FreelanceProject { get; private set; }
    public List<Project> OwnedProject { get; private set; }
    public List<ProjectComment> Comments { get; private set; }
}
