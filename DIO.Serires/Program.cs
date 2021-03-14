using DIO.Serires.Entities;
using DIO.Serires.Entities.BaseEntity;
using DIO.Serires.Enums;
using DIO.Serires.Repository;
using System;
using System.Collections.Generic;
using static System.Console;

namespace DIO.Serires
{
    class Program
    {
        static SerieRepositorio _repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
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
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(ReadLine());

            var serie = _repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da série que voce deseja excluir: ");
            int idSerie = int.Parse(ReadLine());

            Console.WriteLine();
            Console.Write("Deseja mesmo excluir a série de id {0} ? (S/N): ", idSerie);
            char opcaoUsuario = char.Parse(ReadLine().ToUpper());
            if (opcaoUsuario == 'S')
            {
                _repositorio.Excluir(idSerie);
            }
            else
            {
                Console.WriteLine("Ok! Estamos voltando para o menu");
                Console.WriteLine("...");
                ObterOpcaoUsuario();

            }
            
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da Série");
            int indiceSerie = int.Parse(ReadLine());
            Console.WriteLine();

            retornaItensSeries();

            Series novaSere = new Series(id: indiceSerie,
                                        genero: (Genero)retornaItensSeries().retornaGenero(),
                                        titulo: retornaItensSeries().retornaTitulo(),
                                        ano: retornaItensSeries().retornaAno(),
                                        descricao: retornaItensSeries().retornaDescricao());
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Serie");

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
            Console.WriteLine("Listar Series");

            var lista = _repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada no momento.");
            }
            else
            {
                foreach (var item in lista)
                {
                    var excluido = item.retornaExcluir();
                    if (!excluido)
                    {
                        Console.WriteLine("#ID {0}: - {1}", item.retornaId(), item.retornaTitulo());
                    }
                    
                }
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsiario = ReadLine();
            Console.WriteLine();
            return opcaoUsiario;
        }

        private static Series retornaItensSeries()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(ReadLine());

            Console.Write("Digite o Título da série: ");
            string entradaTitulo = ReadLine();

            Console.Write("Digite o Ano de início da Série: ");
            int entraAno = int.Parse(ReadLine());

            Console.Write("Digite a descição da série: ");
            string entraDescricao = ReadLine();

            Series itens = new Series((Genero)entradaGenero, entradaTitulo, entraDescricao, entraAno);

            return itens;
        }
    }
}
