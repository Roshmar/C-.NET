using System;
using System.Collections.Generic;
using SlideLama.Entity;

namespace SlideLama.Service
{
    
    public interface IHodnotenieService
    {
        void AddHodnotenie(Hodnotenie hodnotenie);
        int MiddleStars();

        IList<Hodnotenie> GetHodnotenies();
    }
}