
// T-SQL DML: data manipulation language --> SELECT, INSERT, UPDATE, DELETE

// CRUD Operations: CREATE, READE, UPDATE, DELETE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;
using D02_EF6_CF_v1.Model;

namespace D02_EF6_CF_v1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utility.SetUnicodeConsole();

            using (var db = new BlogContext())
            {

                #region Blog

                //Criar e gravar um novo Blog

                Blog blog01 = new Blog();

                // blog01.BlogID = 1; não é necessário porque pela convenção as PK já são auto incremented
                blog01.Name = "EF6";

                db.Blog.Add(blog01);

                db.SaveChanges();

                var queryBlogs = db.Blog.Select(b => b).OrderBy(b => b.Name);

                Utility.WriteTitle("Blogs");

                queryBlogs.ToList().ForEach(b => Utility.WriteMessage($"{b.BlogID} - {b.Name}", "", "\n\n"));


                #endregion

                #region Posts

                Post post01 = new Post();
                Post post02= new Post();
                Post post03= new Post();

                post01.BlogID = 1;
                post01.Title= "First Post";
                post01.Content = "All about Entity Framework 1";

                post02.BlogID = 1;
                post02.Title = "Second Post";
                post02.Content = "All about Entity Framework 2";

                post03.BlogID = 1;
                post03.Title = "Third Post";
                post03.Content = "All about Entity Framework 3";

                db.Post.Add(post01);
                db.Post.Add(post02);
                db.Post.Add(post03);

                int countPosts = db.SaveChanges();

                Utility.WriteTitle("Posts");

                Utility.WriteMessage($"{countPosts} posts inseridos.", "", "\n\n");

                var queryPosts = db.Post.Select(p => p).OrderBy(p => p.PostID).ToList();

                queryPosts.ForEach(p => Utility.WriteMessage($"{p.PostID}: {p.Title} - {p.Content} - {p.BlogID}"));

                #endregion


                Utility.TerminateConsole();

            }

        }
    }
}
