using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Models
{
    public class Post : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public string AttachmentUrl { get; set; }
        public DateTime PublishAt { get; set; }
        public int PostCategoryId { get; set; }
        public PostCategory PostCategory { get; set; }
        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }

    }
}
