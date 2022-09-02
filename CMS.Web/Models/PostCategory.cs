using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Models
{
    public class PostCategory : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }
}
