using CMS.Web.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Dto
{
    public class CreateUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Mobile { get; set; }
        [Required]
        public UserType Type { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public int? OrganizationId { get; set; }
    }
}
