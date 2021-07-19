using System;



namespace SlideLama
{
    [Serializable]
    public class GameSource
    {
       
       
        private int _playerNumb;
        private int _playerNumb1;
        private int _playerNumb2;
        private int _player;
        private int _direction = 0;
        private int _rowOrColumn = 0;
        private const int Row = 5;         //Rows count
        private const int Col = 5;        //Column count
        private int _score = 0;
        public Cell [,]map = new Cell[Row,Col];
        private int playerMode;

        public int Get_pLayerMode() {
            return playerMode;
        }
        public void Set_playerMode(int playerMode) {
            this.playerMode = playerMode;
        }
        public int Get_player() {
            return _player;
        }
        public void Set_player(int player) {
            this._player = player;
        }
        //Generate random number from min to max-1 
        public int Get_randomNumber(int min , int max)
        {
            Random random = new Random();
           return random.Next(min, max);
            
        }

        public void Set_playerNumb(int PlayerNumb)  
        {                                                     
            this._playerNumb = PlayerNumb;          
        }                                                     
                                                      
        public int Get_playerNumb()                      
        {                                                     
            return _playerNumb;                          
        }
        public void Set_playerNumb1(int Numb)
        {
            this._playerNumb1 = Numb;
        }

        public int Get_playerNumb1()
        {
            return _playerNumb1;
        }
        public void Set_playerNumb2(int Numb)
        {
            this._playerNumb2 = Numb;
        }

        public int Get_playerNumb2()
        {
            return _playerNumb2;
        }


        public int Get_rowOrColumn()
        {
            return _rowOrColumn;
        }

        public void Set_direction(int direction)
        {
            this._direction = direction;
        }

        public void Set_rowOrCol(int number)
        {
            this._rowOrColumn = number;
        }
      
        //Take direction (Left ,Top , Right) and number of column or row
        public void Set_playerTurn()
        {
            //string direction;
            //string rowOrColumn;
            int state = 1;
            char direction = '0';
            char rowOrColumn = '0';
            char[] input;
            string  inputLine  = Console.ReadLine();
            
            input = inputLine.ToCharArray();

            for (int i = 0; i <input.Length; i++)
            {   
                if (Char.IsDigit(input[i])&& input.Length-(i+3) >= 0)
                {
                    direction = input[i];
                    rowOrColumn = input[i + 2];
                    break;
                }
            }

            
            //Console.WriteLine( Convert.ToString(direction) + Convert.ToString(rowOrColumn)); 
            if (Char.IsDigit(direction) && Char.IsDigit(rowOrColumn) && ((direction - 48 <= 3 && direction - 48 > 0) && (rowOrColumn - 49 >= 0 && rowOrColumn - 49 <= 4)))
            { 
                this._direction = (direction-48); 
                this._rowOrColumn = (rowOrColumn-49); 
                state = 0;
            }else
            { 
                Console.ForegroundColor = ConsoleColor.Yellow; 
                Console.WriteLine("Enter correct number please!");
                Console.ResetColor();
            }

            if (state != 0)
            {
                Set_playerTurn();
            }
        }
        
