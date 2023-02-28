using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatBlog.Core.Entities
{
    internal class Tag
    {
        //Ma tu khoa
        public int Id { get; set; }

        //Noi dung tu khoa
        public string Name { get; set; }

        //Ten dinh dang de tao URL
        public string UrlSlug { get; set; }

        //Mo ta them ve tu khoa
        public string Description { get; set; }

        //Danh sach bai viet co chua tu khoa
        public IList<Post> Posts { get; set; }

    }
}
