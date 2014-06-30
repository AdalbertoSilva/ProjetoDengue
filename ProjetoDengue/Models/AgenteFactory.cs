using ProjetoDengue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDengue.Models
{
    public class AgenteFactory
    {
        /// <summary>
        /// Retorna uma posição aleatória válida para a inserção de um agente.
        /// </summary>
        public int[] DefinirPosicaoValida()
        {
            bool resultado = false;
            Campo campo = Campo.Instance;
            int limiteX = campo.TamanhoX;
            int limiteY = campo.TamanhoY;
            Random random = SingleRandom.Instance.random;
            int posicaoX = 0;
            int posicaoY = 0;
            while (resultado == false)
            {
                posicaoX = random.Next(limiteX);
                posicaoY = random.Next(limiteY);
                bool existeOutroAgenteNaMesmaPosicao = campo.ListaAgentes.Exists(a => a.PosicaoX == posicaoX && a.PosicaoY == posicaoY);
                resultado = !existeOutroAgenteNaMesmaPosicao;
            }
            int[] posicoesValidas = new int[2];
            posicoesValidas[0] = posicaoX;
            posicoesValidas[1] = posicaoY;
            return posicoesValidas;
        }

        /// <summary>
        /// Cria um novo agente, de determinado tipo.
        /// <paramref name="tipoAgente"> Tipo do agente que deve ser criado.</paramref>
        /// </summary>
        public Agente CriarAgente(String tipoAgente)
        {
            Agente agente = null;
            int[] posicoesValidas = DefinirPosicaoValida();

            if (tipoAgente == "OvoMosquito")
            {
                agente = new OvoMosquito();
            }
            else if (tipoAgente == "MosquitoMacho")
            {
                agente = new MosquitoMacho();            
            }
            else if (tipoAgente == "MosquitoFemea")
            {
                agente = new MosquitoFemea();
            }
            else if (tipoAgente == "AgenteSanitario")
            {
                agente = new AgenteSanitario();
            }
            else{
                agente =  new Pessoa();
            }
            agente.PosicaoX = posicoesValidas[0];
            agente.PosicaoY = posicoesValidas[1];
            return agente;
        }

        /// <summary>
        /// Cria e adiciona automaticamente a lista determinada quantidade de agentes, de um determinado tipo.
        /// <paramref name="tipoAgente"> Tipo do agente que deve ser criado.</paramref>
        /// <paramref name="quantidade"> Quantidade de Agentes que deve ser criada.</paramref>
        /// </summary>
        public void AdicionarAgentesALista(int quantidade, String tipoAgente)
        {
            Campo campo = Campo.Instance;
            for (int i = 0; i < quantidade; i++)
            {
                campo.ListaAgentes.Add(CriarAgente(tipoAgente));
            }
        }

        /// <summary>
        /// Cria ovos de mosquito próximos do Mosquito Fêmea, nos espaços disponíveis.
        /// <paramref name="mosquitoMae"> Mosquito Fêmea responsável pela criação dos ovos.</paramref>
        /// </summary>
        public void AdicionarOvos(MosquitoFemea mosquitoMae)
        {
            Campo campo = Campo.Instance;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int posicaoXOvo = mosquitoMae.PosicaoX+x;
                    int posicaoYOvo = mosquitoMae.PosicaoY+y;
                    bool existeOutroAgenteNaMesmaPosicao = campo.ListaAgentes.Exists(a => a.PosicaoX == 
                         posicaoXOvo && a.PosicaoY == posicaoYOvo);
                    if (!existeOutroAgenteNaMesmaPosicao)
                    {
                        if (posicaoXOvo < campo.TamanhoX && posicaoYOvo < campo.TamanhoY)
                        {
                            OvoMosquito ovoMosquito = new OvoMosquito();
                            ovoMosquito.PosicaoX = posicaoXOvo;
                            ovoMosquito.PosicaoY = posicaoYOvo;
                            ovoMosquito.dengue = mosquitoMae.dengue;
                            campo.ListaAgentes.Add(ovoMosquito);
                        }
                    }
                }
            }
        }
        
    }
}