using System;
using Raylib_cs;

namespace GFX2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Window prop.
            int windowW = 1280;
            int windowH = 720;

            Raylib.InitWindow(windowW, windowH, "Ping Pong");

            Color myColor = new Color(0, 0, 0, 0);


            //LEFT
            
            //left height
            int LH = 150;
            //left width
            int LW = 10;

            //left Y pos
            float LY = (windowH/2)-(LH/2);
            // left X pos
            float LX = 15;

            //left speed
            float LS = 0.125f;

            //left score
            int LSC = 0;


            //RIGHT
        
            //right height
            int RH = 150;
            //right width
            int RW = 10;

            //right y pos
            float RY = (windowH/2)-(RH/2);
            //right x pos
            float RX = windowW-15-RW;

            //right speed
            float RS = 0.125f;

            //right score
            int RSC = 0;


            //BALL

            //ball start
            float ballY = 300;
            float ballX = 400;

            //ball radius
            int ballR = 15;

            //ball speed constant
            float xConstant = 0.1f;
            float yConstant = 0.1f;

            //random gen for start position
            Random generator = new Random();
            ballY = generator.Next(250,351);
            ballX = generator.Next(350, 451);
            

            //MIDDLE LINE INFO
            float midW = 5;

            
            while(!Raylib.WindowShouldClose())
            {
                //Ball movement
                //speed increase
                xConstant = xConstant*1.000001f;
                yConstant = yConstant*1.000001f;
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

                if (ballY > (RY-5) && ballY < (RY+RH+5) && ballX > (RX-ballR))
                {
                    yConstant *= -1;
                }

                if (ballY > (LY-5) && ballY < (LY+LH+5) && ballX < (LX+ballR))
                {
                    yConstant *= -1;
                }


                //Left movement
                if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && LY >= 0)
                {
                    LY = LY - RS;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && LY <= (windowH-LH))
                {
                    LY = LY + LS;
                }

                //Right movement
                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP) && RY >= 0)
                {
                    RY = RY - RS;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) && RY <= (windowH-RH))
                {
                    RY = RY + RS;
                }

                Raylib.BeginDrawing();

                Raylib.ClearBackground(myColor);

                Raylib.DrawRectangle((int)((windowW/2)-(midW/2)), 0, (int)midW, windowH, Color.GRAY);
                
                Raylib.DrawCircle((int)ballX, (int)ballY, ballR, Color.WHITE);

                Raylib.DrawRectangle((int)LX, (int)LY, LW, LH, Color.WHITE);

                Raylib.DrawRectangle((int)RX, (int)RY, RW, RH, Color.WHITE);

                //DRAW POINTS, RÄKNA UT POINTS

                // Raylib.DrawText();

                Raylib.EndDrawing();

            }

            
            
        }

        
    }
}
