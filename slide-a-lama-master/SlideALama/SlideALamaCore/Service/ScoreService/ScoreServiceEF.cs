using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using SlideLama.Service;
using SlideLama.Entity;

namespace SlideLama.SlideALamaCore.Service.ScoreService
{
    [Serializable]
    public class ScoreServiceEF : IScoreService
    {
        public void AddScore(Score score)
        {
            using (var context = new SlideLamaDbContext())
            {
                context.Scores.Add(score);
                context.SaveChanges();
            }
        }

        [Obsolete]
        public void ClearScores()
        {
            using (var context = new SlideLamaDbContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Score");
            }
        }

        public IList<Score> GetTopScores()
        {
            using (var context = new SlideLamaDbContext())
            {
                return (from s in context.Scores
                        orderby s.Points
                            descending
                        select s).Take(5).ToList();
            }
        }
    }
}
