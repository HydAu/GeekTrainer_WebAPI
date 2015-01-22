using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace _06dVersioning.Version
{
    public class VersionControllerSelector : DefaultHttpControllerSelector
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        public VersionControllerSelector(HttpConfiguration config) : base(config)
        {
        }

        /// <summary>
        /// Implement required operation that returns controller based on version, URL path
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var descriptor = base.SelectController(request);

            if (!descriptor.ControllerName.StartsWith("versions", 
                StringComparison.InvariantCultureIgnoreCase))
            {
                return descriptor;
            }

            var version = request.GetVersion();

            if (string.IsNullOrWhiteSpace(version) ||
                version.Equals("v2", StringComparison.InvariantCultureIgnoreCase))
            {
                return descriptor;
            }
            var newName = string.Format("Versions{0}", version);
            var controllers = base.GetControllerMapping();
            HttpControllerDescriptor newDescriptor;
            if (controllers.TryGetValue(newName, out newDescriptor))
            {               
                return newDescriptor;
            }
            return descriptor;
        }
    }
}