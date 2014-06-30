using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDengue.Models
{
    public class MosquitoFemea : Mosquito
    {
        public override String Tipo
        {
            get
            {
                return "MosquitoFemea";
            }
        }
        public bool temSangue;

        public override void DecidirAcao()
        {
            TempoDeCiclosVivo += 1;
            if (TempoDeCiclosVivo >= 20)
            {
                Campo campo = Campo.Instance;
                campo.RemoverAgente(this);
            }
            else
            {
                List<Agente> listaAgentesProximos = VerificarAgentesProximos();
                if (listaAgentesProximos.Count == 0)
                {
                    MoverAleatoriamente();
                }
                else
                {
                    Agente agenteSanitario = null;
                    Agente pessoa = null;
                    Agente mosquitoMacho = null;
                    agenteSanitario = listaAgentesProximos.FirstOrDefault(a => a.Tipo.Contains("AgenteSanitario"));
                    pessoa = listaAgentesProximos.FirstOrDefault(a => a.Tipo.Contains("Pessoa"));
                    mosquitoMacho = listaAgentesProximos.FirstOrDefault(a => a.Tipo.Contains("MosquitoMacho"));

                    if (agenteSanitario != null)
                    {
                        IrNaDirecaoOposta(agenteSanitario.PosicaoX, agenteSanitario.PosicaoY);
                    }
                    else if (temSangue == false)
                    {
                        if (pessoa != null)
                        {
                            Pessoa pessoaProxima = (Pessoa)InformarDeterminadoTipoDeAgenteProximo("Pessoa");
                            if (pessoaProxima != null && temSangue == false)
                            {
                                PicarPessoa(pessoaProxima);
                            }
                            else
                            {
                                IrNaMesmaDirecao(pessoa.PosicaoX, pessoa.PosicaoY);
                            }
                        }
                        else
                        {
                            MoverAleatoriamente();
                        }
                    }
                    else if (temSangue == true)
                    {
                        if (mosquitoMacho != null)
                        {
                            MosquitoMacho mosquitoMachoProximo = (MosquitoMacho)InformarDeterminadoTipoDeAgenteProximo("MosquitoMacho");
                            if (mosquitoMachoProximo != null)
                            {
                                Copular(mosquitoMachoProximo);
                            }
                            else
                            {
                                IrNaMesmaDirecao(mosquitoMacho.PosicaoX, mosquitoMacho.PosicaoY);
                            }
                        }
                        else
                        {
                            MoverAleatoriamente();
                        }
                    }
                    else
                    {
                        MoverAleatoriamente();
                    }
                }
            }
        }

        public bool PicarPessoa(Pessoa pessoa)
        {
            Campo campo = Campo.Instance;
            Pessoa pessoaAlterar = (Pessoa)campo.ListaAgentes.FirstOrDefault(a => a == pessoa);
            if (pessoaAlterar != null && this.dengue != null)
            {
                pessoaAlterar.FicarDoente(this.dengue);
            }
            temSangue = true;
            return true;

        }

        public bool Copular(MosquitoMacho mosquitoMachoProximo)
        {
            if (mosquitoMachoProximo.dengue != null) { 
                this.dengue = mosquitoMachoProximo.dengue;
            }
            AgenteFactory agenteFactory = new AgenteFactory();
            agenteFactory.AdicionarOvos(this);
            temSangue = false;
            return true;
        }
    }
}