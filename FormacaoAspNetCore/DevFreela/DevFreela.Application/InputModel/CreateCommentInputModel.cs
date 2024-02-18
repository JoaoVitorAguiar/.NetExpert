using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModel;

public class CreateCommentInputModel
{
    public string Content { get; private set; }
    public int ClientId { get; private set; }
    public int ProjectId { get; private set; }
}
