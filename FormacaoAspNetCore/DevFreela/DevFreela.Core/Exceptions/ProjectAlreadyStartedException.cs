namespace DevFreela.Core.Exceptions;

public class ProjectAlreadyStartedException : Exception
{
    ProjectAlreadyStartedException() : base("Project is already in Started status")
    {

    }
}
