using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;
using System.Data;
using Example.Model;

namespace Example.Service
{
    public class dataService : BaseDao<Model.data>
    {
        #region "单例"
        private static dataService service;
        public static dataService Instance
        {
            get
            {
                if (service == null)
                {
                    service = new dataService();
                }
                return service;
            }
        }
        #endregion

    }

}

