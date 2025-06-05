namespace Contracts;

public interface IUpdatePessoa
{
    Guid Id { get; }
    string Nome { get; }
    DateTime DataNascimento { get; }
}