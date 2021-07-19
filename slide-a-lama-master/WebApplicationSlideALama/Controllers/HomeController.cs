using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SlideLama;
using SlideLama.Entity;
using SlideLama.Service;
using WebApplicationSlideALama.Controllers;
using WebApplicationSlideALama.Models;

namespace WebApplicationSlideALama.ApiControllers
{
    public class HomeController : Controller
    {

        private readonly CommentController commentControlle = new CommentController();
        private readonly HodnoterieController hodnoterieController = new HodnoterieController();
        private readonly IScoreService _scoreService = new SlideLama.SlideALamaCore.Service.ScoreService.ScoreServiceEF();
        private readonly ICommentService _commentService = new SlideLama.SlideALamaCore.Service.CommentService.CommentServiceEF();
        private readonly IHodnotenieService _hodnotenieService = new SlideLama.SlideALamaCore.Service.HodnotenieService.HodnotenieServiceEF();

        public GameMode gameMode = new GameMode();
        public GameSource gameSource = new GameSource();
        

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
       
       
       
       

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Score()
        {
            SlideALamaModels model = prepareScore();
            return View(model);
        }
        public IActionResult Comment()
        {
            SlideALamaModels model = prepareComment();
            return View(model);
        }
      
        public IActionResult LeaveComment( string name,string country,string age,int reviewStars, string comment)
        {
            commentControlle.Post(new Comment { PlayerName = name, PlayerAge = age, PlayerCountry = country, PlayerComment = comment });
            hodnoterieController.Post(new Hodnotenie { PlayerName = name, StarsCount = reviewStars });
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private SlideALamaModels prepareScore()
        {
            return new SlideALamaModels
            {
                Scores = _scoreService.GetTopScores()
            };
        }
        private SlideALamaModels prepareComment()
        {
            return new SlideALamaModels
            {
                Comments = _commentService.GetComment()
            };
        }




        public IActionResult ChooseGameMode()
        {
            var gameSource = new GameSource();
            HttpContext.Session.SetObject("gameSource", gameSource); 
            return View();
        }

        public IActionResult Index()
        {
           
            var gameMode = new GameMode();
            if (!gameMode.Get_isGameCreate())
            {
                gameMode.Set_nameOfFirstPlayer("Player1");
                gameMode.Set_firstplayerColor("red");
                gameMode.Set_nameOfSecondPlayer("Player2");
                gameMode.Set_secondplayerColor("blue");
                gameMode.Set_IconFirstPlayer("url('../img/PlayerIcon.png')");
                gameMode.Set_IconSecondPlayer("url('../img/PlayerIcon.png')");
                gameMode.Set_isGameCreate(true);
                HttpContext.Session.SetObject("gameMode", gameMode);
            }
           
            return View();
        }
       
        

        public IActionResult Setting(string inputNameFirstPlayer, string inputNameSecondPlayer,string ColorFirstPlayer, string ColorSecondPlayer,string IconFirstPlayer,string IconSecondPlayer)
        {
            
            var model = InitializeModel("update map");
            if (inputNameFirstPlayer != null) {
                model.gameMode.Set_nameOfFirstPlayer(inputNameFirstPlayer); 
            }
            if (inputNameSecondPlayer != null)
            {
                model.gameMode.Set_nameOfSecondPlayer(inputNameSecondPlayer);
            }
            if (ColorFirstPlayer != null) {
                model.gameMode.Set_firstplayerColor(ColorFirstPlayer);
            }
            if (ColorSecondPlayer != null)
            {
                model.gameMode.Set_secondplayerColor(ColorSecondPlayer);
            }
            if (IconFirstPlayer != null)
            {
                model.gameMode.Set_IconFirstPlayer(IconFirstPlayer);
            }
            if (IconSecondPlayer != null)
            {
                model.gameMode.Set_IconSecondPlayer(IconSecondPlayer);
            }

            
            PushModel(model);
            return View("Setting",model);
        }

        private SlideALamaModels InitializeModel(string message)
        {
            return new SlideALamaModels
            {
                gameSource = (GameSource)HttpContext.Session.GetObject("gameSource"),
                gameMode = (GameMode)HttpContext.Session.GetObject("gameMode"),
                Message = message
               
            };
        }
        public IActionResult MainGame()
        {

            var model = InitializeModel("update map");
            model.gameSource.GetRandomMap();
            model.gameSource.Set_playerNumb1(gameSource.Get_randomNumber(1, 8));
            model.gameSource.Set_playerNumb2(gameSource.Get_randomNumber(1, 8));
            model.gameSource.Set_player(1);
            model.gameMode.Set_NowPlayerColor1(model.gameMode.Get_firstplayerColor());
            model.gameMode.Set_NowPlayerColor2(model.gameMode.Get_secondplayerColor());
            PushModel(model);
            return View(model);
        }

        public IActionResult UpdateMove(int direction, int rowOrColumn)
        {

            var model = InitializeModel("update map");
            if (model.gameSource.Get_pLayerMode() == 2)
            {
                model.gameSource.Set_playerNumb(model.gameSource.Get_playerNumb1());
                model.gameSource.Set_playerNumb1(model.gameSource.Get_playerNumb2());
                model.gameSource.Set_playerNumb2(model.gameSource.Get_randomNumber(1, 8));
                model.gameSource.Set_direction(direction);
                model.gameSource.Set_rowOrCol(rowOrColumn - 1);
                model.gameSource.AddNumbToMap();
                model.gameSource.CheckSameNumbers();
                if (model.gameSource.Get_player() == 1)
                {
                    model.gameMode.Set_score_of_first_player(model.gameSource.GetScore());
                    model.gameSource.SetScore(0);
                    model.gameSource.Set_player(2);
                    model.gameMode.Set_NowPlayerColor1(model.gameMode.Get_secondplayerColor());
                    model.gameMode.Set_NowPlayerColor2(model.gameMode.Get_firstplayerColor());
                }
                else
                {
                    model.gameMode.Set_score_of_second_player(model.gameSource.GetScore());
                    model.gameSource.SetScore(0);
                    model.gameSource.Set_player(1);
                    model.gameMode.Set_NowPlayerColor1(model.gameMode.Get_firstplayerColor());
                    model.gameMode.Set_NowPlayerColor2(model.gameMode.Get_secondplayerColor());
                }

                if (((model.gameMode.Get_score_of_first_player() - model.gameMode.Get_score_of_second_player()) > 400) || ((model.gameMode.Get_score_of_second_player() - model.gameMode.Get_score_of_first_player()) > 400))
                {
                    model.gameMode._scoreService.AddScore(new Score { Player = model.gameMode.Get_nameOfFirstPlayer(), Points = model.gameMode.Get_score_of_first_player() });
                    model.gameMode._scoreService.AddScore(new Score { Player = model.gameMode.Get_nameOfSecondPlayer(), Points = model.gameMode.Get_score_of_second_player() });
                    model.gameMode.Set_score_of_first_player(0);
                    model.gameMode.Set_score_of_second_player(0);
                    PushModel(model);
                    return View("EndGame", model);
                }
                PushModel(model);
                return View("MainGame", model);
            }
            if (model.gameSource.Get_pLayerMode() == 1) {
                model.gameSource.Set_playerNumb(model.gameSource.Get_playerNumb1());
                model.gameSource.Set_playerNumb1(model.gameSource.Get_playerNumb2());
                model.gameSource.Set_playerNumb2(model.gameSource.Get_randomNumber(1, 8));
                model.gameSource.Set_direction(direction);
                model.gameSource.Set_rowOrCol(rowOrColumn - 1);
                model.gameSource.AddNumbToMap();
                model.gameSource.CheckSameNumbers();
               
                model.gameMode.Set_score_of_first_player(model.gameSource.GetScore());
                model.gameSource.SetScore(0);
                model.gameSource.Set_player(2);
                model.gameMode.Set_NowPlayerColor1(model.gameMode.Get_secondplayerColor());
                model.gameMode.Set_NowPlayerColor2(model.gameMode.Get_firstplayerColor());

                    if (((model.gameMode.Get_score_of_first_player() - model.gameMode.Get_score_of_second_player()) > 400) || ((model.gameMode.Get_score_of_second_player() - model.gameMode.Get_score_of_first_player()) > 400))
                    {
                        model.gameMode._scoreService.AddScore(new Score { Player = model.gameMode.Get_nameOfFirstPlayer(), Points = model.gameMode.Get_score_of_first_player() });
                        model.gameMode._scoreService.AddScore(new Score { Player = model.gameMode.Get_nameOfSecondPlayer(), Points = model.gameMode.Get_score_of_second_player() });
                       
                        PushModel(model);
                        return View("EndGame", model);
                    }
                PushModel(model);
                var model2 = InitializeModel("update map");
                model2.gameSource.Set_playerNumb(model2.gameSource.Get_playerNumb1());
                model2.gameSource.Set_playerNumb1(model2.gameSource.Get_playerNumb2());
                model2.gameSource.Set_playerNumb2(model2.gameSource.Get_randomNumber(1, 8));
                model2.gameSource.Set_direction(model2.gameSource.Get_randomNumber(1, 6));
                model2.gameSource.Set_rowOrCol(model2.gameSource.Get_randomNumber(1, 6) - 1);
                model2.gameSource.AddNumbToMap();
                model2.gameSource.CheckSameNumbers();

                model2.gameMode.Set_score_of_second_player(model2.gameSource.GetScore());
                model2.gameSource.SetScore(0);
                model2.gameSource.Set_player(1);
                    if (((model2.gameMode.Get_score_of_first_player() - model2.gameMode.Get_score_of_second_player()) > 400) || ((model2.gameMode.Get_score_of_second_player() - model2.gameMode.Get_score_of_first_player()) > 400))
                    {
                        model2.gameMode._scoreService.AddScore(new Score { Player = model2.gameMode.Get_nameOfFirstPlayer(), Points = model2.gameMode.Get_score_of_first_player() });
                        model2.gameMode._scoreService.AddScore(new Score { Player = model2.gameMode.Get_nameOfSecondPlayer(), Points = model2.gameMode.Get_score_of_second_player() });
                       
                        PushModel(model2);
                        return View("EndGame", model2);
                    }
                    PushModel(model2);
                return View("MainGame", model2); 
            }
          
           return View("MainGame",model);
        }

        public IActionResult SingleGame()
        {
            var model = InitializeModel("update map");
           
            model.gameSource.Set_playerMode(1);
            model.gameSource.GetRandomMap();
            model.gameSource.Set_playerNumb1(model.gameSource.Get_randomNumber(1, 8));
            model.gameSource.Set_playerNumb2(model.gameSource.Get_randomNumber(1, 8));
            model.gameSource.Set_player(1);
            model.gameMode.Set_NowPlayerColor1(model.gameMode.Get_firstplayerColor());
            model.gameMode.Set_NowPlayerColor2(model.gameMode.Get_secondplayerColor());
            model.gameMode.Set_score_of_first_player(0);
            model.gameMode.Set_score_of_second_player(0);
            model.gameMode.TheroScore();
            PushModel(model);
            return View("MainGame", model);
        }
        public IActionResult MultiGame()
        {
            var model = InitializeModel("update map");
            
            model.gameSource.Set_playerMode(2);
            model.gameSource.GetRandomMap();
            model.gameSource.Set_playerNumb1(model.gameSource.Get_randomNumber(1, 8));
            model.gameSource.Set_playerNumb2(model.gameSource.Get_randomNumber(1, 8));
            model.gameSource.Set_player(1);
            model.gameMode.Set_NowPlayerColor1(model.gameMode.Get_firstplayerColor());
            model.gameMode.Set_NowPlayerColor2(model.gameMode.Get_secondplayerColor());
            model.gameMode.TheroScore();
            PushModel(model);
            return View("MainGame", model);
        }

        private void PushModel(SlideALamaModels model)
        {
            HttpContext.Session.SetObject("gameSource", model.gameSource);
            HttpContext.Session.SetObject("gameMode", model.gameMode);
        }

     
    }
}
