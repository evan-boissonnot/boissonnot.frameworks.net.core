using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boissonnot.Framework.Core.Web
{
    /// <summary>
    /// Parent par défaut des controllers
    /// </summary>
    public abstract class DefaultBaseController : Controller
    {
        #region Fields
        private DbContext _context = null;
        #endregion

        #region Constructors
        public DefaultBaseController(DbContext context)
        {
            this._context = context;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Action par défaut
        /// </summary>
        /// <returns></returns>
        public virtual IActionResult Index()
        {
            return View();
        }
        #endregion
    }
}
