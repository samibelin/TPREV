using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertDevises.Métier;

namespace Tests
{
    public class TestsDevises
    {
        [Fact]

        public void TestAdd()
        {
            Devises devises = new Devises();
            Devise devise = new Devise("truc", 1);
            devises.Ajouter(devise);

            Assert.Single(devises.Lister());
        }

        [Fact]
        public void TestConvert()
        {
            Devises devises = new Devises();
            Devise devise = new Devise("truc", 1);
            Devise devise1 = new Devise("truc", 2);

            Assert.Equal(5,devises.Convertir(10, devise, devise1));
        }
    }
}
