using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WelcomeToMyHead.Models;

namespace WelcomeToMyHead.ViewModels.BlogPosts
{
    public class BlogPostViewModel
    {
        public BlogPostViewModel()
        {
        }

        public BlogPostViewModel(IEnumerable<SelectListItem> categories)
        {
            Categories = categories;
        }

        public BlogPost Post { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
