using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Infrastructure.Persistense;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations;

public class SkillService : ISkillsService
{
    private readonly DevFreelaDbContext _dbContext;

    public SkillService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<SkillViewModel>> GetAll()
    {
        var skills = _dbContext.Skills;
        var skillsViewModel = await skills.Select(s => new SkillViewModel(s.Id, s.Description)).ToListAsync();
        return skillsViewModel;
    }
}
