using ServiceStack;
using Smartformulator_Formulalookup_Webservice.ServiceModel;

namespace Smartformulator_Formulalookup_Webservice.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}