namespace DevFreela.Application.ViewModel;

public class ProjectDetailsViewModel
{
    public ProjectDetailsViewModel(
        int id,
        string title,
        string description,
        decimal totalCost,
        DateTime? startedAt,
        DateTime? finishedAt,
        string clientFirstName,
        string clientLastName,
        string freelancerFirstName,
        string freelancerLastName)
    {
        Id = id;
        Title = title;
        Description = description;
        TotalCost = totalCost;
        StartedAt = startedAt;
        FinishedAt = finishedAt;
        ClientFirstName = clientFirstName;
        ClientLastName = clientLastName;
        FreelancerFirstName = freelancerFirstName;
        FreelancerLastName = freelancerLastName;
    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal TotalCost { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public string ClientFirstName { get; private set; }
    public string ClientLastName { get; private set; }
    public string FreelancerLastName { get; private set; }
    public string FreelancerFirstName { get; private set; }
}
