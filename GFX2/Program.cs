using System;
using Raylib_cs;

namespace GFX2
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {

int x = 0;
            while (true)
            {
                Console.Clear();
                System.Console.WriteLine(@" 
 ______ _                ______                  
(_____ (_)              (_____ \                 
 _____) ) ____   ____    _____) )__  ____   ____ 
|  ____/ |  _ \ / _  |  |  ____/ _ \|  _ \ / _  |
| |    | | | | ( (_| |  | |   | |_| | | | ( (_| |
|_|    |_|_| |_|\___ |  |_|    \___/|_| |_|\___ |
               (_____|                    (_____| 
");
                string[] array = new string[]{"Play", "Quit"};
                for (int i = 0; i < x; i++)
                {
                    System.Console.WriteLine(array[i]);
                }
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("--> " + array[x]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = x +1; i < array.Length; i++)
                {
                    System.Console.WriteLine(array[i]);
                }
                ConsoleKeyInfo Ui = Console.ReadKey();

                if (Ui.Key == ConsoleKey.DownArrow && x != array.Length-1|| Ui.Key == ConsoleKey.S && x != array.Length-1)
                {
                    x++;
                }
                else if (Ui.Key == ConsoleKey.UpArrow && x != 0|| Ui.Key == ConsoleKey.W && x != 0)
                {
                    x--;
                }
                else if (Ui.Key == ConsoleKey.Enter)
                {
                    if (x == 0)
                    {
                        Game();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
        static void Game()
        {
            Window.Initialize();

            Random generator = new Random();
            Ball ball = new Ball(generator.Next(Window.windowW/4, ((Window.windowW/4)*3)), generator.Next(Window.windowH/4,((Window.windowH/4)*3)));
            

            //MIDDLE LINE INFO
                //Middle line width
                float midW = 5;

            //SPAWN BLOCKS
                Block right = new Block(1255, 360);
                Block left = new Block(15, 360);

            //RUN GAME
            while(!Raylib.WindowShouldClose())
            {
                //BALL MOVEMENT
                    //Speed increase
                        ball.xConstant = ball.xConstant*ball.speedIncreaseVar;
                        ball.yConstant = ball.yConstant*ball.speedIncreaseVar;

                    //Ball y mov
                        if (ball.Y < (Window.windowH-ball.R)) 
                        {
                            ball.Y += (int)ball.yConstant;
                        }
                        else if (ball.Y > (Window.windowH-ball.R))
                        {
                            ball.yConstant *= -1;
                            ball.Y += (int)ball.yConstant;
                        }

                        if (ball.Y < ball.R)
                        {
                            ball.yConstant *= -1;
                        }

                    //Ball X mov + bounce
                        //Main movement
                        ball.X += (int)ball.xConstant;

                        //Right bounce
                        if (ball.Y > (right.Y-5) && ball.Y < (right.Y+right.H+5) && ball.X > (right.X-ball.R))
                        {
                            //Change direction
                                ball.xConstant *= -1;
                            
                            //Speed increase on bounce
                                ball.xConstant = ball.xConstant*ball.speedIncreaseVar;
                                ball.yConstant = ball.yConstant*ball.speedIncreaseVar;
                        }

                        //Left bounce
                        if (ball.Y > (left.Y-5) && ball.Y < (left.Y+left.H+5) && ball.X < (left.X+ball.R*2))
                        {
                            //Change direction
                                ball.xConstant *= -1;
                            
                            //Speed increase on bounce
                                ball.xConstant = ball.xConstant*ball.speedIncreaseVar;
                                ball.yConstant = ball.yConstant*ball.speedIncreaseVar;
                        }

                //BLOCK MOVEMENT
                    //Left movement
                        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && left.Y >= 0)
                        {
                            left.Y = left.Y - left.S;
                        }

                        if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && left.Y <= (Window.windowH-left.H))
                        {
                            left.Y = left.Y + left.S;
                        }

                    //Right movement
                        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP) && right.Y >= 0)
                        {
                            right.Y = right.Y - right.S;
                        }

                        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) && right.Y <= (Window.windowH-right.H))
                        {
                            right.Y = right.Y + right.S;
                        }

                //Point system
                    //Left scores
                        if (ball.X > right.X)
                        {
                            //Score increase
                                left.SC++;

                            //Spawn new ball
                            
                                ball = new Ball(generator.Next(Window.windowW/4, ((Window.windowW/4)*3)), generator.Next(Window.windowH/4,((Window.windowH/4)*3)));


                            //Reset speed
                                ball.xConstant = ball.speedIncreaseConstant;
                                ball.yConstant = ball.speedIncreaseConstant;
                        }
                    //Right scores
                        else if (ball.X < (left.X+left.W))
                        {
                            //Score increase
                                right.SC++;

                            //Spawn new ball
                                ball = new Ball(generator.Next(Window.windowW/4, ((Window.windowW/4)*3)), generator.Next(Window.windowH/4,((Window.windowH/4)*3)));


                            //Reset speed
                                ball.xConstant = ball.speedIncreaseConstant;
                                ball.yConstant = ball.speedIncreaseConstant;
                        }

                //DRAWING
                    Raylib.BeginDrawing();

                    Raylib.ClearBackground(Window.backgroundColor);

                    //Middle line
                    Raylib.DrawRectangle((int)((Window.windowW/2)-(midW/2)), 0, (int)midW, Window.windowH, Color.GRAY);

                    //Score
                    Raylib.DrawText(left.SC.ToString(), (Window.windowW/2)-(Window.windowW/4), 5, 250, Color.GRAY);

                    Raylib.DrawText(right.SC.ToString(), (Window.windowW/2)+(Window.windowH/4), 5, 250, Color.GRAY);
                    
                    //Ball
                    if (ball.X > 0 && ball.X < Window.windowW)
                    {
                        Raylib.DrawCircle((int)ball.X, (int)ball.Y, ball.R, Color.WHITE);
                    }
                    
                    //Blocks
                    Raylib.DrawRectangle((int)left.X, (int)left.Y, left.W, left.H, Color.WHITE);

                    Raylib.DrawRectangle((int)right.X, (int)right.Y, right.W, right.H, Color.WHITE);

                    Raylib.EndDrawing();
            }
        }
    }
}
