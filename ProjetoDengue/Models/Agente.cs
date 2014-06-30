using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace ProjetoDengue.Models
{
    public class Agente
    {
        public virtual String Tipo { get; set; }
        /// <summary>
        /// Posição Horizontal
        /// </summary>
        public int PosicaoX { get; set; }
        /// <summary>
        /// Posição Vertical
        /// </summary>
        public int PosicaoY { get; set; }
        /// <summary>
        /// Corre na direção oposta, com base na posição informada.
        /// <paramref name="posicaoAgenteX"> Posição horizontal do agente do qual deve fugir.</paramref>
        /// <paramref name="posicaoAgenteY"> Posição vertical do agente do qual deve fugir.</paramref>
        /// </summary>
        public void IrNaDirecaoOposta(int posicaoOutroAgenteX, int posicaoOutroAgenteY)
        {
            Campo campo = Campo.Instance;
            bool flagMovimentoValido = false;
            if (posicaoOutroAgenteX > PosicaoX)
            {
                if (campo.EspacoEValido(PosicaoX - 1, PosicaoY))
                {
                    PosicaoX = PosicaoX - 1;
                    flagMovimentoValido = true;
                }
            }
            else if (posicaoOutroAgenteX < PosicaoX)
            {
                if (campo.EspacoEValido(PosicaoX + 1, PosicaoY))
                {
                    PosicaoX = PosicaoX + 1;
                    flagMovimentoValido = true;
                }
            }
            else if (posicaoOutroAgenteY > PosicaoY)
            {
                if (campo.EspacoEValido(PosicaoX, PosicaoY - 1))
                {
                    PosicaoY = PosicaoY - 1;
                    flagMovimentoValido = true;
                }
            }
            else if (posicaoOutroAgenteY < PosicaoY)
            {
                if (campo.EspacoEValido(PosicaoX, PosicaoY + 1))
                {
                    PosicaoY = PosicaoY + 1;
                    flagMovimentoValido = true;
                }

            }

            if (!flagMovimentoValido)
            {
                FicarParado();
            }
        }

        /// <summary>
        /// Auto explicativo
        /// </summary>
        public void FicarParado()
        {

        }

        /// <summary>
        /// Se move em uma direção aleatória.
        /// </summary>
        public void MoverAleatoriamente()
        {
            Campo campo = Campo.Instance;
            int tamanhoCampoX = campo.TamanhoX;
            int tamanhoCampoY = campo.TamanhoY;
            Boolean flagMovimentoValido = false;
            Random random = SingleRandom.Instance.random;
            do
            {
                int aleatorio = random.Next(0, 5);

                switch (aleatorio)
                {
                    case 0:
                        FicarParado();
                        flagMovimentoValido = true;
                        break;
                    case 1:
                        if (tamanhoCampoX > PosicaoX + 1)
                        {
                            if (!campo.ListaAgentes.Exists(a => a.PosicaoX == PosicaoX + 1 && a.PosicaoY == PosicaoY))
                            {
                                PosicaoX = PosicaoX + 1;
                                flagMovimentoValido = true;
                            }
                        }
                        break;
                    case 2:
                        if (tamanhoCampoY > PosicaoY + 1)
                        {
                            if (!campo.ListaAgentes.Exists(a => a.PosicaoX == PosicaoX && a.PosicaoY == PosicaoY + 1))
                            {
                                PosicaoY = PosicaoY + 1;
                                flagMovimentoValido = true;
                            }
                        }
                        break;
                    case 3:
                        if (0 < PosicaoX)
                        {
                            if (!campo.ListaAgentes.Exists(a => a.PosicaoX == PosicaoX - 1 && a.PosicaoY == PosicaoY))
                            {
                                PosicaoX = PosicaoX - 1;
                                flagMovimentoValido = true;
                            }
                        }
                        break;
                    case 4:
                        if (0 < PosicaoY)
                        {
                            if (!campo.ListaAgentes.Exists(a => a.PosicaoX == PosicaoX && a.PosicaoY == PosicaoY - 1))
                            {
                                PosicaoY = PosicaoY - 1;
                                flagMovimentoValido = true;
                            }
                        }
                        break;
                }
            } while (flagMovimentoValido == false);
        }

        /// <summary>
        /// Corre na mesma direção, com base na posição informada.
        /// <paramref name="posicaoAgenteX"> Posição horizontal do agente que deve seguir.</paramref>
        /// <paramref name="posicaoAgenteY"> Posição vertical do agente que deve seguir.</paramref>
        /// </summary>
        public void IrNaMesmaDirecao(int posicaoOutroAgenteX, int posicaoOutroAgenteY)
        {
            Campo campo = Campo.Instance;
            bool flagMovimentoValido = false;
            if (posicaoOutroAgenteX > PosicaoX)
            {
                if (campo.EspacoEValido(PosicaoX + 1, PosicaoY))
                {
                    PosicaoX = PosicaoX + 1;
                    flagMovimentoValido = true;
                }
            }
            else if (posicaoOutroAgenteX < PosicaoX)
            {
                if (campo.EspacoEValido(PosicaoX-1, PosicaoY))
                {
                    PosicaoX = PosicaoX - 1;
                    flagMovimentoValido = true;
                }
            }
            else if (posicaoOutroAgenteY > PosicaoY)
            {
                if (campo.EspacoEValido(PosicaoX, PosicaoY + 1))
                {
                    PosicaoY = PosicaoY + 1;
                    flagMovimentoValido = true;
                }
            }
            else if (posicaoOutroAgenteY < PosicaoY)
            {
                if (campo.EspacoEValido(PosicaoX, PosicaoY - 1))
                {
                    PosicaoY = PosicaoY - 1;
                    flagMovimentoValido = true;
                }
            
            }

            if (!flagMovimentoValido)
            {
                FicarParado();
            }
        }

        /// <summary>
        /// Metodo que decidirá qual será o próximo movimento do agente.
        /// </summary>
        public virtual void DecidirAcao()
        {
            
        }

        /// <summary>
        /// Informa o tipo do agente próximo.
        /// <paramref name="agente"> Agente próximo.</paramref>
        /// </summary>
        public string verificarTipoAgenteProximo(Agente agente)
        {
            return agente.Tipo;
        }

        /// <summary>
        /// Retorna uma lista que contém todos os agentes a 3 quadrados de distância.
        /// </summary>
        public List<Agente> VerificarAgentesProximos()
        {
            Campo campo = Campo.Instance;
            List<Agente> agentesProximos = new List<Agente>();
            for(int x = -3; x <= 3 ; x++){
                for (int y = -3; y <= 3; y++)
                {
                    Agente agente = campo.ProcurarAgentePorPosicao(PosicaoX + x, PosicaoY + y);
                    if(agente != null){
                        agentesProximos.Add(agente);
                    }
                }
            }
            return agentesProximos;
        }

        /// <summary>
        /// Informa o agente que estiver próximo, para que possa decidir quais ações devem ser realizadas com ele posteriormente.
        /// <paramref name="tipoAgente"> Agente próximo.</paramref>
        /// </summary>
        public Agente InformarDeterminadoTipoDeAgenteProximo(String tipoAgente)
        {
            Campo campo = Campo.Instance;
            List<Agente> agentesProximos = new List<Agente>();
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    Agente a = campo.ProcurarAgentePorPosicao(PosicaoX + x, PosicaoY + y);
                    if (a != null)
                    {
                        agentesProximos.Add(a);
                    }
                }
            }
            Agente agente = agentesProximos.FirstOrDefault(a => a.Tipo.Contains(tipoAgente));
            return agente;
        }
    }
}