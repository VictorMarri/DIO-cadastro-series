using DIO.Serires.Entities.BaseEntity;
using DIO.Serires.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Serires.Entities
{
    public class Series : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Series(Genero genero, string titulo, string descricao, int ano)
        {
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public Series(int id,Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido + Environment.NewLine;
            return retorno;
        }

        /// <summary>
        /// Encapsulamento do retorno do titulo, pois colocamos a propriedade como private
        /// </summary>
        /// <returns></returns>

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        /// <summary>
        /// Encapsulamento do retorno do id, pois colocamos a propriedade como private
        /// </summary>
        /// <returns></returns>
        public int retornaId()
        {
            return this.Id;
        }

        /// <summary>
        /// Encapsulamento que faz a mudança de estado do objeto para true, para não termos que de fato excluir o objeto e sim tirar ele do radar de notoriedade
        /// </summary>
        public void Exclui()
        {
            this.Excluido = true;
        }

        public Enum retornaGenero()
        {
            return Genero;
        }

        public string retornaDescricao()
        {
            return Descricao;
        }

        public int retornaAno()
        {
            return Ano;
        }

        public bool retornaExcluir()
        {
            return Excluido;
        }
    }
}
