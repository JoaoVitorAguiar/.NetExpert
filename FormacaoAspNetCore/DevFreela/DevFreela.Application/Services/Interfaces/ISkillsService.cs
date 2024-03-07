using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces;

public interface ISkillsService
{
    Task<List<SkillViewModel>> GetAll();
}
