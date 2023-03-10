using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Services.Extensions;

namespace TatBlog.Services.Blogs
{
    public class BlogRepository : IBlogRepository
    {
        //Cai dat cac phuong thuc khoi tao
        private readonly BlogDbContext _context;
        public BlogRepository(BlogDbContext context)
        {
            _context = context; 
        }


        //Tim Top N bai viet pho duoc nhieu nguoi xem nhat
        public async Task<IList<Post>> GetPopularArticlesAsync(
            int numPosts, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Post>()
                .Include(x => x.Author)
                .Include(x => x.Category)
                .OrderByDescending(p => p.ViewCount)
                .Take(numPosts)
                .ToListAsync(cancellationToken);
        }

        //Tim bai viet co ten dinh danh la 'slug'
        //va duoc dang vao thang 'month' nam 'year'
        public async Task<Post> GetPostAsync(
            int year, 
            int month, 
            string slug, 
            CancellationToken cancellationToken = default)
        {
            IQueryable<Post> postsQuery = _context.Set<Post>()
                .Include(x => x.Category)
                .Include(x => x.Author);

            if(year > 0)
            {
                postsQuery = postsQuery.Where(x => x.PostedDate.Year == year);
            }

            if (month > 0)
            {
                postsQuery = postsQuery.Where(x => x.PostedDate.Month == month);
            }

            if (!string.IsNullOrWhiteSpace(slug))
            {
                postsQuery = postsQuery.Where(x => x.UrlSlug == slug);
            }

            return await postsQuery.FirstOrDefaultAsync(cancellationToken);
        }

        //Tang so luot xem cua mot bai viet
        public async Task IncreaseViewCountAsync(
            int postId, CancellationToken cancellationToken = default)
        {
             await _context.Set<Post>()
                .Where(x => x.Id == postId)
                .ExecuteUpdateAsync(p =>
                 p.SetProperty(x => x.ViewCount, x => x.ViewCount + 1),
                 cancellationToken);
        }

        //Kiem tra xem ten dinh danh cua bai viet da co hay chua
        public async Task<bool> IsPostSlugExistedAsync(
            int postId,
            string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Post>()
                .AnyAsync(x => x.Id != postId && x.UrlSlug == slug, 
                cancellationToken);
        }

        //Lay danh sach chuyen muc va so luong bai viet
        // nam thuoc tung chuyen muc/ chu de
        public async Task<IList<CategoryItem>> GetCategoriesAsync(
            bool showOnMenu = false,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Category> categories = _context.Set<Category>();

            if(showOnMenu) 
            {
                categories = categories.Where(x => x.ShowOnMenu);
            }

            return await categories
                .OrderBy(x => x.Name)
                .Select(x => new CategoryItem()
                {
                    Id = x.Id,
                    Name= x.Name,
                    UrlSlug= x.UrlSlug,
                    Description= x.Description,
                    ShowOnMenu= x.ShowOnMenu,
                    PostCount = x.Posts.Count(p => p.Published)
                })
                .ToListAsync(cancellationToken);
        }

        public Task<IList<CategoryItem>> GetCategoriesAsync(bool showOnMenu)
        {
            throw new NotImplementedException();
        }

        //Lay danh sach tu khoa/ the va phan trang theo cac tham so pagingParams
        public async Task<IPagedList<TagItem>> GetPagedTagsAsync(
            IPagingParams pagingParams,
            CancellationToken cancellationToken = default
            )
        {
            var tagQuery = _context.Set<Tag>()
                .Select(x => new TagItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlSlug = x.UrlSlug,
                    Description = x.Description,
                    PostCount = x.Posts.Count(p => p.Published)
                });

            return await tagQuery.ToPagedListAsync(pagingParams, cancellationToken);
        }
    }
}
