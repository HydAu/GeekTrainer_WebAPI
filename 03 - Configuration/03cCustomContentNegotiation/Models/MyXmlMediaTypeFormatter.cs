using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace _03cCustomContentNegotiation.Models
{
    public class MyXmlMediaTypeFormatter : XmlMediaTypeFormatter
    {
        public MyXmlMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml+full"));
            UseXmlSerializer = false;
            this.AddQueryStringMapping("xml", "true", "application/xml+full");
        }
    }
}