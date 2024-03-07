using DevFreela.Application.InputModel;
using DevFreela.Application.ViewModel;

namespace DevFreela.Application.Services.Interfaces;

public interface IProjectService
{
    // Implementação dos Endpoints de ProjectController
    Task<List<ProjectViewModel>> GetAll(string query);
    Task<ProjectDetailsViewModel> GetById(int id);
    Task<int> Create(NewProjectInputModel inputModel);
    void Update(UpdateProjectInputModel inputModel);
    void CreateComment(CreateCommentInputModel inputModel);
    void Delete(int id);
    void Start(int id);
    void Finish(int id);
}
