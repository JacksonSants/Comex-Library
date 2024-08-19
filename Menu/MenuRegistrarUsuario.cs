using Comex_Library.model;

namespace Comex_Library.Menu;

internal class MenuRegistrarUsuario
{
    public void Executar(List<Usuario> usuarios)
    {
        Usuario usuario = new Usuario();
        Console.Clear();
        Console.WriteLine("---- Registrar usuário ----");

        Console.Write("Nome: ");
        string nome = Console.ReadLine()!;

        Console.Write("CPF: ");
        string cpf = Console.ReadLine()!;

        string buscaCPF = buscaCpfEmUsuarios(usuarios, cpf);

        if (buscaCPF != null)
        {
            Console.WriteLine($"O CPF {buscaCPF} já está cadastrado no sistema.");
        }
        else
        {
            usuario.CadastrarCpf(cpf);
            usuarios.Add(usuario);
            Console.WriteLine("Usuário cadastrado com sucesso.");
        }
        Console.WriteLine("Aprte Enter para voltar ao Menu principal.");
        Console.ReadKey();
        Console.Clear();

    }

    public string buscaCpfEmUsuarios(List<Usuario> usuarios, string cpf)
    {
        var buscaCPF = usuarios.FirstOrDefault(u => u.CPF.Equals(cpf));
        return buscaCPF?.CPF;
    }
}
