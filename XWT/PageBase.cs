﻿#region License
/*
 **************************************************************
 *  Author: Ludmal de silva
 *          © Xwt Solutions, 2010
 *          http://www.infonexsolutions.com/
 * 
 * Created: 12/11/2009
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 **************************************************************  
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xwt.Logging;
using Xwt;

namespace Xwt.Web
{
    public class PageBase : System.Web.UI.Page, IViewControl 
    {
        private CacheManager _CacheManager = new CacheManager();
        public CacheManager CacheManager
        {
            get
            {
                return _CacheManager;
            }
        }

        public string UserID
        {
            get
            {
                return Context.User.Identity.Name;
            }
        }

        private Logger _Logger = null;

        public Logger Logger {
            get {
                if (CacheManager.Get(Keys.CACHE_LOGGER) == null)
                {
                    Logger.Initialize();
                    _Logger = new Logger();
                    return _Logger;
                }
                else {
                    return CacheManager.Get(Keys.CACHE_LOGGER) as Logger;
                }
            }
        }

    }
}