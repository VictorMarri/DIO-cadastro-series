using DIO.Serires.Entities;
using DIO.Serires.Interfaces;
using System.Collections.Generic;

namespace DIO.Serires.Repository
{
    /// <summary>
    /// Classe base do repositorio
    /// </summary>
    public class SerieRepositorio : IRepository<Series>
    {
        /// <summary>
        /// Essa lista abaixo está meramente representando um banco de dados.
        /// No lugar dessa lista, estaria por exemplo a classe de contexto de um banco de dados
        /// Para ai sim podemos manipular dentro de um banco de dados real as operações.
        /// </summary>
        private List<Series> listaSeries = new List<Series>();
        public void Atualizar(int id, Series entidade)
        {
            listaSeries[id] = entidade;
        }

        public void Excluir(int id)
        {
            listaSeries[id].Exclui();
        }

        public void Insere(Series entidade)
        {
            listaSeries.Add(entidade);
        }

        public List<Series> Lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }

        public Series RetornaPorId(int id)
        {
            return listaSeries[id];
        }
    }
}
