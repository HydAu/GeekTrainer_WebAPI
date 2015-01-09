using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace _03cCustomContentNegotiation.Models
{
    public class MyJsonMediaTypeFormatter : JsonMediaTypeFormatter
    {
        public MyJsonMediaTypeFormatter() 
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json+full"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/hal+json"));
        }
    }
}