        //Generates gaming map
        public void GetRandomMap()
        {
            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    map[i, j] = new Cell(i,j,Get_randomNumber(1,8));
                }
            }
        }
        
        //Add player number to gaming map
        public void AddNumbToMap()
        {
            switch (_direction)
                {
                    case 1:
                        int []array1 = new int[5];
                        int value1 = 1;
                        for (int i = 0, j=1; i < Row-1; i++,j++)
                        {
                            if (map[Get_rowOrColumn(), i].Get_value()==8)
                            {
                                break;
                            }
                            array1[j] = map[Get_rowOrColumn(), i].Get_value();
                            value1++;
                        }
                        for (int i = 0; i <value1; i++)
                        {
                            map[Get_rowOrColumn(), i].Set_value(array1[i]);
                        }
                        map[Get_rowOrColumn(), 0].Set_value(Get_playerNumb());
                        UpdateMap();
                        break;
                    case 2:
                        int []array2 = new int[5];
                        int value2 = 1;
                        for (int i = 0, j=1; i < Col-1; i++,j++)
                        {
                            if (map[i,Get_rowOrColumn()].Get_value()==8)
                            {
                                break;
                            }
                            array2[j] = map[i,Get_rowOrColumn()].Get_value();
                            value2++;
                        }
                        for (int i = 0; i <value2; i++)
                        {
                            map[i,Get_rowOrColumn()].Set_value(array2[i]);
                        }
                        map[0,Get_rowOrColumn()].Set_value(Get_playerNumb());
                        UpdateMap();
                        break;
                    case 3:
                        int []array3 = new int[5];
                        int value3 = Row-1;
                        for (int i = Row-1, j=Row-2; i > 0; i--,j--)
                        {
                            if (map[Get_rowOrColumn(), i].Get_value()==8)
                            {
                                break;
                            }
                            array3[j] = map[Get_rowOrColumn(), i].Get_value();
                            value3--;
                        }
                        for (int i = value3; i < Row-1; i++)
                        {
                            map[Get_rowOrColumn(), i].Set_value(array3[i]);
                        }
                        map[Get_rowOrColumn(), 4].Set_value(Get_playerNumb());
                        UpdateMap();
                        break;
                    default:
                        Set_playerTurn();
                        AddNumbToMap();
                        break;
                }
        }

        //Get bonus score of player
          public void GetBonusScore(int numb,int bonus)
          {    
             
              int helpScore = 0;
              switch (numb)
              {
                  case 1: helpScore = 10;
                      break;
                  case 2: helpScore = 20;
                      break;
                  case 3: helpScore = 30;
                      break;
                  case 4: helpScore = 40;
                      break;
                  case 5: helpScore = 70;
                      break;
                  case 6: helpScore = 100;
                      break;
                  case 7: helpScore = 150;
                      break;
                  default: 
                      break;
              }
  
              switch (bonus)
              {
                  case 4: this._score += helpScore * 2;
                      break;
                  case 5: this._score += helpScore * 3;
                      break;
                  default: this._score += helpScore;
                      break;
              }

              // Console.ForegroundColor = ConsoleColor.DarkRed;
              // Console.WriteLine(_score.ToString());
              // Console.ResetColor();
          }
          
          public int GetScore()
          {
              return _score;
          }

          public void SetScore(int score)
          {
              this._score = score;
          }

          //Delete Row on map
          public void DeleteRow(int bonus,Cell cell)
          {
              for (int i = 0; i < bonus; i++)
              {
                 map[cell.Get_positionColumn(),cell.Get_positionRow()+i].Set_value(8);
              }
          }

          public void DeleteColumn(int bonus,Cell cell)
          {
              for (int i = 0; i < bonus; i++)
              {
                  map[cell.Get_positionColumn()+i,cell.Get_positionRow()].Set_value(8);
              }
          }

          public void CheckSameNumbers()
          {
              int sameNumbCount = 1;
              int streekCount = 0;
              int value = 9;
              Cell streekNumb = map[0,0];

              for (int i = 0; i < Col; i++)
              {
                  for (int j = 0; j < Row; j++)
                  {
                      if (value == map[i,j].Get_value() && map[i,j].Get_value() != 8 )
                      {
                          sameNumbCount++;
                          if (sameNumbCount >= 3)
                          {
                              streekNumb = map[i, j - sameNumbCount + 1];
                              streekCount = sameNumbCount;
                          }
                      }
                      else
                      {
                          sameNumbCount = 1;
                      }
                      value = map[i, j].Get_value();
                  }
                  if ( streekCount >= 3)
                  {
                      GetBonusScore(streekNumb.Get_value(),streekCount);
                      DeleteRow(streekCount,streekNumb);
                      UpdateMap();
                  }
                  streekCount = 0;
                  sameNumbCount = 1;
                  value = 9;
              }
              for (int i = 0; i < Row; i++)
              {
                  for (int j = 0; j < Col; j++)
                  {
                      if (value == map[j,i].Get_value() && map[j,i].Get_value()!= 8 )
                      {
                          sameNumbCount++;
                          if (sameNumbCount >= 3)
                          {
                              streekNumb = map[j- sameNumbCount + 1, i];
                              streekCount = sameNumbCount;
                          }
                      }
                      else
                      {
                          sameNumbCount = 1;
                      }
                      value = map[j, i].Get_value();
                  }
                  if ( streekCount >= 3)
                  {
                      GetBonusScore(streekNumb.Get_value(),streekCount);
                      DeleteColumn(streekCount,streekNumb);
                      UpdateMap();
                  }
                  streekCount = 0;
                  sameNumbCount = 1;
                  value = 9;
              }
          }

          public void UpdateMap()
          {
              for (int i = 0; i < Row; i++)
              {
                  for (int j = Col-1; j > 0 ; j--)
                  {
                      if (map[j,i].Get_value() == 8)
                      {
                          for (int k = j; k >= 0; k--)
                          {
                              if (map[k,i].Get_value() != 8)
                              {
                                  map[j,i].Set_value(map[k,i].Get_value());
                                  map[k,i].Set_value(8);
                                  break;
                              }
                          }
                      }
                  }
              }
          }
          
          
        
        //Write gaming map
        public void Show_map()
        {
            Console.WriteLine(" +-----------+");
            for (int i = 0; i < Col; i++)
            {
                Console.Write(i+1 + "| ");
                for (int j = 0; j < Row; j++)
                {
                    if (map[i,j].Get_value() >= 8)
                    {
                        Console.Write(" " + " ");
                    }
                    else
                    {
                        switch (map[i,j].Get_value())
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(map[i,j].Get_value().ToString() + " ");
                                
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(map[i,j].Get_value().ToString() + " ");
                                Console.ResetColor();
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(map[i,j].Get_value().ToString() + " ");
                                Console.ResetColor();
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write(map[i,j].Get_value().ToString() + " ");
                                Console.ResetColor();
                                break;
                            case 5:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(map[i,j].Get_value().ToString() + " ");
                                Console.ResetColor();
                                break;
                            case 6:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(map[i,j].Get_value().ToString() + " ");
                                Console.ResetColor();
                                break;
                            case 7:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(map[i,j].Get_value().ToString() + " ");
                                Console.ResetColor();
                                break;
                        }
                    }
                }
                Console.Write("|" + (i+1));
                Console.Write('\n');  
            }
            Console.WriteLine("-+-----------+-");
        }
    }
}