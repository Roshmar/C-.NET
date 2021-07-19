using System;


namespace SlideLama
{
    [Serializable]
    public class MenuInGame
    {
        GameMode gameMode = new GameMode();
        LeaveComment _leaveComment = new LeaveComment();
        private int value;
        
        public void Run()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("If you want to:");
            Console.WriteLine("1)Start Game ");
            Console.WriteLine("2)leave comment ");
            Console.WriteLine("3)Show comment ");
            Console.WriteLine("4)Show Score");
            Console.WriteLine("5)Show Hodnotenie");
            Console.WriteLine("6)Exit ");
            Console.WriteLine("--------------------------------------------------------------");
            char[] inputGameMode = Console.ReadLine().ToCharArray();
           
            for (int i = 0; i < inputGameMode.Length; i++)
            {
                if (Char.IsDigit(inputGameMode[i]))
                {
                    value = inputGameMode[i]-48;
                    break;
                }
                else
                {
                    value = -1;
                }
            }
            switch (value)
            {
                case 1 :
                        
                        gameMode.ChooseGameMode();
                    if (gameMode.Get_game_mode() == 0)
                        {
                            gameMode.StartSingleGame();
                        }
                        else
                        {
                            gameMode.StartMultiGame();
                        }
                        break;
                case 2 :
                        _leaveComment.LeaveComments();
                        break;
                case 3 :
                    _leaveComment.PrintComment();
                        break;
                case 4 :
                        gameMode.PrintScores();
                        Run();
                    break;
                case 5 :
                        _leaveComment.PrintHodnotenie();
                    break;
                case 6 :
                    break;
            }

            if (value != 6)
            {
                if (value > 6 || value < 0 )
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; 
                    Console.WriteLine("Enter correct number!");
                    Console.ResetColor();
                }
                Run();
            }
        }
    }
}