using Funq;
using ServiceStack;
using Smartformulator_Formulalookup_Webservice.ServiceInterface;

namespace Smartformulator_Formulalookup_Webservice
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptyAspNet
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("Smartformulator_Formulalookup_Webservice", typeof(AppHost).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {

         ////   this.Plugins.Add(new PostmanFeature());
            Plugins.Add(new CorsFeature(
    allowOriginWhitelist: new[] { "http://localhost", "http://localhost:5001", "http://run.plnkr.co" },
    allowCredentials: true,
    allowedHeaders: "Content-Type, Allow, Authorization, X-Args"));
            container.RegisterAutoWired<SF_Repository>();
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());
        }
    }
}