using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDengue.Models
{
    public class Pessoa : Agente
    {
        /// <summary>
        /// Tipo de dengue que carrega.
        /// </summary>
        public String dengue;
        /// <summary>
        /// Tipos de dengue que já teve.
        /// </summary>
        public List<String> ListaTipoDengueAntigas = new List<String>();
        /// <summary>
        /// Tempo em que está doente, deve ser 0 caso não esteja doente.
        /// </summary>
        public int tempoDoente;
        public override String Tipo { get; set; }

        /// <summary>
        /// Informa se a pessoa está doente ou não.
        /// </summary>
        public bool EstaDoente { get; set; }

        public Pessoa()
        {
            Tipo = "Pessoa";
        }

        public override void DecidirAcao()
        {
            if (tempoDoente >= 8)
            {
                TerminarPeriodoDoente();
            }
            if (EstaDoente)
            {
                Tipo = "PessoaDoente";
                tempoDoente += 1;
            }
            else
            {
                Tipo = "Pessoa";
                tempoDoente = 0;
            }
            List<Agente> listaAgentesProximos = VerificarAgentesProximos();
            if (listaAgentesProximos.Count == 0)
            {
                MoverAleatoriamente();
            }
            else
            {
                Agente mosquito = null;
                mosquito = listaAgentesProximos.FirstOrDefault(a => a.Tipo.Contains("Mosquito"));
                if (mosquito != null)
                {
                    IrNaDirecaoOposta(mosquito.PosicaoX, mosquito.PosicaoY);
                }
                else
                {
                    MoverAleatoriamente();
                }
            }
        }

        /// <summary>
        /// Remover pessoa do campo.
        /// </summary>
        public void Morrer()
        {
            Campo campo = Campo.Instance;
            campo.RemoverAgente(this);
        }

        public void TerminarPeriodoDoente()
        {
            if (dengue == "Hemorragica")
            {
                Random random = SingleRandom.Instance.random;
                int chanceDeMorrer = random.Next(2);
                if (chanceDeMorrer == 1)
                {
                    Morrer();
                }
            }
            EstaDoente = false;
            ListaTipoDengueAntigas.Add(dengue);
            dengue = "";
        }

        public void FicarDoente(String dengue)
        {
            bool teveMesmoTipoDengue = ListaTipoDengueAntigas.Contains(dengue);
            if (EstaDoente == false)
            {
                if (!teveMesmoTipoDengue)
                {
                    EstaDoente = true;
                    Tipo = "PessoaDoente";
                    this.dengue = dengue;
                }
            }
        }
    }
}