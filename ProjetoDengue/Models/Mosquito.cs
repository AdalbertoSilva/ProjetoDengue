using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDengue.Models
{
    public class Mosquito : Agente
    {
        /// <summary>
        /// Tipo de dengue que carrega.
        /// </summary>
        public String dengue;
        /// <summary>
        /// Quanto tempo existe no campo.
        /// </summary>
        public int TempoDeCiclosVivo { get; set; }

        /// <summary>
        /// Construtor ser tipo de dengue informado, neste caso o tipo de dengue será definido aleatóriamente.
        /// </summary>
        public Mosquito()
        {
            Random random = SingleRandom.Instance.random;
            int valorSexo = random.Next(4);
            switch (valorSexo)
            {
                case 0:
                    dengue = Dengue.Tipo.Hemorragica.ToString();
                    break;
                case 1:
                    dengue = Dengue.Tipo.Tipo1.ToString();
                    break;
                case 2:
                    dengue = Dengue.Tipo.Tipo2.ToString();
                    break;
                case 3:
                    dengue = Dengue.Tipo.Tipo3.ToString();
                    break; 
                default:
                    dengue = null;
                    break;
            }
        }

        /// <summary>
        /// Construtor onde é definido o seu tipo de dengue.
        /// </summary>
        public Mosquito(String dengue)
        {
            this.dengue = dengue;
        }

        /// <summary>
        /// Caso esteja em um estátio que permita crescer, ela passará para a próxima fase de vida.
        /// </summary>
        public void Crescer()
        {
            Campo campo = Campo.Instance;
            Mosquito mosquito = null;
            Random random = SingleRandom.Instance.random;
            if (Tipo == "OvoMosquito")
            {
                mosquito = new PupaMosquito();
            }
            else if (Tipo == "PupaMosquito")
            {
                mosquito = new LarvaMosquito();
            }
            else if (Tipo == "LarvaMosquito")
            {
                int valorSexo = random.Next(2);
                if (valorSexo == 0)
                {
                    mosquito = new MosquitoFemea();
                }
                else
                {
                    mosquito = new MosquitoMacho();
                }
            }
            mosquito.PosicaoX = this.PosicaoX;
            mosquito.PosicaoY = this.PosicaoY;
            if (campo.RemoverAgente(this)) { 
                campo.InserirAgente(mosquito);
            }
        }
    }
}