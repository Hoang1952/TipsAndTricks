using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatBlog.Core.Entities
{
    public class Post
    {
        //Ma bai viet
        public int Id { get; set; }

        //Ten de bai viet
        public string Title { get; set; }

        //Mo ta hay gioi thieu ngan ve noi dung
        public string ShortDescription { get; set; }

        //Noi dung chi tiet cua bai viet
        public string Description { get; set; }

        //Metadata
        public string Meta { get; set; }

        // Ten dinh dang de tao URL
    }
}
