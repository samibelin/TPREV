using ConvertDevises.Métier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertDevises.Mocks
{
    public class MockServiceWeb : IServiceWeb
    {
        public async Task<Devises> Lister()
        {
            Devises devises = new Devises();
            devises.Ajouter(new Devise("Euro", 1));
            devises.Ajouter(new Devise("Dollar", 0.92));
            devises.Ajouter(new Devise("Yen", 0.0063));
            devises.Ajouter(new Devise("Franc suisse", 1.04)); ;
            return devises;
        }


    }
}
