using ConvertDevises.Métier;

namespace Tests
{
    public class TestsDevise
    {

        [Fact]
        public void TestCreateCurrency()
        {
            Devise devise = new Devise("Bitcoin",240000);   
            Assert.NotNull(devise);
            
            Assert.Equal("Bitcoin", devise.Nom);

            Assert.ThrowsAny<Exception>(() => { Devise devise1 = new Devise("", 240); } );
            Assert.ThrowsAny<Exception>(() => { Devise devise2 = new Devise("truc", -1); });
        }

        [Fact]
        public void TestConversion()
        {
            Devise devise = new Devise("truc", 1);
            Devise devise1 = new Devise("truc2", 2);

            Assert.Equal(20,devise.Convertir(10, devise1));
        }

        [Fact]
        public void TestEquals()
        {
            Devise devise = new Devise("Bitcoin", 240000);
            Devise devise1 = new Devise("Bitcoin", 240000);

            Assert.True(devise.Equals(devise1));
        }
    }
}