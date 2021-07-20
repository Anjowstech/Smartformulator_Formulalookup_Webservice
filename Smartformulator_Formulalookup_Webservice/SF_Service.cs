using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smartformulator_Formulalookup_Webservice
{
    public class SF_Service
    {
        public List<EntityClass.SearchCAS> Any(Rawmaterials.SearchCASclass request)
        {
            return Repository.SearchCAS();
        }


    }
}