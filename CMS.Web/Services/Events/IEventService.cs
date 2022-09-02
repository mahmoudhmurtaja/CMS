using CMS.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Services.Events
{
    public interface IEventService
    {
        public List<Event> GetAll();
        public void Create(Event model);
        public void Update(Event model);
        public void AddImage(EventImage Image);
        public void UpdateImage(EventImage Image);
        public Event Get(int id);
        public void Delete(int id);
        public void Save();
        public SelectList SelctEventCategory();
        public SelectList SelctOrganization();
    }
}
