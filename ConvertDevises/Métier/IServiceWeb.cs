using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConvertDevises.Métier
{
    /// <summary>
    /// Interface creating a list of devises
    /// </summary>
    public interface IServiceWeb
    {
        /// <summary>
        /// initialize a list of devises
        /// </summary>
        /// <returns>A task of devises</returns>
        Task<Devises> Lister();

    }
}
