using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;
using D02_EF6_CF_v2.Model;

namespace D03_EF6_CF_v2.Model
{
    public static class PostRepository
    {
        public static int CreatePost()
        {
            using (var db = new BlogContext())
            {
                Post post01 = new Post();
                Post post02 = new Post();
                Post post03 = new Post();

                post01.BlogID = 1;
                post01.Title = "First Post";
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

                return countPosts;
            }


        }

        public static void ReadPost(int countPosts)
        {
            var db = new BlogContext();

            Utility.WriteTitle("Posts");

            Utility.WriteMessage($"{countPosts} posts inseridos.", "", "\n\n");

            var queryPosts = db.Post.Select(p => p).OrderBy(p => p.PostID).ToList();

            queryPosts.ForEach(p => Utility.WriteMessage($"{p.PostID}: {p.Title} - {p.Content} - {p.BlogID}", "", "\n\n"));

        }
    }
}
