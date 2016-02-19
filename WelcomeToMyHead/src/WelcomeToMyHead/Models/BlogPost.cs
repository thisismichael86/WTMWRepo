using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WelcomeToMyHead.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                _htmlTitle = new HtmlString(value);
            }
        }

        public string Body
        {
            get
            {
                return _body;
            }
            set
            {
                _body = value;
                _htmlBody = new HtmlString(value);
            }
        }

        private HtmlString _htmlTitle;

        [NotMapped]
        public HtmlString HtmlTitle
        {
            get
            {
                return _htmlTitle ?? new HtmlString(Title);
            }
        }

        private HtmlString _htmlBody;
        private string _title;
        private string _body;

        [NotMapped]
        public HtmlString HtmlBody
        {
            get
            {
                return _htmlBody ?? new HtmlString(Body);
            }
        }
    }
}
