using ConvertDevises.Métier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertDevises.Mocks
{
    public class MockStockage : IStockeDevisesFavorites
    {
        public Devise ChargerCible()
        {
            return new Devise("Euro", 1);
        }

        public Devise ChargerSource()
        {
            return new Devise("Dollar", 0.92);
        }

        public void SauverCible(Devise cible)
        {
            
        }

        public void SauverSource(Devise source)
        {
            
        }
    }
}
