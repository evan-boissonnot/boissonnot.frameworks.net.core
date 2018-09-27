using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boissonnot.Framework.Core.Web
{
    /// <summary>
    /// Parente de tous les controllers
    /// </summary>
    public abstract class BaseController<TBusiness> : DefaultBaseController
    {
        #region Fields
        private TBusiness _business = default(TBusiness);
        #endregion

        #region Constructors
        public BaseController(DbContext context, TBusiness business) : base(context)
        {
            this._business = business;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Accesseur du business par défaut
        /// </summary>
        protected TBusiness DefaultBusiness { get => this._business; }
        #endregion
    }
}
