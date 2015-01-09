using System.Collections.Generic;

namespace _03cCustomContentNegotiation.Models
{
    public class SingleLink
    {
        public string href { get; set; }
    }
    
    public class Links
    {
        public SingleLink self { get; set; }
    }

    public class SimpleHateoasResponse 
    {
        public Links _links { get; set; }
        public string Message { get; set; }
    }
}