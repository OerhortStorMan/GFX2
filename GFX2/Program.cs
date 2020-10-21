using System;
using Raylib_cs;
using System.Numerics;

namespace GFX2
{
    class Program
    {
        static void Main(string[] args)
        {
            int windowH = 600;
            int windowW = 800;

            Raylib.InitWindow(windowW, windowH, "Ping Pong");

            Color myColor = new Color(0, 0, 0, 0);

            //left Y pos
            float LY = 0;
            //left height
            int LH = 80;
            //left width
            int LW = 10;
            //left speed
            float LS = 0.3f;
            bool leftLost = false;

            //right y pos
            float RY = 0;
            //right height
            int RH = 80;
            //right width
            int RW = 10;
            //right speed
            float RS = 0.3f;
            bool rightLost = false;

            //ball start
            float ballY = 300;
            float ballX = 400;
            //ball radius
            int ballR = 15;
            //ball speed constant
            float constant = 0.175f;

            //random gen for start angle
            Random generator = new Random();

            while(!Raylib.WindowShouldClose())
            {
                //Ball movement
                //ball y mov
                if (ballY < (windowH-ballR)) 
                {
                    ballY += constant;
                    
                }
                else if (ballY > (windowH-ballR))
                {
                    constant *= -1;
                    ballY += constant;
                }

                if (ballY < ballR)
                {
                    constant *= -1;
                }

                //ball X mov
                if (ballX < (windowW-ballR)) 
                {
                    ballX += constant;
                    
                }
                else if (ballX > (windowW-ballR))
                {
                    constant *= -1;
                    ballX += constant;
                }

                if (ballX < ballR)
                {
                    constant *= -1;
                }

                //ball goal
                if (ballX == windowW - ballR)
                {
                    rightLost = true;
                }
                
                if (ballX == ballR)
                {
                    leftLost = true;
                }


                //Left movement
                if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                {
                    if (LY >= 0)
                    {
                        LY = LY - RS;
                    }
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    if (LY <= (windowH-LH))
                    {
                        LY = LY + LS;
                    }
                    
                }

                //Right movement
                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    if (RY >= 0)
                    {
                        RY = RY - RS;
                    }
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    if (RY <= (windowH-RH))
                    {
                        RY = RY + RS;
                    }
                    
                }


                Raylib.BeginDrawing();

                Raylib.ClearBackground(myColor);

                if (rightLost == true)
                {
                    Raylib.ImageText("Right lost!", 20, Color.RED);
                }
                else if (leftLost == true)
                {
                    Raylib.ImageText("Left lost!", 20, Color.RED);
                }
                else
                {
                Raylib.DrawCircle((int)ballX, (int)ballY, ballR, Color.WHITE);

                Raylib.DrawRectangle(15, (int)LY, LW, LH, Color.WHITE);

                Raylib.DrawRectangle(775, (int)RY, RW, RH, Color.WHITE);

                Raylib.EndDrawing();
                }
                


            }

            
            
        }
    }
}
