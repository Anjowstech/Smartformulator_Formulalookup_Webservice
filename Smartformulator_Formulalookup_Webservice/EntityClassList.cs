using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smartformulator_Formulalookup_Webservice
{
    public class EntityClassList
    {
        public class Displaygrid : IReturn<Displaygrid>
        {
            public string Ingredients { get; set; }
            public string FillRatio { get; set; }
            public string VOCPercentage { get; set; }

        }
        public class SaveUpdateFormulation : IReturn<SaveUpdateFormulation>
        {        

        }
    }
}