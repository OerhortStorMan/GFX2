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
                Color backgroundColor = new Color(0, 0, 0, 0);


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

                //Ball speed increase constant
                float speedIncreaseConstant = 1.0000075f;

                //Random gen for start position
                Random generator = new Random();
                ballY = generator.Next(250,351);
                ballX = generator.Next(350, 451);
            

            //MIDDLE LINE INFO
                //Middle line width
                float midW = 5;

            //RUN GAME
            while(!Raylib.WindowShouldClose())
            {
                //BALL MOVEMENT
                    //Speed increase
                        xConstant = xConstant*speedIncreaseConstant;
                        yConstant = yConstant*speedIncreaseConstant;

                    //Ball y mov
                        if (ballY < (windowH-ballR)) 
                        {
                            ballY += yConstant;
                        }
                        else if (ballY > (windowH-ballR))
                        {
                            yConstant *= -1;
                            ballY += yConstant;
                        }

                        if (ballY < ballR)
                        {
                            yConstant *= -1;
                        }

                    //Ball X mov + bounce
                        //Main movement
                        ballX += xConstant;

                        //Right bounce
                        if (ballY > (RY-5) && ballY < (RY+RH+5) && ballX > (RX-ballR))
                        {
                            //Change direction
                                xConstant *= -1;
                            
                            //Speed increase on bounce
                                xConstant = xConstant*speedIncreaseConstant;
                                yConstant = yConstant*speedIncreaseConstant;
                        }

                        //Left bounce
                        if (ballY > (LY-5) && ballY < (LY+LH+5) && ballX < (LX+ballR))
                        {
                            //Change direction
                                xConstant *= -1;
                            
                            //Speed increase on bounce
                                xConstant = xConstant*1.00005f;
                                yConstant = yConstant*1.00005f;
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

                //Point system
                    //Left scores
                        if (ballX > windowW)
                        {
                            //Score increase
                                LSC++;

                            //Spawn new ball
                                ballY = generator.Next(250,351);
                                ballX = generator.Next(350, 451);

                            //Reset speed
                                xConstant = 0.1f;
                                yConstant = 0.1f;
                        }
                    //Right scores
                        else if (ballX < 0)
                        {
                            //Score increase
                                RSC++;

                            //Spawn new ball
                                ballY = generator.Next(250,351);
                                ballX = generator.Next(350, 451);

                            //Reset speed
                                xConstant = 0.1f;
                                yConstant = 0.1f;
                        }

                //DRAWING
                    Raylib.BeginDrawing();

                    Raylib.ClearBackground(backgroundColor);

                    //Middle line
                    Raylib.DrawRectangle((int)((windowW/2)-(midW/2)), 0, (int)midW, windowH, Color.GRAY);

                    //Score
                    Raylib.DrawText(LSC.ToString(), (windowW/2)-(windowW/4), 5, 250, Color.GRAY);

                    Raylib.DrawText(RSC.ToString(), (windowW/2)+(windowH/4), 5, 250, Color.GRAY);
                    
                    //Ball
                    if (ballX > 0 && ballX < windowW)
                    {
                        Raylib.DrawCircle((int)ballX, (int)ballY, ballR, Color.WHITE);
                    }
                    
                    //Blocks
                    Raylib.DrawRectangle((int)LX, (int)LY, LW, LH, Color.WHITE);

                    Raylib.DrawRectangle((int)RX, (int)RY, RW, RH, Color.WHITE);

                    Raylib.EndDrawing();
            }
        }
    }
}
