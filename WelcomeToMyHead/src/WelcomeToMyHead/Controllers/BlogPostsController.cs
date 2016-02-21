using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WelcomeToMyHead.Models;
using Microsoft.AspNet.Authorization;
using WelcomeToMyHead.ViewModels.BlogPosts;
using WelcomeToMyHead.Services;
using System;

namespace WelcomeToMyHead.Controllers
{
    [Authorize]
    public class BlogPostsController : Controller
    {
        private ApplicationDbContext _context;

        public BlogPostsController(ApplicationDbContext context)
        {
            _context = context;   
        }

        // GET: BlogPosts
        public IActionResult Index()
        {
            return View(_context.BlogPost.ToList());
        }

        // GET: BlogPosts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BlogPost blogPost = _context.BlogPost.Single(m => m.Id == id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }

            return View(blogPost);
        }

        // GET: BlogPosts/Create
        public IActionResult Create()
        {
            //TODO: Fat controller logic - this needs moving to a service
            var categories = from c in _context.PostCategory
                            select new SelectListItem
                            {
                                Text = c.Name,
                                Value = c.Id.ToString()
                            };

            var model = new BlogPostViewModel(categories);

            return View(model);
        }

        // POST: BlogPosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogPostViewModel blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.Post.CreatedDate = DateTime.Now;

                _context.BlogPost.Add(blogPost.Post);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BlogPost blogPost = _context.BlogPost.Single(m => m.Id == id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BlogPostViewModel blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.Post.UpdatedDate = DateTime.Now;

                _context.Update(blogPost.Post);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BlogPost blogPost = _context.BlogPost.Single(m => m.Id == id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }

            return View(blogPost);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            BlogPost blogPost = _context.BlogPost.Single(m => m.Id == id);
            _context.BlogPost.Remove(blogPost);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
