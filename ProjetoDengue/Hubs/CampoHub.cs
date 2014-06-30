using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using ProjetoDengue.Models;
using System.Collections.Generic;
using System.Linq;

namespace SignalRChat
{
    public class CampoHub : Hub
    {
        public void Send(String conexaoId)
        {
            // Call the addNewMessageToPage method to update clients.
            
            Campo campo = Campo.Instance;
            if (campo.ConexaoId == null)
            {
                campo.ConexaoId = conexaoId;
            }
            if (campo.ConexaoId == conexaoId)
            {

                if (campo.QuantidadeCiclos > 0)
                {
                    List<Agente> listaAgentes = new List<Agente>();
                    foreach (Agente agente in campo.ListaAgentes)
                    {
                        listaAgentes.Add(agente);
                    }
                    foreach (Agente agente in listaAgentes)
                    {
                        agente.DecidirAcao();
                    }
                }
                campo.QuantidadeCiclos += 1;
            }
            //Clients.All.addNewMessageToPage(campo);
            Clients.Client(conexaoId).addNewMessageToPage(campo);
            //Clients.User(conexaoId).addNewMessageToPage(campo);
        }

        public void Reset()
        {
            Campo campo = Campo.Instance;
            campo.ListaAgentes = new List<Agente>();
            campo.QuantidadeCiclos = 0;
            campo.CriarCampo(0, 0);
            campo.ConexaoId = null;
        }
    }
}