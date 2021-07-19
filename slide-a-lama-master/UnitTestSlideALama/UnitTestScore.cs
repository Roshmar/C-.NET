using NUnit.Framework;
using SlideLama.Service;
using SlideLama.Entity;

namespace SlideLamaUnitTest 

{
    public class TestsScore
    {    
        private IScoreService IScoreServiceT()
        {
            var scoreService = new ScoreServiceFile();
            scoreService.ClearScores();
            return scoreService;
        }

        private void CheckOutput(string NameToCheck, string name, int ScoreToCheck, int score)
        {
            Assert.AreEqual(NameToCheck,name);
            Assert.AreEqual(ScoreToCheck,score);
            Assert.Pass();
        }

        [Test]
        public void Test1()
        {
            string nameOfPlayer = "Martin";
            int scorePlayer = 21;
            var scoreService = IScoreServiceT();
            scoreService.AddScore(new Score{Player = nameOfPlayer, Points = scorePlayer});

            var score = scoreService.GetTopScores();
            
            CheckOutput(score[0].Player,nameOfPlayer,score[0].Points,scorePlayer);
            
        }
        
        [Test]
        public void Test2()
        {
            string nameOfPlayer = "Martin";
            int scorePlayer = 54;
            var scoreService = IScoreServiceT();
            scoreService.AddScore(new Score{Player = nameOfPlayer, Points = scorePlayer});

            var score = scoreService.GetTopScores();
            
            CheckOutput(score[0].Player,nameOfPlayer,score[0].Points,scorePlayer);
            
        }
        
        [Test]
        public void Test3()
        {
            string nameOfPlayer = "gshjvccsvbnm.,mn";
            int scorePlayer = 45445335;
            var scoreService = IScoreServiceT();
            scoreService.AddScore(new Score{Player = nameOfPlayer, Points = scorePlayer});

            var score = scoreService.GetTopScores();
            
            CheckOutput(score[0].Player,nameOfPlayer,score[0].Points,scorePlayer);
            
        }
    }
}