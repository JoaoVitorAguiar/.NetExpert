using MediatR;

namespace DevFreela.Application.Commands.Project.CreateComment;

public class CreateCommentCommand : IRequest<int>
{
    public string Content { get; set; }
    public int ClientId { get; set; }
    public int ProjectId { get; set; }
}
