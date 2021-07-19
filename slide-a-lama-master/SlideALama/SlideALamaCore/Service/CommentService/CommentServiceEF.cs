using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using SlideLama.Entity;
using SlideLama.Service;


namespace SlideLama.SlideALamaCore.Service.CommentService
{
    [Serializable]
    public class CommentServiceEF : ICommentService
    {
        public void AddComment(Comment comment)
        {
            using (var context = new SlideLamaDbContext())
            {
                context.Comments.Add(comment);
                context.SaveChanges();
            }
        }

        [Obsolete]
        public void ClearComment()
        {
            using (var context = new SlideLamaDbContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Comments");
            }
        }

        public IList<Comment> GetComment()
        {
            using (var context = new SlideLamaDbContext())
            {
                return (from s in context.Comments
                        orderby s.PlayerCountry
                            descending
                        select s).Take(4)
                        .ToList();
            }
        }
    }
}
