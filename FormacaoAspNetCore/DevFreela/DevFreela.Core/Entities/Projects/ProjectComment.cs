using DevFreela.Core.Entities.Users;

namespace DevFreela.Core.Entities.Projects;

public class ProjectComment : BaseEntity
{
    public ProjectComment(string content, int projectId, int userId)
    {
        Content = content;
        ProjectId = projectId;
        UserId = userId;

        CreatedAt = DateTime.Now;
    }

    public string Content { get; private set; }
    public int ProjectId { get; private set; }
    public int UserId { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;

    public Project Project { get; private set; }
    public User User { get; private set; }
}