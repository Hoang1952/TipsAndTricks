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
        public string UrlSlug { get; set; }

        //Duong dan den tap tin hinh anh
        public string ImageUrl { get; set; }

        //So luot xem, doc bai viet
        public int ViewCount { get; set; }

        //Trang thai bai viet
        public bool Published { get; set; }

        //Ngay gio dang bai
        public DateTime PostedDate { get; set; }

        //Ngay gio cap nhat lan cuoi
        public DateTime? ModifiedDate { get; set; }

        //Ma chuyen muc
        public int CategoryId { get; set; }

        //Ma tac gia cua bai viet
        public int AuthorId { get; set; }

        //Chuyen muc cua bai viet
        public Category Category { get; set; }

        //Tac gia cua bai viet
        public Author Author { get; set; }

        //Danh sach cac tu khoa cua bai viet
        public IList<Tag> Tags { get; set; }
    }
}
