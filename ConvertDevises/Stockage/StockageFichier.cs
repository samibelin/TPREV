using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using ConvertDevises.Métier;
namespace ConvertDevises.Stockage
{
    
    public class StockageFichier : IStockeDevisesFavorites
    {
        private string path;
        private DataContractSerializer serializer;
        public StockageFichier(string path)
        {
            this.path= path;
            serializer = new DataContractSerializer(typeof(Devise));
        }

        private void SauverDevise(Devise devise, string name)
        {
            string fileName = Path.Combine(path, name);
            try
            {
                using (var flux = File.OpenWrite(fileName))
                {
                    serializer.WriteObject(flux, devise);
                }

            }
            catch
            {
                throw new ErreurStockage();
            }
        }

        public void SauverSource(Devise source)
        {
            SauverDevise(source, "source.dev");
        }
        
        public void SauverCible(Devise cible)
        {
            SauverDevise(cible, "cible.dev");
        }

        private Devise ChargerDevise(string name)
        {
            string fileName = Path.Combine(path, name);
            Devise devise=null;
            try
            {
                using (var flux = File.OpenRead(fileName))
                {
                    devise = serializer.ReadObject(flux) as Devise;
                }
            }
            catch
            {
                throw new ErreurStockage();
            }     
            return devise;
        }

        public Devise ChargerSource()
        {
            return ChargerDevise("source.dev");
        }

        public Devise ChargerCible()
        {
            return ChargerDevise("cible.dev");
        }
    }
}
