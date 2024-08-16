namespace Comex_Library.model;

internal class Usuario
{
    public Usuario()
    {
        LivrosEmprestados = new List<Livro>();
    }

    public string Nome { get; set; }
    public string CPF { get; private set; }
    public List<Livro> LivrosEmprestados { get; set; }

    public int CadastrarCpf(string cpf)
    {
        if (ValidarCpf(cpf))
        {
            CPF = cpf;
            return 1;
        }
        else
        {
            return -1;
        }
    }

    private static bool ValidarCpf(string cpf)
    {
        // Remove caracteres não numéricos
        string cpfNumeros = new string(cpf.Where(char.IsDigit).ToArray());

        // Verifica o comprimento
        if (cpfNumeros.Length != 11)
            return false;

        // Verifica se todos os dígitos são iguais
        if (cpfNumeros.All(c => c == cpfNumeros[0]))
            return false;

        // Calcula e verifica os dígitos verificadores
        return VerificarDigitos(cpfNumeros);
    }

    private static bool VerificarDigitos(string cpf)
    {
        int[] cpfNumeros = cpf.Select(c => int.Parse(c.ToString())).ToArray();

        // Calcula o primeiro dígito verificador
        int primeiroDigito = CalcularDigitoVerificador(cpfNumeros, 10);
        if (primeiroDigito != cpfNumeros[9])
            return false;

        // Calcula o segundo dígito verificador
        int segundoDigito = CalcularDigitoVerificador(cpfNumeros, 11);
        if (segundoDigito != cpfNumeros[10])
            return false;

        return true;
    }

    private static int CalcularDigitoVerificador(int[] cpfNumeros, int pesoInicial)
    {
        int soma = 0;
        for (int i = 0; i < pesoInicial - 1; i++)
        {
            soma += cpfNumeros[i] * (pesoInicial - i);
        }

        int resto = soma % 11;
        return resto < 2 ? 0 : 11 - resto;
    }

    public void EmprestarLivro(List<Livro> livros)
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine()!;
        Nome = nome;

        Console.Write("CPF: ");
        string cpf = Console.ReadLine()!;
        int mensagemCadastro = CadastrarCpf(cpf);

        if (mensagemCadastro == -1)
        {
            Console.WriteLine("CPF inválido.");
            return;
        }

        Console.Write($"Quantidade de livros para serem emprestados para {nome} (No máximo 3 livros): ");
        int quantidade = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < livros.Count; i++)
        {
            if (livros[i].Emprestado == false)
            {
                Console.WriteLine($"{i + 1}. Livro: {livros[i].Titulo} - Autor: {livros[i].Autor}");
            }
        }

        for (int i = 0; i < quantidade; i++)
        {
            Console.Write($"\nLivro{i + 1} (Digite o numero do livro): ");
            int key = int.Parse(Console.ReadLine()!);

            if (key > 0 && key <= livros.Count)
            {
                var livroEscolhido = livros[key - 1];
                if (livroEscolhido.Emprestado == false)
                {
                    LivrosEmprestados.Add(livroEscolhido);
                    livroEscolhido.Emprestado = true;
                    Console.WriteLine("Livro adicionado com sucesso\n");
                }
                else
                {
                    Console.WriteLine("O livro já está emprestado.");
                }
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
        }
    }

    public void DevolverLivro(List<Livro> livros)
    {
        Console.Write("Digite o numero do livro que deseja devolver: ");
        int numeroLivro = int.Parse(Console.ReadLine()!);

        int index = numeroLivro - 1;

        if (index >= 0 && index < livros.Count)
        {
            var livroEscolhido = livros[index];

            livros.RemoveAt(index);

            Console.WriteLine($"Livro {livroEscolhido.Titulo} removido da lista. Ele já está disponível para empréstimo.");
        }
        else
        {
            Console.WriteLine("Número do livro inválido.");
        }
    }


    public void ListarLivros()
    {
        for (int i = 0; i < LivrosEmprestados.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Livro: {LivrosEmprestados[i].Titulo} - Autor: {LivrosEmprestados[i].Autor}\n");
        }
    }
}