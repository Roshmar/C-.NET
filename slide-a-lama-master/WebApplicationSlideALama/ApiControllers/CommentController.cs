using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlideLama.Entity;
using SlideLama.Service;
using SlideLama.SlideALamaCore.Service.CommentService;

namespace WebApplicationSlideALama.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService = new CommentServiceEF();

        // GET: api/Comment
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return _commentService.GetComment();
        }

        // POST: api/Comment
        [HttpPost]
        public void Post([FromBody] Comment comment)
        {
            _commentService.AddComment(comment);
        }
    }
}