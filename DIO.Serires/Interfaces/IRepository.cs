using System.Collections.Generic;

namespace DIO.Serires.Interfaces
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Retornar Lista
        /// </summary>
        /// <returns>A lista contendo todos os objetos armazenados</returns>
        List<T> Lista();
        /// <summary>
        /// Retorna o objeto especifico por Id
        /// </summary>
        /// <returns>Retorna o objeto especifico</returns>
        T RetornaPorId(int id);
        /// <summary>
        /// Insere um Objeto
        /// </summary>
        /// <param name="entidade">Entidade a ser inserida</param>
        void Insere(T entidade);
        /// <summary>
        /// Exclui um objeto
        /// </summary>
        /// <param name="id">Id do objeto a ser excluido</param>
        void Excluir(int id);
        /// <summary>
        /// Atualiza um objeto
        /// </summary>
        /// <param name="id">ID do objeto a ser alterado</param>
        /// <param name="entidade"></param>
        void Atualizar(int id, T entidade);
        /// <summary>
        /// Retorna o Proximo Id para fins de manuseio de array
        /// </summary>
        /// <returns></returns>
        int ProximoId();
    }
}
