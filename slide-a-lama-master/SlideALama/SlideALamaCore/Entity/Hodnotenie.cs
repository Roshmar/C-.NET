using System;

namespace SlideLama.Entity
{
    [Serializable]
    public class Hodnotenie
    {
        public int Id { get; set; }
        public int StarsCount { get; set; }
        
        public int MiddleStarsCount { get; set; }
        
        public string PlayerName { get; set; }
    }
}