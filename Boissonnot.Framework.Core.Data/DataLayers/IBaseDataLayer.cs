using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boissonnot.Framework.Core.Data.DataLayers
{
    /// <summary>
    /// Base pour tous les DataLayers
    /// </summary>
    /// <typeparam name="TItem">Item à gérer</typeparam>
    /// <typeparam name="TContext">Context d'accès à la base de données</typeparam>
    public interface IBaseDataLayer<TItem, TContext> : IDataLayer
                     where TItem : Models.IEntityItem
                     where TContext : DbContext
    {
        /// <summary>
        /// Ramène tous les éléments d'un type donnée
        /// </summary>
        /// <returns></returns>
        List<TItem> SelectAll();

        /// <summary>
        /// Ramène un élément, suivant l'id concerné
        /// </summary>
        /// <returns></returns>
        TItem SelectOne(int id);

        /// <summary>
        /// Ramène un élément, suivant son id (demande asynchrone)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TItem> SelectOneAsync(int id);

        /// <summary>
        /// Mise à jour de l'item en cours
        /// </summary>
        /// <param name="item">Item à mettre à jour, avec l'id renseigné</param>
        /// <returns></returns>
        Task UpdateOneAsync(TItem item); 
    }
}
