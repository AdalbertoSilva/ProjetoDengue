using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDengue.Models
{
    public class SingleRandom
    {
        /// <summary>
        /// Instância do objeto Random, a única que deverá existir.
        /// </summary>
        private static readonly SingleRandom _instance = new SingleRandom();
        public Random random = new Random((int)DateTime.Now.Ticks);
        private SingleRandom()
        {
        
        }

        public static SingleRandom Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}