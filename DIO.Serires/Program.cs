using DIO.Serires.Entities;
using DIO.Serires.Enums;
using DIO.Serires.Repository;
using System;
using static System.Console;

namespace DIO.Serires
{
    class Program
    {
        static SerieRepositorio _repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizarSerie()
        {
            Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(ReadLine());

            var serie = _repositorio.RetornaPorId(indiceSerie);

            WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Write("Digite o ID da série que voce deseja excluir: ");
            int idSerie = int.Parse(ReadLine());

            WriteLine();
            Write("Deseja mesmo excluir a série de id {0} ? (S/N): ", idSerie);
            char opcaoUsuario = char.Parse(ReadLine().ToUpper());
            if (opcaoUsuario == 'S')
            {
                _repositorio.Excluir(idSerie);
            }
            else
            {
                WriteLine("Ok! Estamos voltando para o menu");
                WriteLine("...");
                ObterOpcaoUsuario();

            }

        }

        private static void AtualizarSerie()
        {
            Write("Digite o ID da Série");
            int indiceSerie = int.Parse(ReadLine());
            WriteLine();

            retornaItensSeries();

            Series novaSere = new Series(id: indiceSerie,
                                        genero: (Genero)retornaItensSeries().retornaGenero(),
                                        titulo: retornaItensSeries().retornaTitulo(),
                                        ano: retornaItensSeries().retornaAno(),
                                        descricao: retornaItensSeries().retornaDescricao());
        }

        private static void InserirSerie()
        {
           WriteLine("Inserir Nova Serie");

            retornaItensSeries();

            Series novaSere = new Series(id: _repositorio.ProximoId(),
                                         genero: (Genero)retornaItensSeries().retornaGenero(),
                                         titulo: retornaItensSeries().retornaTitulo(),
                                         ano: retornaItensSeries().retornaAno(),
                                         descricao: retornaItensSeries().retornaDescricao());

            _repositorio.Insere(novaSere);
        }

        private static void ListarSeries()
        {
            WriteLine("Listar Series");

            var lista = _repositorio.Lista();

            if (lista.Count == 0)
            {
                WriteLine("Nenhuma serie cadastrada no momento.");
            }
            else
            {
                foreach (var item in lista)
                {
                    var excluido = item.retornaExcluir();
                    if (!excluido)
                    {
                        WriteLine("#ID {0}: - {1}", item.retornaId(), item.retornaTitulo());
                    }

                }
            }
        }

        private static string ObterOpcaoUsuario()
        {
            WriteLine();
            WriteLine("DIO Séries a seu dispor!");
            WriteLine("Informe a opção desejada: ");

            WriteLine("1 - Listar Séries");
            WriteLine("2 - Inserir Série");
            WriteLine("3 - Atualizar Série");
            WriteLine("4 - Excluir série");
            WriteLine("5 - Visualizar série");
            WriteLine("6 - Limpar Tela");
            WriteLine("X - Sair");
            WriteLine();

            string opcaoUsiario = ReadLine();
            WriteLine();
            return opcaoUsiario;
        }

        private static Series retornaItensSeries()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(ReadLine());

            Write("Digite o Título da série: ");
            string entradaTitulo = ReadLine();

            Write("Digite o Ano de início da Série: ");
            int entraAno = int.Parse(ReadLine());

            Write("Digite a descição da série: ");
            string entraDescricao = ReadLine();

            Series itens = new Series((Genero)entradaGenero, entradaTitulo, entraDescricao, entraAno);

            return itens;
        }
    }
}
