﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Project.DeleteProject;

public class DeleteProjectCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
