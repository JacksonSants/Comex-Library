using Comex_Library.model;

namespace Comex_Library.Menu;

internal class MenuDevolverLivro
{
    public void Executar(List<Usuario> usuarios)
    {
        Console.WriteLine("---- Devolver livro ----");

        Console.Write("Digite o CPF: ");
        string cpf = Console.ReadLine()!;

        for (int i = 0; i < usuarios.Count; i++)
        {
            if (cpf == usuarios[i].CPF)
            {
                usuarios[i].ListarLivros();
                usuarios[i].DevolverLivro(usuarios[i].LivrosEmprestados);
            }
        }

        Console.WriteLine("Aperter a tecla Enter para voltar menu principal.");
        Console.ReadKey();
        Console.Clear();
    }
}
