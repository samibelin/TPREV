namespace ConvertDevises.Métier
{
    public interface IStockeDevisesFavorites
    {
        Devise ChargerCible();
        Devise ChargerSource();
        void SauverCible(Devise cible);
        void SauverSource(Devise source);
    }
}