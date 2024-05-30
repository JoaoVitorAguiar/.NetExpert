namespace DevFreela.Application.InputModel;

public class CreateCommentInputModel
{
    public string Content { get; private set; }
    public int ClientId { get; private set; }
    public int ProjectId { get; private set; }
}
