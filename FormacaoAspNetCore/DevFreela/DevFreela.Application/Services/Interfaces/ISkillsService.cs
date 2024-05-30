using DevFreela.Application.ViewModel;

namespace DevFreela.Application.Services.Interfaces;

public interface ISkillsService
{
    Task<List<SkillViewModel>> GetAll();
}
