using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smartformulator_Formulalookup_Webservice
{
    public class EntityClassList
    {
        public class SearchCAS : IReturn<loadCAS>
        {
            public string CASNo { get; set; }
            public string Description { get; set; }
            public string Classification { get; set; }

        }
    }
}