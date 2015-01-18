using System;

namespace _05eRoleBasedAuthorization.Models
{
    public class Widget
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int InventedYear { get; set; }
        public bool IsMicrosoftSecured { get; set; }
        public bool IsIVisionSecured { get; set; }

        public bool IsSecured
        {
            get { return IsIVisionSecured || IsMicrosoftSecured; }
        }
    }
}