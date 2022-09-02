using CMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Services.Organizations
{
    public interface IOrganizationService
    {
        public List<Organization> GetAll();
        public Organization Get(int Id);
        public void Create(Organization model);
        public void Update(Organization model);
        public void Delete(int Id);
    }
}
