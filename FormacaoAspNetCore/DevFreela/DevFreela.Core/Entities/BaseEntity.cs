namespace DevFreela.Core.Entities;

public abstract class BaseEntity
{
    // Um construtor protegido significa que apenas
    // membros derivados podem construir instâncias
    // da classe (e instâncias derivadas) usando esse construtor
    protected BaseEntity() { }
    public int Id { get; private set; }
}
