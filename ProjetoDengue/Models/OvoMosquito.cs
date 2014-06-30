using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDengue.Models
{
    public class OvoMosquito : Mosquito
    {
        public override String Tipo
        {
            get
            {
                return "OvoMosquito";
            }
        }
        public override void DecidirAcao()
        {
            Crescer();
        }
    }
}