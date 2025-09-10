using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ConvertDevises.Métier
{
    [DataContract]
    public class Devise
    {
        [DataMember] private string nom;
        [DataMember] private double valConvBase;
        
        public string Nom
        {
            get { return nom; }
        }

        public Devise(string nom, double valeur)
        {
            if (string.IsNullOrWhiteSpace(nom))
                throw new ErreurDeviseIncorrecte();
            this.nom = nom;
            if (valeur <= 0) throw new ErreurDeviseIncorrecte();
            this.valConvBase = valeur;
            
        }

        public double Convertir(double valeur, Devise source)
        {
            if (source == null) throw new ErreurDeviseIncorrecte();
            if (source.valConvBase <= 0) throw new ErreurDeviseIncorrecte();
            double val = (valeur*source.valConvBase) / this.valConvBase;
            return val; 
        }

        public override string ToString()
        {
            return nom;
        }

        public override bool Equals(object obj)
        {
            return obj is Devise devise &&
                   nom == devise.nom &&
                   valConvBase == devise.valConvBase;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(nom, valConvBase);
        }
    }
}
