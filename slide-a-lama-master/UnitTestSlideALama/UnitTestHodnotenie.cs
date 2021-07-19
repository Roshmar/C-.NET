using NUnit.Framework;
using SlideLama.Service;
using SlideLama.Entity;


namespace lideLamaUnitTest
{
    
   public class UnitTestHodnotenie
    {    
        private IHodnotenieService IHodnotenieServiceT()
        {
            var hodnotenieService = new HodnotenieServiceFile();
            hodnotenieService.ClearHodnotenie();
            return hodnotenieService;
        }
        
        private void CheckOutput(string NameToCheck, string name, int ScoreToCheck, int score,int StarsCount)
        {
            Assert.AreEqual(NameToCheck,name);
            Assert.AreEqual(ScoreToCheck,score);
            Assert.Pass();
        }
        
        [Test]
        public void Test1()
        {
            string name = "Martin";
            int stars = 6;
            var scoreService = IHodnotenieServiceT();
            scoreService.AddHodnotenie(new Hodnotenie{PlayerName = name, StarsCount = stars});

            var hodnotenies = scoreService.GetHodnotenies();
            
            CheckOutput(hodnotenies[0].PlayerName,name,hodnotenies[0].StarsCount,stars,hodnotenies[0].MiddleStarsCount);
        }
        
        [Test]
        public void Test2()
        {
            string name = "Alex";
            int stars = 4;
            var scoreService = IHodnotenieServiceT();
            scoreService.AddHodnotenie(new Hodnotenie{PlayerName = name, StarsCount = stars});

            var hodnotenies = scoreService.GetHodnotenies();
            
            CheckOutput(hodnotenies[0].PlayerName,name,hodnotenies[0].StarsCount,stars,hodnotenies[0].MiddleStarsCount);

            name = "Martin";
            stars = 5;
            scoreService.AddHodnotenie(new Hodnotenie{PlayerName = name, StarsCount = stars});
             hodnotenies = scoreService.GetHodnotenies();
             CheckOutput(hodnotenies[1].PlayerName,name,hodnotenies[1].StarsCount,stars,hodnotenies[1].MiddleStarsCount);

        }
        
        [Test]
        public void Test3()
        {
            string name = "";
            int stars = 0;
            var scoreService = IHodnotenieServiceT();
            scoreService.AddHodnotenie(new Hodnotenie{PlayerName = name, StarsCount = stars});

            var hodnotenies = scoreService.GetHodnotenies();
            
            CheckOutput(hodnotenies[0].PlayerName,name,hodnotenies[0].StarsCount,stars,hodnotenies[0].MiddleStarsCount);
        }
    }
}