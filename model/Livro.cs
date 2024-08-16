namespace Comex_Library.model;

internal class Livro
{
    public Livro(string titulo, string autor, string isbn, DateTime dataPublicacao, bool emprestado)
    {
        Titulo = titulo;
        Autor = autor;
        ISBN = isbn;
        DataPublicacao = dataPublicacao;
        Emprestado = emprestado;
    }

    public Livro()
    {
    }

    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public DateTime DataPublicacao { get; set; }
    public bool Emprestado { get; set; }

    public void Emprestar()
    {

    }

    public void Devolver()
    {

    }

    public void ExibirInformacoes(List<Livro> livros)
    {
        Console.Clear();
        Console.WriteLine("---- Livros disponiveis ----\n");
        for (int i = 0; i < livros.Count; i++)
        {
            if (livros[i].Emprestado == false)
            {
                Console.WriteLine($"{i + 1}. Livro: {livros[i].Titulo} - Autor: {livros[i].Autor}\n");
            }
        }

        Console.WriteLine("Aperter a tecla Enter para voltar menu principal.");
        Console.ReadKey();
        Console.Clear();
    }


    /*public string ConsultaLivro(string isbn)
    {
        var consultaLivro = (
            from livro in livros
            where livros.ISBN == isbn).ToList());
    }*/


}
