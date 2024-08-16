using Comex_Library.model;
namespace Comex_Library.Menu;

internal class MenuRegistrarLivro
{
    public void Executar(List<Livro> livros)
    {
        Console.Clear();
        Console.WriteLine("---- Registrar livro ----\n");
        Console.Write("Título: ");
        string titulo = Console.ReadLine()!;

        Console.Write("Autor: ");
        string autor = Console.ReadLine()!;

        Console.Write("ISBN: ");
        string isbn = Console.ReadLine()!;

        DateTime dataPublicacao;
        while (true)
        {
            Console.Write("Data de publicação (dd/MM/yyyy): ");
            string dataInput = Console.ReadLine()!;

            if (DateTime.TryParseExact(dataInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataPublicacao))
            {
                break;
            }
            else
            {
                Console.WriteLine("Data inválida. Por favor, insira a data no formato dd/MM/yyyy.");
            }
        }

        Livro livro = new Livro(titulo, autor, isbn, dataPublicacao, false);
        livros.Add(livro);
        Console.WriteLine("Livro registrado com sucesso!");
        Console.WriteLine("Aprte Enter para voltar ao Menu principal.");
        Console.ReadKey();
        Console.Clear();

    }
}
