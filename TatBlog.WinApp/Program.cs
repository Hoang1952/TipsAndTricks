using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;
using TatBlog.Services.Blogs;

//Tao doi tuong  dbContext de quan ly phien lam viec
// voi CSDL va trang thai cua cac doi tuong
var context = new BlogDbContext();

//Tao doi tuong BlogRepository
IBlogRepository blogRepo = new BlogRepository(context);

//Tao doi tuong khoi tao du lieu mau
var seeder = new DataSeeder(context);

//Goi ham Initialize de nhap du lieu mau
seeder.Initialize();

//Doc danh sach tac gia tu co so du lieu
var authors = context.Authors.ToList();

//Lay kem ten tac gia va chuyen muc
var posts = context.Posts
    .Where(p => p.Published)
    .OrderBy(p => p.Title)
    .Select(p => new
    {
        Id = p.Id,
        Title = p.Title,
        ViewCount = p.ViewCount,
        PostedDate = p.PostedDate,
        Author = p.Author.FullName,
        Category = p.Category.Name,
    })
    .ToList();

//Xuat danh sach tac gia ra man hinh
Console.WriteLine("{0, -4}{1,-30}{2,-30}{3,12}",
    "ID", "FullName", "Email", "Joined Date");

foreach (var author in authors)
{
    Console.WriteLine("{0,-4}{1,-30}{2,-30}{3,12:MM/dd/yyyy}",
        author.Id, author.FullName, author.Email, author.JoinedDate);
}

//Tim 3 bai viet duoc xem/ doc nhieu nhat
//var posts = await blogRepo.GetPopularArticlesAsync(3);

//Xuat danh sach bai viet ra man hinh 
foreach (var post in posts)
{
    Console.WriteLine("ID         :{0}", post.Id);
    Console.WriteLine("Title      :{0}", post.Title);
    Console.WriteLine("View       :{0}", post.ViewCount);
    Console.WriteLine("Date       :{0:MM/dd/yyyy}", post.PostedDate);
    Console.WriteLine("Author     :{0}", post.Author);
    Console.WriteLine("Category   :{0}", post.Category);
    Console.WriteLine("".PadRight(80, '-'));
}
