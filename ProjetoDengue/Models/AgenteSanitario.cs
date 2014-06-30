using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDengue.Models
{
    public class AgenteSanitario : Agente
    {
        public override String Tipo
        {
            get
            {
                return "AgenteSanitario";
            }
        }

        public override void DecidirAcao()
        {
            List<Agente> listaAgentesProximos = VerificarAgentesProximos();
            if (listaAgentesProximos.Count == 0)
            {
                MoverAleatoriamente();
            }
            else
            {
                Agente mosquito = null;
                mosquito = InformarDeterminadoTipoDeAgenteProximo("Mosquito");
                if (mosquito != null)
                {
                    exterminarAgente(mosquito);
                }
                else
                {
                    mosquito = listaAgentesProximos.FirstOrDefault(a => a.Tipo.Contains("Mosquito"));
                    if (mosquito != null)
                    {
                        IrNaMesmaDirecao(mosquito.PosicaoX, mosquito.PosicaoY);
                    }
                    else
                    {
                        MoverAleatoriamente();
                    }
                }
            }
        }

        /// <summary>
        /// Remove determinado agente do campo.
        /// <paramref name="agente"> Agente a ser eliminado.</paramref>
        /// </summary>
        public bool exterminarAgente(Agente agente)
        {
            Campo campo = Campo.Instance;
            campo.ListaAgentes.Remove(agente);
            return true;
        }
    }
}