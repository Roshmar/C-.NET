using System;
using System.Runtime.CompilerServices;
using SlideLama.Entity;
using SlideLama.Service;


namespace SlideLama
{
    [Serializable]
    public class GameMode
    {
        
        public readonly IScoreService _scoreService = new SlideALamaCore.Service.ScoreService.ScoreServiceEF();
       
        //private readonly IRa
        
        private GameSource _gameSource = new GameSource();
        private int _mode = -1;
        private int _winScore = 100;
        private int _scoreFirstPlayer = 0;
        private int _scoreSecondPlayer = 0;
        private string nameOfFirstPlayer,nameOfSecondPlayer;
        private bool isGameCreate = false;
        public bool _endGame = false;
        private string _player;
        private string _restart ;
        private string _firstPlayerColor;
        private string _SecontPlayerColor;
        private string _NowPlayerColor1;
        private string _NowPlayerColor2;
        private string _IconFirstPlayer;
        private string _IconSecondPlayer;

        public void TheroScore() {
            this._scoreFirstPlayer = 0;
            this._scoreSecondPlayer = 0;
        }
        public string Get_IconFirstPlayer()
        {
            return _IconFirstPlayer;
        }
        public void Set_IconFirstPlayer(string isGameCreate)
        {
            this._IconFirstPlayer = isGameCreate;
        }
        public string Get_IconSecondPlayer()
        {
            return _IconSecondPlayer;
        }
        public void Set_IconSecondPlayer(string isGameCreate)
        {
            this._IconSecondPlayer = isGameCreate;
        }

        public string Get_NowPlayerColor1()
        {
            return _NowPlayerColor1;
        }
        public void Set_NowPlayerColor1(string isGameCreate)
        {
            this._NowPlayerColor1 = isGameCreate;
        }
        public string Get_NowPlayerColor2()
        {
            return _NowPlayerColor2;
        }
        public void Set_NowPlayerColor2(string isGameCreate)
        {
            this._NowPlayerColor2 = isGameCreate;
        }

        public bool Get_isGameCreate() {
            return isGameCreate;
        }
        public void Set_isGameCreate(bool isGameCreate) {
            this.isGameCreate = isGameCreate;
        }
        public void Set_firstplayerColor(string color) {
            this._firstPlayerColor = color;
        }
        public string Get_firstplayerColor() {
            return _firstPlayerColor;
        }
        public void Set_secondplayerColor(string color)
        {
            this._SecontPlayerColor = color;
        }
        public string Get_secondplayerColor()
        {
            return _SecontPlayerColor;
        }
        public void Set_nameOfFirstPlayer(string name)
        {
            this.nameOfFirstPlayer = name;
        }
        
        public string Get_nameOfFirstPlayer()
        {
            return nameOfFirstPlayer;
        }

        public void Set_nameOfSecondPlayer(string name)
        {
            this.nameOfSecondPlayer = name;
        }
        
        public string Get_nameOfSecondPlayer()
        {
            return nameOfSecondPlayer;
        }
        
        
        public GameMode() 
        {
        }

        public void Set_game_mode(int mode)
        {
            this._mode = mode;
        }
        
        public int Get_game_mode()
        {                                  
            return _mode;              
        }                                  

        public void Set_score_of_first_player(int scoreFirstPlayer)
        {
            this._scoreFirstPlayer += scoreFirstPlayer;
        }
        
        public int Get_score_of_first_player()
        {                                  
            return _scoreFirstPlayer;              
        }                                  

        public void Set_score_of_second_player(int scoreSecondPlayer)
        {
            this._scoreSecondPlayer += scoreSecondPlayer;
        }
        
        public int Get_score_of_second_player()
        {                                     
            return _scoreSecondPlayer;     
        }
        
