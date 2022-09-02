using CMS.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Services.Posts
{
    public interface IPostService
    {
        public List<Post> GetAll();
        public Post Get(int Id);
        public void Create(Post model);
        public void Update(Post model);
        public void Delete(int Id);
        public SelectList SelectpostCategory();
    }
}
