using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDengue.Models
{
    public class MosquitoMacho : Mosquito
    {
        public override String Tipo
        {
            get
            {
                return "MosquitoMacho";
            }
        }

        public override void DecidirAcao()
        {
            TempoDeCiclosVivo += 1;
            if (TempoDeCiclosVivo >= 20) 
            { 
                Campo campo = Campo.Instance;
                campo.RemoverAgente(this);
            }
            else {
                List<Agente> listaAgentesProximos = VerificarAgentesProximos();
                if (listaAgentesProximos.Count == 0)
                {
                    MoverAleatoriamente();
                }
                else
                {
                    Agente agenteSanitario = null;
                    agenteSanitario = listaAgentesProximos.FirstOrDefault(a => a.Tipo.Contains("AgenteSanitario"));
                    if (agenteSanitario != null)
                    {
                        IrNaDirecaoOposta(agenteSanitario.PosicaoX, agenteSanitario.PosicaoY);
                    }
                    else
                    {
                        MoverAleatoriamente();
                    }
                }
            }   
        }
    }
}