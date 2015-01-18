using System.Collections.Generic;
using System.Linq;

namespace _05eRoleBasedAuthorization.Models
{
    public interface IWidgetRepository
    {
        IQueryable<Widget> Get(bool isIvision, bool isMicrosoft);
    }

    public class WidgetRepository : IWidgetRepository
    {
        private readonly List<Widget> _widgets = new List<Widget>();

        public WidgetRepository()
        {
            _widgets.Add(new Widget
            {
                Id = 1,
                Description = "Answering Machine",
                InventedYear = 1898
            });
            _widgets.Add(new Widget
            {
                Id = 2,
                Description = "Camcorder",
                InventedYear = 1982
            });
            _widgets.Add(new Widget
            {
                Id = 3,
                Description = "Personal Computer",
                InventedYear = 1974,
                IsIVisionSecured = true
            });
            _widgets.Add(new Widget
            {
                Id = 4,
                Description = "Laptop Computer",
                InventedYear = 1983,
                IsMicrosoftSecured = true
            });
            _widgets.Add(new Widget
            {
                Id = 5,
                Description = "Internet",
                InventedYear = 1969,
                IsMicrosoftSecured = true,
                IsIVisionSecured = true
            });
        }

        public IQueryable<Widget> Get(bool isIvision, bool isMicrosoft)
        {
            if (isIvision && isMicrosoft)
            {
                return _widgets.AsQueryable();
            }

            if (isIvision)
            {
                return _widgets.Where(w => !w.IsSecured || w.IsIVisionSecured).AsQueryable();
            }

            if (isMicrosoft)
            {
                return _widgets.Where(w => !w.IsSecured || w.IsMicrosoftSecured).AsQueryable();
            }

            return _widgets.Where(w => !w.IsSecured).AsQueryable();
        }
    }
}