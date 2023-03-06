﻿using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;
using TatBlog.Services.Blogs;
using TatBlog.WinApp;

//Tao doi tuong  dbContext de quan ly phien lam viec
// voi CSDL va trang thai cua cac doi tuong
var context = new BlogDbContext();

//Tao doi tuong BlogRepository
IBlogRepository blogRepo = new BlogRepository(context);

//Lay danh sach chuyen muc
//var categories = await blogRepo.GetCategoriesAsync();
//////Xuat ra man hinh
//Console.WriteLine("{0,-5}{1,-50}{2,10}",
//    "ID", "Name", "Count");

//foreach (var item in categories)
//{
//    Console.WriteLine("{0,-5}{1,-50}{2,10}",
//        item.Id, item.Name, item.PostCount);
//}

//Tao doi tuong khoi tao du lieu mau
//var seeder = new DataSeeder(context);

////Goi ham Initialize de nhap du lieu mau
//seeder.Initialize();

////Doc danh sach tac gia tu co so du lieu
//var authors = context.Authors.ToList();

////Lay kem ten tac gia va chuyen muc
//var posts = context.Posts
//    .Where(p => p.Published)
//    .OrderBy(p => p.Title)
//    .Select(p => new
//    {
//        Id = p.Id,
//        Title = p.Title,
//        ViewCount = p.ViewCount,
//        PostedDate = p.PostedDate,
//        Author = p.Author.FullName,
//        Category = p.Category.Name,
//    })
//    .ToList();

//Xuat danh sach tac gia ra man hinh
//Console.WriteLine("{0, -4}{1,-30}{2,-30}{3,12}",
//    "ID", "FullName", "Email", "Joined Date");

//foreach (var author in authors)
//{
//    Console.WriteLine("{0,-4}{1,-30}{2,-30}{3,12:MM/dd/yyyy}",
//        author.Id, author.FullName, author.Email, author.JoinedDate);
//}

//Tim 3 bai viet duoc xem/ doc nhieu nhat
//var posts = await blogRepo.GetPopularArticlesAsync(3);

//Xuat danh sach bai viet ra man hinh 
//foreach (var post in posts)
//{
//    Console.WriteLine("ID         :{0}", post.Id);
//    Console.WriteLine("Title      :{0}", post.Title);
//    Console.WriteLine("View       :{0}", post.ViewCount);
//    Console.WriteLine("Date       :{0:MM/dd/yyyy}", post.PostedDate);
//    Console.WriteLine("Author     :{0}", post.Author);
//    Console.WriteLine("Category   :{0}", post.Category);
//    Console.WriteLine("".PadRight(80, '-'));
//}

//Tao doi tuong chua tham so phan trang
//var pagingParams = new PagingParams
//{
//    PageNumber = 1,              //Lay ket qua o trang so 1
//    PageSize = 5,                //Lay 5 mau tin
//    SortColumn = "Name",        //Sap xep theo ten
//    SortOrder = "DESC"          //Theo chieu giam dan
//};

////Lay danh sach tu khoa
//var tagsList = await blogRepo.GetPagedTagsAsync(pagingParams);

////Xuat ra man hinh
//Console.WriteLine("{0,-5}{1,-50}{2,10}",
//    "ID", "Name", "Count");

//foreach (var item in tagsList)
//{
//    Console.WriteLine("{0,-5}{1,-50}{2,10}",
//        item.Id, item.Name, item.PostCount);
//}

//C. BÀI TẬP THỰC HÀNH
////a.Tìm một thẻ (Tag) theo tên định danh (slug) 
//var TagSlug = await blogRepo.FindTagBySlugAsync("Razor Page");
//Console.WriteLine("{0,-5}{1,-50}{2,10}",
//     TagSlug.Id, TagSlug.Name, TagSlug.UrlSlug);


//b. Tạo lớp DTO có tên là TagItem để chứa các thông tin về thẻ và số lượng
//bài viết chứa thẻ đó. 
//var TagList = await blogRepo.GetTagsAsync();
//Console.WriteLine("{0,-5}{1,-50}{2,10}",
//    "ID", "Name", "Count");

//foreach (var item in TagList)
//{
//    Console.WriteLine("{0,-5}{1,-50}{2,10}",
//        item.Id, item.Name, item.PostCount);
//}

//c. Lấy danh sách tất cả các thẻ (Tag) kèm theo số bài viết chứa thẻ đó. Kết
//quả trả về kiểu IList<TagItem>.
//var tags = await blogRepo.FindTagItemSlugAsync();
//Console.WriteLine("{0,-5}{1,-50}{2,-20}", "ID", "Name", "Post Count");
//foreach(var tag in tags)
//{
//    Console.WriteLine("{0,-5}{1,-50}{2,-20}", tag.Id, tag.Name, tag.PostCount);
//}


IBlogRepository repository = new BlogRepository(context);

//g. Thêm hoặc cập nhật một chuyên mục/chủ đề
var isAdd = await blogRepo.AddOrUpdateCategoryAsync(new TatBlog.Core.Entities.Category()
{
    Name = "Toeic",
    Description = " Test of English for International Communication",
    UrlSlug = "toeic_learning",
    ShowOnMenu = true
});

Console.WriteLine(isAdd ? "True" : "False");