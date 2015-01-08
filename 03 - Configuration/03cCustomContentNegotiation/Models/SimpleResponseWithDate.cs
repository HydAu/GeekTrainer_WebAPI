using System;

namespace _03cCustomContentNegotiation.Models
{
    public class SimpleResponseWithDate : SimpleResponse 
    {
        public SimpleResponseWithDate()
        {
            BornOnDate = DateTime.Now;
        }

        public SimpleResponseWithDate(string message) : this()
        {
            Message = message;
        }

        public DateTime BornOnDate { get; set; }
    }
}