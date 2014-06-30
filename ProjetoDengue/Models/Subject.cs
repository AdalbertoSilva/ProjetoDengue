using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDengue.Models
{
    public interface Subject
    {
        void RegistrarObserver(Observer o);
        void RemoverObserver(Observer o);
        void NotificarObservers();
    }
}