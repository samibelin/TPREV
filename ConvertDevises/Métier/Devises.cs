using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertDevises.Métier
{    
    /// <summary>
    /// Class representing multiple devises
    /// </summary>
    public class Devises
    {
        private List<Devise> devises ;

        /// <summary>
        /// The constructor of the class initializing a new empty list of devices
        /// </summary>
        public Devises()
        {
            devises = new List<Devise>();
        }
        
        /// <summary>
        /// Method for the convertion of a devise in another
        /// </summary>
        /// <param name="valeur">The initial value</param>
        /// <param name="source">The devise to convert from</param>
        /// <param name="cible">The devise to be converted in</param>
        /// <returns>The value in the second devise</returns>
        /// <exception cref="ErreurDeviseIncorrecte">If the second devise is null</exception>
        public double Convertir(double valeur, Devise source, Devise cible)
        {
            if (cible == null) throw new ErreurDeviseIncorrecte();            
            return cible.Convertir(valeur,source);
        }

        /// <summary>
        /// Add to the list of devise a new one
        /// </summary>
        /// <param name="d">The devise to add</param>
        public void Ajouter(Devise d)
        {
            devises.Add(d);
        }

        /// <summary>
        /// Method to show the list of devise
        /// </summary>
        /// <returns>An array with all the devise</returns>
        public Devise[] Lister()
        {
            return devises.ToArray();
        }
    }
}
