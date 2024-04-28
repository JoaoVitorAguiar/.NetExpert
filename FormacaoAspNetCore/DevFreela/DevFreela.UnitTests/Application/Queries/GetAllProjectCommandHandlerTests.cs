using DevFreela.Application.Queries.Projects.GetAllProjects;
using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Queries;

public class GetAllProjectCommandHandlerTests
{
    // Aplicando o padrão given_when_then
    // Dado que 3 projetos existem quando executado retorna 3 projects view model
    [Fact]
    public  async Task ThreeProjectsExist_Executed_ReturnThreeProjectsViewModels()
    {
        // Arrange 
        var projects = new List<Project>
        {
            new Project("Nome teste 01", "Descrição teste 01", 1, 1, 100),
            new Project("Nome teste 02", "Descrição teste 02", 1, 1, 200),
            new Project("Nome teste 03", "Descrição teste 03", 1, 1, 300),
        };

        // Dependência do GetAllProjectHandler
        var projectRepositoryMock = new Mock<IProjectRepository>();
        projectRepositoryMock.Setup(pr => pr.GetAllAsync()).ReturnsAsync(projects);

        var getAllProjectQuery = new GetAllProjectsQuery("");
        var getAllProjectQueryHandler = new GetAllProjectHandler(projectRepositoryMock.Object);
        
        
        // Act
        var projectsViewModels = await getAllProjectQueryHandler.Handle(getAllProjectQuery, new CancellationToken());

        // Assert
        Assert.NotNull(projectsViewModels);
        Assert.NotEmpty(projectsViewModels);
        Assert.Equal(projects.Count, projectsViewModels.Count);

        projectRepositoryMock.Verify(pr => pr.GetAllAsync(), Times.Once);
    }
}