        public bool CheckEndGame()
        {
            if (Get_score_of_first_player()> _winScore)
            {
                _endGame = true;
                _player = Get_nameOfFirstPlayer();
            }
            if (Get_score_of_second_player() > _winScore)
            {
                _endGame = true;
                _player = Get_nameOfSecondPlayer();
            }
            if (_endGame)
            {    
                _gameSource.Show_map();
                WriteScore();
                _scoreService.AddScore(new Score{Player = nameOfFirstPlayer, Points = _scoreFirstPlayer});
                _scoreService.AddScore(new Score{Player = nameOfSecondPlayer, Points = _scoreSecondPlayer});
                
                Console.WriteLine("-+-+-+-+-+-+-+-+- " +_player+" Win !!! -+-+-+-+-+-+-+-+-");
                PrintScores();
                Console.Write("If you want restart game write yes/no : ");
                _restart = Console.ReadLine();
                if (_restart.Equals("yes", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (ChooseGameMode() == 0)
                    {
                        StartSingleGame();
                    }
                    else
                    {
                        StartMultiGame();
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        //Write Score
        public void WriteScore()
        {    
           
            Console.Write("   | ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(Get_score_of_first_player().ToString());
            Console.ResetColor();
            Console.Write(" | ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(Get_score_of_second_player().ToString());
            Console.ResetColor();
            Console.Write(" |\n");
            
            
        }
        //Choose Game mode single or multi player
        public int ChooseGameMode()
        {
            Set_game_mode(-1);
            _restart = " ";
            _player = " ";
            _endGame = false;
            _scoreFirstPlayer = 0;
            _scoreSecondPlayer = 0;
            nameOfFirstPlayer = " ";
            nameOfSecondPlayer = " ";
            
            Console.Write("Choose single or multi player mode (0 or 1):" + "\n");
            char[] inputGameMode = Console.ReadLine().ToCharArray();
           
            for (int i = 0; i < inputGameMode.Length; i++)
            {
                if (Char.IsDigit(inputGameMode[i]))
                {
                    Set_game_mode(inputGameMode[i]-48);
                    break;
                }
            }
            if (Get_game_mode() == 0)
            {    
                Console.Write("Enter your name: ");
                Set_nameOfFirstPlayer(Console.ReadLine());
                Set_nameOfSecondPlayer("Bot");
                _gameSource.GetRandomMap();
                return 0;
            }
            if (Get_game_mode() == 1)
            {    
                Console.Write("Enter the name of first player: ");
                Set_nameOfFirstPlayer( Console.ReadLine());
                Console.Write("Enter the name of second player: ");
                Set_nameOfSecondPlayer( Console.ReadLine());
                _gameSource.GetRandomMap();
                return 1;
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.WriteLine("Choose mode, enter correct number please..."); 
            Console.ResetColor(); 
            ChooseGameMode();
            return -1;
        }
        
        public void StartSingleGame()
        {
            _gameSource.Show_map();
            _gameSource.Set_playerNumb(_gameSource.Get_randomNumber(1,8));
            WriteScore();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(Get_nameOfFirstPlayer());
            Console.ResetColor();
            Console.WriteLine(" your turn. " + "The number is " + _gameSource.Get_playerNumb().ToString());
            _gameSource.Set_playerTurn();
            _gameSource.AddNumbToMap();
            _gameSource.CheckSameNumbers();
            Set_score_of_first_player(_gameSource.GetScore());
            _gameSource.SetScore(0);
            
                
            //Bot Turn
            if (CheckEndGame() != true && _endGame != true)
            {
                _gameSource.Show_map();
                _gameSource.Set_playerNumb(_gameSource.Get_randomNumber(1,8));
                WriteScore(); 
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(Get_nameOfSecondPlayer());
                Console.ResetColor();
                Console.WriteLine(" your turn. " + "The number is " + _gameSource.Get_playerNumb().ToString()); 
                _gameSource.Set_direction(_gameSource.Get_randomNumber(1,3));
                _gameSource.Set_rowOrCol(_gameSource.Get_randomNumber(0,4));
                _gameSource.AddNumbToMap();
                _gameSource.CheckSameNumbers();
                Set_score_of_second_player(_gameSource.GetScore());
                _gameSource.SetScore(0);
                if (CheckEndGame() != true && _endGame != true)
                {
                    StartSingleGame();
                }
            }
        }
        
        public void StartMultiGame()
        {    
            _gameSource.Show_map();
            _gameSource.Set_playerNumb(_gameSource.Get_randomNumber(1,8));
            WriteScore();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(Get_nameOfFirstPlayer());
            Console.ResetColor();
            Console.WriteLine(" your turn. " + "The number is " + _gameSource.Get_playerNumb().ToString());
            _gameSource.Set_playerTurn();
            _gameSource.AddNumbToMap();
            _gameSource.CheckSameNumbers();
            Set_score_of_first_player(_gameSource.GetScore());
            _gameSource.SetScore(0);
            //Second Player Turn
            
            if (CheckEndGame() != true && _endGame != true)
            {
                _gameSource.Show_map();
                _gameSource.Set_playerNumb(_gameSource.Get_randomNumber(1,8));
                WriteScore();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(Get_nameOfSecondPlayer());
                Console.ResetColor();
                
                Console.WriteLine(" your turn. " + "The number is " + _gameSource.Get_playerNumb().ToString());
                _gameSource.Set_playerTurn();
                _gameSource.AddNumbToMap();
                _gameSource.CheckSameNumbers();
                Set_score_of_second_player(_gameSource.GetScore());
                _gameSource.SetScore(0);
                if (CheckEndGame() != true && _endGame != true)
                {
                    StartMultiGame();
                }
            }
        }
        public void PrintScores()
        {
            Console.WriteLine("Top scores:");
            foreach (var score in _scoreService.GetTopScores())
            {
                Console.WriteLine("{0} {1}", score.Player, score.Points);
            }
        }

        public void StartMultiPlayerGameWeb()
        {
            // _gameSource.Set_playerNumb2(_gameSource.Get_randomNumber(1, 8)); перед початком гри 1 раз

           
            _gameSource.Set_playerNumb1(_gameSource.Get_playerNumb2());
            _gameSource.Set_playerNumb2(_gameSource.Get_randomNumber(1, 8));
            _gameSource.Set_playerTurn(); //установка координат для нової плитки
            _gameSource.AddNumbToMap();
            _gameSource.CheckSameNumbers();
            Set_score_of_first_player(_gameSource.GetScore());
            _gameSource.SetScore(0);

            if (CheckEndGame() != true && _endGame != true)
            {
               
                _gameSource.Set_playerNumb1(_gameSource.Get_playerNumb2());
                _gameSource.Set_playerNumb2(_gameSource.Get_randomNumber(1, 8));
                _gameSource.Set_playerTurn();
                _gameSource.AddNumbToMap();
                _gameSource.CheckSameNumbers();
                Set_score_of_second_player(_gameSource.GetScore());
                _gameSource.SetScore(0);
                if (CheckEndGame() != true && _endGame != true)
                {
                    StartMultiPlayerGameWeb();
                }
            }
        }
    }
}
