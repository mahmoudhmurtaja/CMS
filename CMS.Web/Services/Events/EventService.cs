using CMS.Web.Data;
using CMS.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Services.Events
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _DB;
        public EventService(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        public List<Event> GetAll()
        {
            var events = _DB.Events.Include(x => x.EventCategory).Include(x => x.Organization).Where(x => !x.IsDelete).ToList();
            return (events);
        }

        public void Create(Event model)
        {
            _DB.Events.Add(model);
            _DB.SaveChanges();
        }
        public void Update(Event model)
        {
            _DB.Events.Update(model);
            _DB.SaveChanges();
        }
        public void AddImage(EventImage Image)
        {
            _DB.EventImages.Add(Image);
            _DB.SaveChanges();
        }
        public void UpdateImage(EventImage Image)
        {
            _DB.EventImages.Update(Image);
            _DB.SaveChanges();
        }

        public Event Get(int id)
        {
            return _DB.Events.SingleOrDefault(x => !x.IsDelete && x.Id == id);
        }

        public void Delete(int id )
        {
            var model = _DB.Events.SingleOrDefault(x => !x.IsDelete && x.Id == id);
            model.IsDelete = true;
            _DB.Events.Update(model);
            _DB.SaveChanges();
        }
        public void Save()
        {
            _DB.SaveChanges();
        }
        
        public SelectList SelctEventCategory()
        {
            var SelectList = new SelectList(_DB.EventCategorys.Where(x => !x.IsDelete), "Id", "Name");
            return (SelectList);
        }
        public SelectList SelctOrganization()
        {
            var SelectList = new SelectList(_DB.Organizations.Where(x => !x.IsDelete), "Id", "Name");
            return (SelectList);
        }

    }
}
