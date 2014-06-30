using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDengue.Models
{
    public class LarvaMosquito : Mosquito
    {
        public override String Tipo
        {
            get
            {
                return "LarvaMosquito";
            }
        }
        public override void DecidirAcao()
        {
            Crescer();
        }
    }
}