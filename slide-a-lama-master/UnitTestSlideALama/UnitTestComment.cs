using NUnit.Framework;
using SlideLama.Service;
using SlideLama.Entity;

namespace SlideLamaUnitTest
{
    class UnitTestComment
    {
          
        private ICommentService IcommentService()
        {
            var commentService = new CommentServiceFile();
            commentService.ClearComment();
            return commentService;
        }
        private void CheckOutput(string playerToCheck, string ComentToCheck, string player, string comment,string AgeToCheck,string age, string CountryToCheck, string country)
        {
            Assert.AreEqual(playerToCheck, player);
            Assert.AreEqual(AgeToCheck, age);
            Assert.AreEqual(CountryToCheck,country);
            Assert.AreEqual(ComentToCheck, comment);
            Assert.Pass();
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string _name = "Martin";
            string _age = "18";
            string _country = "Slovakia";
            string _coment = "Nice game!!";
            var commentService = IcommentService();
            commentService.AddComment(new Comment{PlayerName = _name,PlayerAge = _age,PlayerCountry = _country,PlayerComment = _coment});
            var comment = commentService.GetComment();
            
            CheckOutput(comment[0].PlayerName,comment[0].PlayerComment,_name,_coment,comment[0].PlayerAge,_age,comment[0].PlayerCountry,_country);
           
        }

        [Test]
        public void Test2()
        {
            int i = 0;
            string _name = "Martin";
            string _age = "18";
            string _country = "Slovakia";
            string _coment = "Nice game!!";
            var commentService = IcommentService();
            commentService.AddComment(new Comment{PlayerName = _name,PlayerAge = _age,PlayerCountry = _country,PlayerComment = _coment});
            var comment = commentService.GetComment();
            CheckOutput(comment[i].PlayerName,comment[i].PlayerComment,_name,_coment,comment[i].PlayerAge,_age,comment[i].PlayerCountry,_country);
                
            i = 1;
             _name = "Alexjhgd hdg";
             _age = "234d554654 .gk dg";
             _country = "USAshghghghgghsb5b7n78m986mn5jbh4vgtcfrr3vb4nm6i7,om6n5b7uv6y5ctrv4bnm689,8m7n6b56vcrf";
             _coment = "GGsdaffafhj,jvmsbnj.kavm/m.jrhj dsjl s fjk4 74 4";
             commentService.AddComment(new Comment{PlayerName = _name,PlayerAge = _age,PlayerCountry = _country,PlayerComment = _coment});
             comment = commentService.GetComment();
             CheckOutput(comment[i].PlayerName,comment[i].PlayerComment,_name,_coment,comment[i].PlayerAge,_age,comment[i].PlayerCountry,_country);

        }
        
        [Test]
        public void Test3()
        {
            string _name = "";
            string _age = "";
            string _country = "";
            string _coment = "";
            var commentService = IcommentService();
            commentService.AddComment(new Comment{PlayerName = _name,PlayerAge = _age,PlayerCountry = _country,PlayerComment = _coment});
            var comment = commentService.GetComment();
            
            CheckOutput(comment[0].PlayerName,comment[0].PlayerComment,_name,_coment,comment[0].PlayerAge,_age,comment[0].PlayerCountry,_country);
           
        }

    }
}
