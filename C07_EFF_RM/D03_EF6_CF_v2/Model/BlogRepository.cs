using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;

namespace D02_EF6_CF_v2.Model
{
    
    public static class BlogRepository
    {
        
       
        public static void CreateBlog()
        {
            using (var db = new BlogContext())
            {
                Blog blog01 = new Blog();


                blog01.Name = "EF6";

                db.Blog.Add(blog01);

                db.SaveChanges();

            }
        }

        public static void ReadBlog()
        {
            var db = new BlogContext();

            var queryBlogs = db.Blog.Select(b => b).OrderBy(b => b.Name);

            Utility.WriteTitle("Blogs");

            queryBlogs.ToList().ForEach(b => Utility.WriteMessage($"{b.BlogID} - {b.Name}", "", "\n\n"));

        }

       
    }
}
