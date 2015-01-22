using System;
using System.Linq;
using System.Net.Http;

namespace _06dVersioning.Version
{
    public static class VersionHelper
    {
        public static string GetVersion(this HttpRequestMessage message)
        {
            if (message.Headers.Contains("version"))
            {
                var version = message.Headers.GetValues("version").FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(version))
                {
                    return (version.StartsWith("v", StringComparison.InvariantCultureIgnoreCase)
                        ? version
                        : string.Format("v{0}", version)).ToUpper();
                }
            }

            var acceptHeader = message.Headers.Accept;
            foreach (var acceptedType in acceptHeader)
            {
                var version = acceptedType.Parameters.FirstOrDefault(
                    v => v.Name.Equals("version", StringComparison.InvariantCultureIgnoreCase));
                if (version != null && !string.IsNullOrWhiteSpace(version.Value))
                {
                    return (version.Value.StartsWith("v", StringComparison.InvariantCultureIgnoreCase)
                        ? version.Value
                        : string.Format("v{0}", version.Value)).ToUpper();
                }
            }

            return string.Empty;
        }
    }
}