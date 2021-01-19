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

        //MAIN MENU
            static void MainMenu()
            {
                //CREATE SELECTION POSITION ID
                    int x = 0;

                //RUN MENU
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
                    (____|                     (____| 
    ");
                        //PICK OPTIONS ARRAY
                            string[] array = new string[]{"Play", "Quit"};

                        //WHITEN SELECTION AND ADD ARROW
                            for (int i = 0; i < x; i++)
                            {
                                System.Console.WriteLine(array[i]);
                            }
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("--> " + array[x]);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        
                        for (int i = x+1; i < array.Length; i++)
                        {
                            System.Console.WriteLine(array[i]);
                        }
                        ConsoleKeyInfo Ui = Console.ReadKey();

                        //TOGGLE BETWEEN SELECTIONS AND SELECT UPON CLICK
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
        
        //GAME SCREEN
            static void Game()
            {
                //INITIALIZE GAME WINDOW
                    Window.Initialize();

                //SPAWN BALL
                    //Random generator for position
                        Random generator = new Random();
                    //Create ball
                        Ball ball = new Ball(generator.Next(Window.windowW/4, ((Window.windowW/4)*3)), generator.Next(Window.windowH/4,((Window.windowH/4)*3)));
                
                //MIDDLE LINE INFO
                    //Middle line width
                    float midW = 5;

                //SPAWN BLOCKS
                    Block right = new Block(1255, 360);
                    Block left = new Block(15, 360);

                //LET BALL KNOW BLOCKS
                    ball.right = right;
                    ball.left = left;

                //RUN GAME
                while(!Raylib.WindowShouldClose())
                {
                    //CALCULATE BALL POSITION AND BOUNCE
                        ball.Calculate();

                    //CALCULATE BLOCKS POSITION
                        right.Calculate("right");
                        left.Calculate("left");

                    //DRAWING
                        Raylib.BeginDrawing();

                        Raylib.ClearBackground(Window.backgroundColor);

                        GameObject.Draw(ball, right, left, midW);

                        Raylib.EndDrawing();
                }
            }
    }
}
