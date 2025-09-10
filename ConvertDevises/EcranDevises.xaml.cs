using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Input.Manipulations;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConvertDevises.Métier;
using ConvertDevises.Mocks;
using ConvertDevises.Réseau;
using ConvertDevises.Stockage;

namespace ConvertDevises
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EcranDevises : Window
    {
        private IStockeDevisesFavorites stockage;
        private IServiceWeb fournisseur;
        private Devises devises;

        public EcranDevises()
        {
            InitializeComponent();
            stockage = new StockageFichier(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            fournisseur = new MockServiceWeb();
            Init();
        }

        private async void Init()
        {
            try
            {
                devises = await fournisseur.Lister();
            }
            catch (ErreurServiceWeb)
            {
                MessageBox.Show("Erreur de fournisseur de données");
            }
            InitialiseListe();
            try
            {
                var dsource = stockage.ChargerSource();
                var dcible = stockage.ChargerCible();
                SelectFav(dsource, dcible);
            }
            catch (ErreurStockage)
            {
                // ne fait rien, les favoris ne sont pas fondamentaux
            }
        }

        private void SelectFav(Devise dsource, Devise dcible)
        {
            source.SelectedItem = dsource;
            cible.SelectedItem = dcible;
        }
		
        private void InitialiseListe()
        {
            source.Items.Clear();
            cible.Items.Clear();
            var copie = devises.Lister().ToList();
            
            copie.Sort( (d1, d2) => d1.Nom.CompareTo(d2.Nom));
            foreach(var devise in copie)
            {
                source.Items.Add(devise);
                cible.Items.Add(devise);
            }
        }
        
        private void ChoisirDeviseSource(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (source.SelectedItem is Devise d)
                {
                    stockage.SauverSource(d);
                }
            }
            catch(ErreurStockage)
            {
                MessageBox.Show("Impossible de sauvegarder la devise");
            }
        }

        private void Convertir(object sender, RoutedEventArgs e)
        {
            try
            {
                double val = Convert.ToDouble(valeur.Text);
                Devise ds = source.SelectedItem as Devise;
                Devise dc = cible.SelectedItem as Devise;
                double result = devises.Convertir(val, ds, dc);
                resultat.Text = result.ToString();  
            }
            catch(ErreurDeviseIncorrecte)
            {
                MessageBox.Show("Une des devises choisie n'est pas correcte");
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void ChoisirDeviseCible(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cible.SelectedItem is Devise d)
                {
                    stockage.SauverCible(d);
                }
            }
            catch (ErreurStockage)
            {
                MessageBox.Show("Impossible de sauvegarder la devise");
            }
        }
    }
}
