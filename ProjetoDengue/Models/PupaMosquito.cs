using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDengue.Models
{
    public class PupaMosquito : Mosquito
    {
        public override String Tipo
        {
            get
            {
                return "PupaMosquito";
            }
        }
        public override void DecidirAcao()
        {
            Crescer();
        }
    }
}