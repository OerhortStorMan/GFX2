using System;
using Raylib_cs;

namespace GFX2
{
    class Program
    {
        static void Main(string[] args)
        {
            //WINDOW PROPERTIES
                //Window width
                int windowW = 1280;

                //Window height
                int windowH = 720;

                //Window creation
                Raylib.InitWindow(windowW, windowH, "Ping Pong");

                //Background color
                Color myColor = new Color(0, 0, 0, 0);


            //LEFT BLOCK
                //Left height
                int LH = 150;
                //Left width
                int LW = 10;

                //Left Y pos
                float LY = (windowH/2)-(LH/2);
                //Left X pos
                float LX = 15;

                //Left speed
                float LS = 0.125f;

                //Left score
                int LSC = 0;


            //RIGHT BLOCK
                //Right height
                int RH = 150;
                //Right width
                int RW = 10;

                //Right y pos
                float RY = (windowH/2)-(RH/2);
                //Right x pos
                float RX = windowW-15-RW;

                //Right speed
                float RS = 0.125f;

                //Right score
                int RSC = 0;


            //BALL
                //Ball start
                float ballY = 300;
                float ballX = 400;

                //Ball radius
                int ballR = 15;

                //Ball speed constant
                float xConstant = 0.1f;
                float yConstant = 0.1f;

                //Random gen for start position
                Random generator = new Random();
                ballY = generator.Next(250,351);
                ballX = generator.Next(350, 451);
            

            //MIDDLE LINE INFO
                float midW = 5;

            //RUN GAME
            while(!Raylib.WindowShouldClose())
            {
                //BALL MOVEMENT
                    //Speed increase
                        xConstant = xConstant*1.000001f;
                        yConstant = yConstant*1.000001f;

                    //Ball y mov
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

                    //Ball X mov + bounce
                        //Main movement
                        ballX += yConstant;

                        //Right bounce
                        if (ballY > (RY-5) && ballY < (RY+RH+5) && ballX > (RX-ballR))
                        {
                            yConstant *= -1;
                        }

                        //Left bounce
                        if (ballY > (LY-5) && ballY < (LY+LH+5) && ballX < (LX+ballR))
                        {
                            yConstant *= -1;
                        }

                //BLOCK MOVEMENT
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

                //DRAWING
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
