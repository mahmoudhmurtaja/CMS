using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Models
{
    public class EventCategory : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<Event> Events { get; set; }
        
    }
}
