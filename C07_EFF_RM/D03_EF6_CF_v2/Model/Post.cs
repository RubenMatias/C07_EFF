using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D02_EF6_CF_v2.Model
{
    public class Post
    {
        #region Scalar properties

        public int PostID { get; set; }    //PK

        public int BlogID { get; set; }     //FK

        public string Title { get; set; }

        public string Content { get; set; }

        #endregion

        #region Navigation properties

        public virtual Blog Blog { get; set; }

        #endregion
    }
}
