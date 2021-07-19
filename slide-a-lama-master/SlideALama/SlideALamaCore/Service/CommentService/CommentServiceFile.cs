using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using SlideLama.Entity;

namespace SlideLama.Service
{
    [Serializable]
    public class CommentServiceFile : ICommentService
    {    
        private const string FileName = "Comment.bin";
        
        private List<Comment> comment = new List<Comment>();
        
        public void AddComment(Comment comments)
        {
            comment.Add(comments);

            SaveComment();
        }

        public IList<Comment> GetComment()
        {
            LoadComment();
            return (from s in comment orderby s.PlayerCountry  
                descending select s).Take(5).ToList();;
        }

        public void ClearComment()
        
        { 
            comment.Clear();
            File.Delete(FileName);
        }
        
        private void SaveComment()
        {
            using (var fs = File.OpenWrite(FileName))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, comment);
            }
        }
        
        private void LoadComment()
        {
            if (File.Exists(FileName))
            {
                using (var fs = File.OpenRead(FileName))
                {
                    var bf = new BinaryFormatter();
                    comment = (List<Comment>)bf.Deserialize(fs);
                }
            }
        }
    }
}