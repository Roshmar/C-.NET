using System;
using SlideLama.Entity;
using SlideLama.Service;


namespace SlideLama
{
    [Serializable]
    public class LeaveComment
    {    
        private readonly ICommentService _commentService = new SlideALamaCore.Service.CommentService.CommentServiceEF();
        private readonly IHodnotenieService _hodnotenieService = new SlideALamaCore.Service.HodnotenieService.HodnotenieServiceEF();
        
        private string name;
        private string age;
        private string country;
        private string comment;
        private int stars;
        public void LeaveComments()
        {
            
            Console.WriteLine("Please Enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("Please Enter your age: ");
            age = Console.ReadLine();
            Console.WriteLine("Please Enter your country: ");
            country = Console.ReadLine();
            Console.WriteLine("Please Enter your comment: ");
            comment = Console.ReadLine();
            _commentService.AddComment(new Comment{PlayerName = name,PlayerAge = age,PlayerCountry = country,PlayerComment = comment});
            
            Console.WriteLine("Please rate this game from 1 to 5: ");
            GetStarsCount();

            _hodnotenieService.AddHodnotenie(new Hodnotenie{PlayerName = name, StarsCount = stars});
        }
        public void PrintComment()
        {
            Console.WriteLine("Comments:");
            foreach (var comment in _commentService.GetComment())
            {
                Console.WriteLine("{0} {1}, {2}: \n {3}", comment.PlayerName, comment.PlayerAge.ToString(),comment.PlayerCountry,comment.PlayerComment);
            }
        }
        public void PrintHodnotenie()
        {
           
            Console.Write("Average game rating: " +  _hodnotenieService.MiddleStars().ToString());
            for (int i = 0; i < _hodnotenieService.MiddleStars(); i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            foreach (var hodnoteny in _hodnotenieService.GetHodnotenies())
            {
                Console.Write("{0} ",hodnoteny.PlayerName);
                for (int i = 0; i < hodnoteny.StarsCount; i++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            
        }

        private void GetStarsCount()
        {
            char[] inputGameMode = Console.ReadLine().ToCharArray();
           
            for (int i = 0; i < inputGameMode.Length; i++)
            {
                if (Char.IsDigit(inputGameMode[0]) && inputGameMode[0]-48<=5 && inputGameMode[0]-48>=0)
                {
                    stars = inputGameMode[0]-48;
                    break;
                }
                else
                { 
                    Console.WriteLine("Please enter correct number!");
                    GetStarsCount();
                }
            }
        }
    }
}