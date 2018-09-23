using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Boissonnot.Framework.Core.Web
{
    /// <summary>
    /// Classe parente pour les controllers
    /// </summary>
    /// <typeparam name="TBusiness">Accès à la classe Business par défaut</typeparam>
    /// <typeparam name="TPresentation">Item DTO de représentation pour la vue</typeparam>
    public abstract class BaseApiController<TBusiness, TPresentation> : ControllerBase
    {
        #region Fields
        private DbContext _context = null;
        #endregion

        #region Constructors
        public BaseApiController(DbContext context, TBusiness business)
        {
            this.Context = context;
            this.DefaultBusiness = business;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Méthode représentant la sélection d'un octopus
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public abstract Task<ActionResult<TPresentation>> Get(int id);
        #endregion

        #region Properties
        /// <summary>
        /// Context d'accès aux données
        /// </summary>
        public DbContext Context { get => this._context; private set => this._context = value; }

        /// <summary>
        /// Accès au business par défaut
        /// </summary>
        public TBusiness DefaultBusiness { get; private set; }
        #endregion
    }
}
