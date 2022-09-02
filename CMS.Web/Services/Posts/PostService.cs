using CMS.Web.Data;
using CMS.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _DB;
        public PostService(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public List<Post> GetAll()
        {
           return (_DB.Posts.Include(x => x.PostCategory).Where(x => !x.IsDelete).ToList());
        }
        public Post Get(int Id)
        {
            return (_DB.Posts.SingleOrDefault(x => !x.IsDelete && x.Id == Id));
        }
        public void Create(Post model)
        {
            _DB.Posts.Add(model);
            _DB.SaveChanges();
        }
        public void Update(Post model)
        {
            _DB.Posts.Update(model);
            _DB.SaveChanges();
        }
        public void Delete(int Id)
        {
            var Post = _DB.Posts.SingleOrDefault(x => !x.IsDelete && x.Id == Id);
            Post.IsDelete = true;
            _DB.Update(Post);
            _DB.SaveChanges();
        }
        public SelectList SelectpostCategory()
        {
            return (new SelectList(_DB.PostCategorys.Where(x => !x.IsDelete), "Id", "Name"));
        }
    }
}
