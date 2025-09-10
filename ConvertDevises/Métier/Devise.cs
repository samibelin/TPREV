using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ConvertDevises.Métier
{
    /// <summary>
    /// Class representing a devise
    /// </summary>
    [DataContract]
    public class Devise
    {
        [DataMember] private string nom;
        [DataMember] private double valConvBase;
        
        /// <summary>
        /// Return a string, the name of the devise
        /// </summary>
        public string Nom
        {
            get { return nom; }
        }

        /// <summary>
        /// The constructor of the class
        /// </summary>
        /// <param name="nom">the name of the devise, not null</param>
        /// <param name="valeur">the actual value of the devise, positive</param>
        /// <exception cref="ErreurDeviseIncorrecte">If the name is blank or the value is below zero the devise is incorrect</exception>
        public Devise(string nom, double valeur)
        {
            if (string.IsNullOrWhiteSpace(nom))
                throw new ErreurDeviseIncorrecte();
            this.nom = nom;
            if (valeur <= 0) throw new ErreurDeviseIncorrecte();
            this.valConvBase = valeur;
            
        }

        /// <summary>
        /// A method to convert a devise into another
        /// </summary>
        /// <param name="valeur">How many you want to convert, superior to zero</param>
        /// <param name="source">The initial devise, not null</param>
        /// <returns>The final value</returns>
        /// <exception cref="ErreurDeviseIncorrecte">If the devise is null or the devise's value is below zero</exception>
        public double Convertir(double valeur, Devise source)
        {
            if (source == null) throw new ErreurDeviseIncorrecte();
            if (source.valConvBase <= 0) throw new ErreurDeviseIncorrecte();
            double val = (valeur*source.valConvBase) / this.valConvBase;
            return val; 
        }

        /// <summary>
        /// Return a string with the name of the devise
        /// </summary>
        /// <returns>String name of the devise</returns>
        public override string ToString()
        {
            return nom;
        }

        /// <summary>
        /// Verify if two devise has the same value and name
        /// </summary>
        /// <param name="obj">Another devise to compare with</param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            return obj is Devise devise &&
                   nom == devise.nom &&
                   valConvBase == devise.valConvBase;
        }

        /// <summary>
        /// Get the hash code of the devise
        /// </summary>
        /// <returns>Int the hash code of the devise</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(nom, valConvBase);
        }
    }
}
