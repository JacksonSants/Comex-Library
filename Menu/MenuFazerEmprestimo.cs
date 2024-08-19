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

            Console.Write("Nome: ");
            string nome = Console.ReadLine()!;
            usuario.Nome = nome;

            Console.Write("CPF: ");
            string cpf = Console.ReadLine()!;
            int mensagemCadastro = usuario.CadastrarCpf(cpf);

            if (mensagemCadastro == -1)
            {
                Console.WriteLine("CPF inválido.");
                return;
            }

            usuario.EmprestarLivro(livros);

            usuarios.Add(usuario);
            Console.WriteLine("Aprte Enter para voltar ao Menu principal.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
