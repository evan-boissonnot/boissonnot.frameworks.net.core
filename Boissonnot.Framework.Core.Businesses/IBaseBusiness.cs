using Boissonnot.Framework.Core.Data.DataLayers;
using Boissonnot.Framework.Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boissonnot.Framework.Core.Businesses
{
    public interface IBaseBusiness<TLayer, TItem, TContext>
                     where TItem : IEntityItem
                     where TContext : DbContext
                     where TLayer : IBaseDataLayer<TItem, TContext>
    {
        /// <summary>
        /// Ramène un élément, suivant l'id concerné
        /// </summary>
        /// <returns></returns>
        TItem GetOne(int id);

        /// <summary>
        /// Ramène un élément, suivant son id (demande asynchrone)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TItem> GetOneAsync(int id);

        /// <summary>
        /// Accesseur à la base de données
        /// </summary>
        TLayer Layer { get; }
    }
}
