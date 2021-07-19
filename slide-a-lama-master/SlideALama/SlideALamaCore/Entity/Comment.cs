using System;

namespace SlideLama.Entity
{
    [Serializable]
    public class Comment
    {
        public int Id { get; set; }
        public string PlayerCountry { get; set; }

        public string PlayerName { get; set; }

        public string PlayerComment { get; set; }

        public string PlayerAge { get; set; } 
        
    }
}