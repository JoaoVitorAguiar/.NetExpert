using DevFreela.Core.Entities.Projects;
using DevFreela.Infrastructure.Persistense;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Project.CreateComment;

public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, int>
{
    private readonly DevFreelaDbContext _dbContext;

    public CreateCommentHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(request.Content, request.ClientId, request.ProjectId);
        await _dbContext.ProjectComment.AddAsync(comment);
        await _dbContext.SaveChangesAsync();
        return comment.Id;
    }
}
