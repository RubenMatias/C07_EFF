using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;
using D02_EF6_CF_v2.Model;
using D03_EF6_CF_v2.Model;

namespace D03_EF6_CF_v2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Utility.SetUnicodeConsole();

            BlogRepository.CreateBlog();
            BlogRepository.ReadBlog();
            PostRepository.ReadPost(PostRepository.CreatePost());


            Utility.TerminateConsole();


        }
    }
}
