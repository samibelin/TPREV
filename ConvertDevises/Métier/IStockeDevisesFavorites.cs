namespace ConvertDevises.Métier
{
    /// <summary>
    /// Interface to instantiate a devise or recover it
    /// </summary>
    public interface IStockeDevisesFavorites
    {
        /// <summary>
        /// Method to recover a devise for convert in
        /// </summary>
        /// <returns>Return the devise to convert in</returns>
        Devise ChargerCible();

        /// <summary>
        /// Method to recover a devise for convert from
        /// </summary>
        /// <returns>Return the devise to convert from</returns>
        Devise ChargerSource();

        /// <summary>
        /// Method to create a devise to convert in
        /// </summary>
        /// <param name="cible">The devise to convert in</param>
        void SauverCible(Devise cible);

        /// <summary>
        /// Method to create a devise to convert from
        /// </summary>
        /// <param name="source">The devise to convert from</param>
        void SauverSource(Devise source);
    }
}