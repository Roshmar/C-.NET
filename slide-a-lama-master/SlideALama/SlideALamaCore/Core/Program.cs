using System;


namespace SlideLama
{
    [Serializable]
    class Program
    {
        static void Main(string[] args)
        {
         MenuInGame menuInGame = new MenuInGame();
         Console.WriteLine("Hello , welcome to the Slide a lama game!!!");
         menuInGame.Run();
        }
    }
}