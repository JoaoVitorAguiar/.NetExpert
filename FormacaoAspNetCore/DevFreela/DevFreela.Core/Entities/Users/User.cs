using DevFreela.Core.Entities.Projects;

namespace DevFreela.Core.Entities.Users;

class User : BaseEntity
{
    public User(string fisrtName, string lastName, string email, DateTime birthDate)
    {
        FisrtName = fisrtName;
        LastName = lastName;
        Email = email;
        BirthDate = birthDate;

        CreatedAt = DateTime.Now;
        Active = true;
        Skills = [];
        FreelanceProject = [];
        OwnedProject = [];
    }

    public string FisrtName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool Active { get; private set; }

    public List<UserSkill> Skills { get; private set; }
    public List<Project> FreelanceProject { get; private set; }
    public List<Project> OwnedProject { get; private set; }
}
