using System;
using System.Collections.Generic;
using SlideLama.Entity;

namespace SlideLama.Service
{
    
    public interface IScoreService
    {
        void AddScore(Score score);

        IList<Score> GetTopScores();

        void ClearScores();
    }
}
