using Comex_Library.model;
using Comex_Library.Menu;
using Comex_Library;

List<Livro> livros = new List<Livro>
{
    new Livro("Percy Jackson e o Mar de Monstros", "Rick Riordan", "978-8598078549", new DateTime(2006, 4, 1), false),
    new Livro("As Crônicas de Gelo e Fogo", "George R. R. Martin", "978-8551001894", new DateTime(1996, 8, 6), false),
    new Livro("Heir of Fire", "Sarah J. Maas", "978-1595145872", new DateTime(2014, 9, 2), false),
    new Livro("Queen of Shadows", "Sarah J. Maas", "978-1619630343", new DateTime(2015, 9, 1), true),
    new Livro("Fogo & Sangue", "George R. R. Martin", "978-8551005991", new DateTime(2018, 11, 20), false),
    new Livro("O Hobbit", "J. R. R. Tolkien", "978-8551000000", new DateTime(1937, 9, 21), false),
    new Livro("O Senhor dos Anéis", "J. R. R. Tolkien", "978-8551001110", new DateTime(1954, 7, 29), false),
    new Livro("O Festim dos Corvos", "George R. R. Martin", "978-8551005151", new DateTime(2005, 10, 17), false),
    new Livro("Percy Jackson e o Ladrão de Raios", "Rick Riordan", "978-8598078440", new DateTime(2005, 7, 28), false),
    new Livro("Crown of Midnight", "Sarah J. Maas", "978-1595147210", new DateTime(2013, 8, 27), false),
    new Livro("A Dança dos Dragões", "George R. R. Martin", "978-8551005465", new DateTime(2011, 7, 12), false),
    new Livro("Trono de Vidro", "Sarah J. Maas", "978-8501093585", new DateTime(2013, 9, 1), false),
};

List<Usuario> usuarios = new List<Usuario>();
void ExibirMEnu()
{
    int opcao;
    do
    {
        Menu.Executar();
        Console.WriteLine("\n1 - Registar Usuário\n2 - Cadastar Livro\n3 - Exibir livros disponíveis\n4 - Emprestar livro\n5 - Devolver livro");
        Console.Write("\nDigite a opcação desejada: ");
        opcao = int.Parse(Console.ReadLine()!);

        switch (opcao)
        {
            case 1:
                MenuRegistrarUsuario menu1 = new MenuRegistrarUsuario();
                menu1.Executar(usuarios);
                break;
            case 2:
                MenuRegistrarLivro menu2 = new MenuRegistrarLivro();
                menu2.Executar(livros);
                break;
            case 3:
                Livro livro = new Livro();
                livro.ExibirInformacoes(livros);
                break;
            case 4:
                MenuFazerEmprestimo menu4 = new MenuFazerEmprestimo();
                menu4.Executar(livros, usuarios);
                break;
            case 5:
                MenuDevolverLivro menu5 = new MenuDevolverLivro();
                menu5.Executar(usuarios);
                break;
        }
    } while (opcao != 0);
}

ExibirMEnu();