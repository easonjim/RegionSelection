using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;
using System.Data;
using RegionSelection.Model;

namespace RegionSelection.Service
{
    public class RegionService : BaseDao<Region>
    {
        #region "单例"
        private static RegionService service;
        public static RegionService Instance
        {
            get
            {
                if (service == null)
                {
                    service = new RegionService();
                }
                return service;
            }
        }
        #endregion

    }

}

