

using DevFreela.Application.Commands.Project.CreateProject;
using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Commands;

public class CreateProjectCommandHandlerTests
{
    [Fact]
    // Given_when_then
    public async Task InputeDataOk_Executed_ReturnProjectId()
    {
        // Arrange
        var projectRepository = new Mock<IProjectRepository>();
        var createProjectCommand = new CreateProjectCommand
        {
            Title = "Teste",
            Description = "Descrição Teste",
            ClientId = 1,
            FreelancerId = 1,
            TotalCost = 5000
        };

        var createProjectCommandHandler = new CreateProjectHandler(projectRepository.Object);

        // Act
        var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());


        // Assert

        Assert.True(id >= 0);
        projectRepository.Verify(pr => pr.CreateProjectAsync(It.IsAny<Project>()), Times.Once);

    }
}
