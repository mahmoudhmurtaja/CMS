using CMS.Web.Data;
using CMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Services.EventCategorys
{
    public class EventCategoryService : IEventCategoryService
    {
        private readonly ApplicationDbContext _DB;

        public EventCategoryService(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        public List<EventCategory> GetAll()
        {
            return _DB.EventCategorys.Where(x => !x.IsDelete).ToList();
        }

        public void Create(EventCategory model)
        {
            _DB.EventCategorys.Add(model);
            _DB.SaveChanges();
        }
        public void Update(EventCategory model)
        {
            _DB.EventCategorys.Update(model);
            _DB.SaveChanges();
        }

        public EventCategory Get(int id)
        {
            return _DB.EventCategorys.SingleOrDefault(x => !x.IsDelete && x.Id == id);
        }

        public void Delete(int id )
        {
            var model = _DB.EventCategorys.SingleOrDefault(x => !x.IsDelete && x.Id == id);
            model.IsDelete = true;
            _DB.EventCategorys.Update(model);
            _DB.SaveChanges();
        }
    }
}
