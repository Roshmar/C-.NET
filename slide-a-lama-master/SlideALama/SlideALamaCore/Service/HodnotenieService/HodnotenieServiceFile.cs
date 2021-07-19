using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using SlideLama.Entity;

namespace SlideLama.Service
{
    [Serializable]
    public class HodnotenieServiceFile : IHodnotenieService
    {
        private const string FileName = "hodnotenie.bin";

        public void ClearHodnotenie()
        {
            _hodnotenies.Clear();
            File.Delete(FileName);
        }

        private List<Hodnotenie> _hodnotenies = new List<Hodnotenie>();
        
        public void AddHodnotenie(Hodnotenie hodnotenie)
        {

            hodnotenie.MiddleStarsCount = (hodnotenie.MiddleStarsCount+hodnotenie.StarsCount)/2;
            _hodnotenies.Add(hodnotenie);
            SaveHodnotenie();
        }

        public IList<Hodnotenie> GetHodnotenies()
        {
            LoadHodnotenie();

            return (from s in _hodnotenies
                    orderby s.StarsCount
                        descending
                    select s).ToList();

        }

        private void SaveHodnotenie()
        {
            using (var fs = File.OpenWrite(FileName))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, _hodnotenies);
            }
        }
        public int MiddleStars()
        {
            int value = 0;
            int s_count = 0;
            
            foreach (var count in _hodnotenies)
            {
                value +=  count.StarsCount;
                s_count ++ ;
            }

            if (s_count == 0)
            {
                return 0;
            }
            return value / s_count;
        }

        public void LoadHodnotenie()
        {
            if (File.Exists(FileName))
            {
                using (var fs = File.OpenRead(FileName))
                {
                    var bf = new BinaryFormatter();
                    _hodnotenies = (List<Hodnotenie>)bf.Deserialize(fs);
                }
            }
        }
    }
}