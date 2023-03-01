﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;

namespace TatBlog.Services.Blogs
{
    public interface IBlogRepository
    {
        //Tim bai viet co ten dinh danh la 'slug'
        //va duoc dang vao thang 'month' nam 'year'
        Task<Post> GetPostAsync(
            int year,
            int month,
            string slug,
            CancellationToken cancellationToken = default);

        //Tim Top N bai viet pho duoc nhieu nguoi xem nhat
        Task<IList<Post>> GetPopularArticlesAsync(
            int numPosts,
            CancellationToken cancellationToken = default);

        //Kiem tra xem ten dinh danh cua bai viet da co hay chua
        Task<bool> IsPostSlugExistedAsync(
            int postId, string slug,
            CancellationToken cancellationToken = default);

        //Tang so luot xem cua mot bai viet
        Task IncreaseViewCountAsync(
            int postId,
            CancellationToken cancellationToken = default);
    }
}
