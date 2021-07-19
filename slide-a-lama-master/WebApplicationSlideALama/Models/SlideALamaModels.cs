using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SlideLama;
using SlideLama.Entity;

namespace WebApplicationSlideALama.Models
{
    public class SlideALamaModels
    {
        public string Message { get; set; }
        public string Opinion { get; set; }
        public GameMode gameMode { get; set; }

        public GameSource gameSource { get; set; }

        public Cell cell { get; set; }

        public IList<Hodnotenie> Hodnotenies { get; set; }

        public IList<Score> Scores{ get; set; }

        public IList<Comment> Comments { get; set; }
    }
}
