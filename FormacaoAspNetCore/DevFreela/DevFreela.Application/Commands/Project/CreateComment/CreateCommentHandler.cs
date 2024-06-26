﻿using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Project.CreateComment;

public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, int>
{
    private readonly IProjectRepository _projectRepository;

    public CreateCommentHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(request.Content, request.ClientId, request.ProjectId);
        await _projectRepository.CreateCommentAsync(comment);
        return comment.Id;
    }
}
