using System;

namespace _02aContentNegotation.Models
{
    public class DemoItem
    {
        private Guid _guid;

        public DemoItem()
        {
            _guid = Guid.NewGuid();
        }

        public string Id
        {
            get { return _guid.ToString(); }
            set
            {
                Guid guid;
                if (Guid.TryParse(value, out guid))
                {
                    _guid = guid;
                }
            }
        }
    }
}