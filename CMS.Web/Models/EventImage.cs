using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Models
{
    public class EventImage 
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
