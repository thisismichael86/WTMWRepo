using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WelcomeToMyHead.Models;

namespace WelcomeToMyHead.Services
{
    public class BlogPostService : IBlogPostService
    {
        private ApplicationDbContext _context;

        public BlogPostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<BlogPost> GetRecentPosts()
        {
            List<BlogPost> returnVal = null;
            try
            {
                returnVal = _context.BlogPost.ToList();
            }
            catch (Exception)
            {                
            }

            return returnVal ?? new List<BlogPost>();
        }
    }
}
