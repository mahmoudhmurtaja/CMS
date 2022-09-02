using CMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Services.PostCategorys
{
    public interface IPostCategoryService
    {
        public List<PostCategory> GetAll();
        public PostCategory Get(int Id);
        public void Create(PostCategory model);
        public void Update(PostCategory model);
        public void Delete(int Id);
    }
}
