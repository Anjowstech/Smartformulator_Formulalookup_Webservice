using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smartformulator_Formulalookup_Webservice
{
    public class SF_Service : IService
    {
        public SF_Repository Repository{ get; set; }

        public List<EntityClassList.Displaygrid> Any(SF_RoutingClass.Displaygrids request)
        {
            return Repository.Displaygrid(request.Formula);
        }

        public string Any(SF_RoutingClass.Save_UpdateFormulation request)
        {
            return Repository.SaveUpdateFormulation(request.PDRNo, request.FormulaCode, request.FormulaName, request.TotalVOCPercentage, request.TotalPercentage,
                 request.AddedBy, request.AddedDt,request.operation);
        }

     
    }
}