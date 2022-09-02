using CMS.Web.Data;
using CMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Services.PostCategorys
{
    public class PostCategoryService : IPostCategoryService
    {
        private readonly ApplicationDbContext _DB;
        public PostCategoryService(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        public List<PostCategory> GetAll()
        {
           return (_DB.PostCategorys.Where(x => !x.IsDelete).ToList());
        }
        public PostCategory Get(int Id)
        {
            return (_DB.PostCategorys.SingleOrDefault(x => !x.IsDelete && x.Id == Id));
        }
        public void Create(PostCategory model)
        {
            _DB.PostCategorys.Add(model);
            _DB.SaveChanges();
        }
        public void Update(PostCategory model)
        {
            _DB.PostCategorys.Update(model);
            _DB.SaveChanges();
        }
        public void Delete(int Id)
        {
            var PostCategory = _DB.PostCategorys.SingleOrDefault(x => !x.IsDelete && x.Id == Id);
            PostCategory.IsDelete = true;
            _DB.PostCategorys.Update(PostCategory);
            _DB.SaveChanges();
        }
    }
}
