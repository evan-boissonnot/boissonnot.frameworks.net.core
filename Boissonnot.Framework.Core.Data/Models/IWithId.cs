using System;
using System.Collections.Generic;
using System.Text;

namespace Boissonnot.Framework.Core.Data.Models
{
    /// <summary>
    /// Interface à utiliser pour tout objet avec un Id
    /// </summary>
    public interface IWithId
    {
        /// <summary>
        /// Identifiant de l'item
        /// </summary>
        int Id { get; set; }
    }
}
