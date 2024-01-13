using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Entities.Users;

namespace DevFreela.Infrastructure.Persistense;

public class DevFreelaDbContext
{ 
    public DevFreelaDbContext()
    {
        Projects = [
            new Project("Meu projeto ASP.NET Core 1","Minha descrição do projeto 1",1,1,10000),
            new Project("Meu projeto ASP.NET Core 2","Minha descrição do projeto 2",1,1,20000),
            new Project("Meu projeto ASP.NET Core 3","Minha descrição do projeto 3",1,1,30000),
        ];
        Users = [
            new User("João Vitor", "Aguiar", "joao@gmail.com", new DateTime(2000, 11, 30)),
            new User("Ana", "Silva", "ana@gmail.com", new DateTime(2003, 10, 15)),
            new User("Maria", "Souza", "maria@gmail.com", new DateTime(1998, 1, 3)),
        ];
        Skills = [
            new Skill("C#"),    
            new Skill("ASP.NET Core"),   
            new Skill("SQL"),   
        ];
    }

    public List<Project> Projects { get; private set; }
    public List<User> Users { get; private set; }
    public List<Skill> Skills { get; private set; }
}
