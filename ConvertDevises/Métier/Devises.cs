using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertDevises.Métier
{    
    public class Devises
    {
        private List<Devise> devises ;

        public Devises()
        {
            devises = new List<Devise>();
        }
        
        public double Convertir(double valeur, Devise source, Devise cible)
        {
            if (cible == null) throw new ErreurDeviseIncorrecte();            
            return cible.Convertir(valeur,source);
        }

        public void Ajouter(Devise d)
        {
            devises.Add(d);
        }

        public Devise[] Lister()
        {
            return devises.ToArray();
        }
    }
}
