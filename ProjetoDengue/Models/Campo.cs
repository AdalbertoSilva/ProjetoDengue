using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDengue.Models
{
    public class Campo
    {
        /// <summary>
        /// Instância do Campo, a única que deverá existir.
        /// </summary>
        private static Campo _instance = new Campo();
        public string ConexaoId { get; set; }
        /// <summary>
        /// Tamanho Horizontal.
        /// </summary>
        public int TamanhoX { get; set; }
        /// <summary>
        /// Tamanho Vertical.
        /// </summary>
        public int TamanhoY { get; set; }
        /// <summary>
        /// Lista de agentes, uma linha dentro de uma coluna.
        /// </summary>
        public List<Agente> ListaAgentes { get; set; }
        public int QuantidadeCiclos { get; set; }

        private Campo()
        {

        }

        /// <summary>
        /// Chama a instância do campo.
        /// </summary>
        public static Campo Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Definir tamanho do campo e criar lista de agente para o campo.
        /// <paramref name="tamanhoX"> Tamanho Horizontal.</paramref>
        /// <paramref name="tamanhoY"> Tamanho Vertical.</paramref>
        /// </summary>
        public void CriarCampo(int tamanhoX, int tamanhoY)
        {
            TamanhoX = tamanhoX;
            TamanhoY = tamanhoY;
            ListaAgentes = new List<Agente>();
        }

        /// <summary>
        /// Adicionar determinado agente ao campo
        /// <paramref name="agente"> Agente a ser adicionado.</paramref>
        /// </summary>
        public void InserirAgente(Agente agente)
        {
            ListaAgentes.Add(agente);
        }

        /// <summary>
        /// Remove determinado agente ao campo
        /// <paramref name="agente"> Agente a ser removido.</paramref>
        /// </summary>
        public bool RemoverAgente(Agente agente)
        {
            return ListaAgentes.Remove(agente);
        }

        /// <summary>
        /// Retorna o agente que está ocupando determinada posição.
        /// <paramref name="posicaoX"> Posição Horizontal.</paramref>
        /// <paramref name="posicaoY"> Posição Vertical.</paramref>
        /// </summary>
        public Agente ProcurarAgentePorPosicao(int posicaoX, int posicaoY)
        {
            Agente agente = (from objeto in ListaAgentes
                             where objeto.PosicaoX == posicaoX && objeto.PosicaoY == posicaoY
                             select objeto).FirstOrDefault();
            return agente;
        }

        /// <summary>
        /// Informa se determinado espaço permite a inserção de um novo agente.
        /// <paramref name="posicaoX"> Posição Horizontal.</paramref>
        /// <paramref name="posicaoY"> Posição Vertical.</paramref>
        /// </summary>
        public bool EspacoEValido(int posicaoX, int posicaoY)
        {
            bool resultado = false;
            Campo campo = Campo.Instance;
            int limiteX = campo.TamanhoX;
            int limiteY = campo.TamanhoY;

            if (posicaoX < limiteX && posicaoY < limiteY)
            {
                if (posicaoX >= 0 && posicaoY >= 0)
                {
                    bool existeOutroAgenteNaMesmaPosicao = campo.ListaAgentes.Exists(a => a.PosicaoX == posicaoX && a.PosicaoY == posicaoY);
                    resultado = !existeOutroAgenteNaMesmaPosicao;
                    }
            }

            return resultado;
        }

    }
}