﻿using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Infrastructure.Persistense;
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

    public List<SkillViewModel> GetAll()
    {
        var skills = _dbContext.Skills;
        var skillsViewModel = skills.Select(s => new SkillViewModel(s.Id, s.Description)).ToList();
        return skillsViewModel;
    }
}