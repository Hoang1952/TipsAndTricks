using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;

namespace TatBlog.Core.Entities
{
    public class Category : IEntity
    {
        // Ma chuyen muc
        public int Id { get; set; }

        //Ten chuyen muc, chu de
        public string Name { get; set; }

        //Ten dinh dang dung de tao URL
        public string UrlSlug { get; set; }

        //Mo ta them ve chuyen muc
        public string Description { get; set; }

        //Danh dau chuyen muc duoc hien thi tren Menu
        public bool ShowOnMenu { get; set; }

        //Danh sach cac bai viet thuoc chuyen muc
        public IList<Post> Posts { get; set; }
    }
}
