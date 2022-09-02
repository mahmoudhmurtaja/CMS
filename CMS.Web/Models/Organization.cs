using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Models
{
    public class Organization : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string WorkNature { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telephone { get; set; }
        public List<Post> Posts { get; set; }
        public List<Event> Events { get; set; }
    }
}
