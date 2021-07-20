using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smartformulator_Formulalookup_Webservice
{
    public class SF_RoutingClass
    {
        [Route("/DisplayFormula")]

        public class Displaygrids : IReturn<List<EntityClassList.Displaygrid>>
        {
            public string Formula { get; set; }
        }
        [Route("/Save_UpdateFormulation")]

        public class Save_UpdateFormulation : IReturn<List<EntityClassList.SaveUpdateFormulation>>
        {
            public string PDRNo { get; set; }
            public string FormulaCode { get; set; }
            public string FormulaName { get; set; }
            public string TotalVOCPercentage { get; set; }
            public string TotalPercentage { get; set; }
            public string AddedBy { get; set; }
            public string AddedDt { get; set; }
            public string operation { get; set; }

        }



    }
}