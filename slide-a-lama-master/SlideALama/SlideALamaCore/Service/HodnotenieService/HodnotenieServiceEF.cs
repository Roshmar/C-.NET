using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SlideLama.Entity;
using SlideLama.Service;

namespace SlideLama.SlideALamaCore.Service.HodnotenieService
{
    [Serializable]
    public class HodnotenieServiceEF : IHodnotenieService
    {
        public void AddHodnotenie(Hodnotenie hodnotenie)
        {
            using (var context = new SlideLamaDbContext())
            {
                hodnotenie.MiddleStarsCount = (hodnotenie.MiddleStarsCount + hodnotenie.StarsCount) / 2;
                context.Hodnotenies.Add(hodnotenie);
                context.SaveChanges();
            }
        }

        public IList<Hodnotenie> GetHodnotenies()
        {
            using (var context = new SlideLamaDbContext())
            {
                return (from s in context.Hodnotenies
                        orderby s.StarsCount
                        descending
                        select s).ToList();
            }
        }

        public int MiddleStars()
        {
            using (var context = new SlideLamaDbContext()) 
            { 
                int value = 0;
                int s_count = 0;

            foreach (var count in context.Hodnotenies)
            {
                value += count.StarsCount;
                s_count++;
            }

            if (s_count == 0)
            {
                return 0;
            }
            return value / s_count;
            }
        }
    }
}
