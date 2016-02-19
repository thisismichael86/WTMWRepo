using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WelcomeToMyHead.Models;

namespace WelcomeToMyHead.Services
{
    public interface IBlogPostService
    {
        List<BlogPost> GetRecentPosts();
    }
}
