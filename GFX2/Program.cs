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
            float LY = 300;
            // left X pos
            float LX = 15;
            //left height
            int LH = 80;
            //left width
            int LW = 10;
            //left speed
            float LS = 0.1f;
            bool leftLost = false;

            //right y pos
            float RY = 300;
            //right x pos
            float RX = 775;
            //right height
            int RH = 80;
            //right width
            int RW = 10;
            //right speed
            float RS = 0.1f;
            bool rightLost = false;

            //ball start
            float ballY = 300;
            float ballX = 400;
            //ball radius
            int ballR = 15;
            //ball speed constant
            float xConstant = 0.1f;
            float yConstant = 0.1f;

            //random gen for start angle
            Random generator = new Random();

            while(!Raylib.WindowShouldClose())
            {
                //Ball movement
                //ball y mov
                if (ballY < (windowH-ballR)) 
                {
                    ballY += xConstant;
                    
                }
                else if (ballY > (windowH-ballR))
                {
                    xConstant *= -1;
                    ballY += xConstant;
                }

                if (ballY < ballR)
                {
                    xConstant *= -1;
                }

                //ball X mov + bounce
                ballX += yConstant;

                if (ballY > RY && ballY < (RY+RH) && ballX > (RX-ballR))
                {
                    yConstant *= -1;
                }

                if (ballY > LY && ballY < (LY+LH) && ballX < (LX+ballR))
                {
                    yConstant *= -1;
                }
                



                //ball goal
                // if (ballX == windowW)
                // {
                //     rightLost = true;
                // }
                // if (ballX == 0)
                // {
                //     leftLost = true;
                // }


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

                Raylib.DrawRectangle((int)LX, (int)LY, LW, LH, Color.WHITE);

                Raylib.DrawRectangle((int)RX, (int)RY, RW, RH, Color.WHITE);

                Raylib.EndDrawing();
                }
                


            }

            
            
        }
    }
}
