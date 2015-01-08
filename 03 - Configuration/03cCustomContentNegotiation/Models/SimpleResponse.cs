using System.Runtime.Serialization;

namespace _03cCustomContentNegotiation.Models
{
    [KnownType(typeof(SimpleResponseWithDate))]
    public class SimpleResponse
    {
        public SimpleResponse()
        {
            
        }

        public SimpleResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}