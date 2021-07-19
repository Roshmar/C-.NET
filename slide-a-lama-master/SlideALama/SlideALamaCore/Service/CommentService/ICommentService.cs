using System;
using System.Collections.Generic;
using SlideLama.Entity;

namespace SlideLama.Service
{
    public interface ICommentService
    {
        void AddComment(Comment comment);

        IList<Comment> GetComment();

        void ClearComment();
    }
}