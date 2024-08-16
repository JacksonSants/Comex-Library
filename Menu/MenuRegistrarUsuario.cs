using Comex_Library.model;

namespace Comex_Library.Menu;

internal class MenuRegistrarUsuario
{
    internal void Executar(List<Usuario> usuarios)
    {
        Usuario usuario = new Usuario();
        Console.Clear();
        Console.WriteLine("---- Registrar usuário ----");

        Console.Write("Nome: ");
        string nome = Console.ReadLine()!;

        Console.Write("CPF: ");
        string cpf = Console.ReadLine()!;
        usuario.CadastrarCpf(cpf);


    }
}
