using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatBlog.Core.Entities
{
    public class Author
    {
        //Ma tac gia bai viet
        public int Id { get; set; }

        //Ten tac gia
        public string FullName { get; set; }

        //Ten dinh dang dung de tao URL
        public string UrlSlug { get; set; }

        //Duong dan toi file hinh anh
        public string ImageUrl { get; set; }

        //Ngay bat dau
        public DateTime JoinedDate { get; set; }

        //Dia chi email
        public string Email { get; set; }

        //Ghi chu
        public string Notes { get; set; }

        //Danh sach cac bai viet cua tac gia
        public IList<Post> Posts { get; set; }
    }
}
