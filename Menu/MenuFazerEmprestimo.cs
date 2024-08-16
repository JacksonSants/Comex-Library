using Comex_Library.model;
using System;
using System.Collections.Generic;

namespace Comex_Library.Menu
{
    internal class MenuFazerEmprestimo
    {
        public void Executar(List<Livro> livros, List<Usuario> usuarios)
        {
            var usuario = new Usuario();

            usuario.EmprestarLivro(livros);

            usuarios.Add(usuario);
            Console.WriteLine("Aprte Enter para voltar ao Menu principal.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
