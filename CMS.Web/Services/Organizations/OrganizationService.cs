using CMS.Web.Data;
using CMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Services.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly ApplicationDbContext _DB;
        public OrganizationService(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        
        public List<Organization> GetAll()
        {
            return (_DB.Organizations.Where(x => !x.IsDelete).ToList());
        }
        public Organization Get(int Id)
        {
            var Organization = _DB.Organizations.SingleOrDefault(x => !x.IsDelete && x.Id == Id);
            return (Organization);
        }
        public void Create(Organization model)
        {
            _DB.Organizations.Add(model);
            _DB.SaveChanges();
        }
        public void Update(Organization model)
        {
            _DB.Organizations.Update(model);
            _DB.SaveChanges();
        }
        public void Delete(int Id)
        {
            var model = _DB.Organizations.SingleOrDefault(x => !x.IsDelete && x.Id == Id);
            model.IsDelete = true;
            _DB.Organizations.Update(model);
            _DB.SaveChanges();
        }
    }
}
