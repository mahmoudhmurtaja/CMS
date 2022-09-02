using CMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Services.EventCategorys
{
    public interface IEventCategoryService
    {
        public List<EventCategory> GetAll();
        public void Create(EventCategory model);
        public void Update(EventCategory model);
        public EventCategory Get(int id);
        public void Delete(int id);
    }
}
