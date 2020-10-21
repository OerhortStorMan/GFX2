using System;
using Raylib_cs;

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


            //right y pos
            float RY = 0;
            //right height
            int RH = 80;
            //right width
            int RW = 10;
            //right speed
            float RS = 0.3f;

            float ballX = 400;
            float ballY = 300;

            Random generator = new Random();
            //Så länge fönstret inte ska stängas; fortsätt while
            while(!Raylib.WindowShouldClose())
            {
                //Ball movement

                //Left movement

                if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                {
                    if (LY >= 0)
                    {
                        LY = LY - RS;
                    }
                }

                //box utanför spelrutan (!)
                if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    if (LY <= (800-LH))
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

                //box utanför spelrutan (!)
                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    if (RY <= (800-RH))
                    {
                        RY = RY + RS;
                    }
                    
                }



                Raylib.BeginDrawing();

                Raylib.ClearBackground(myColor);

                Raylib.DrawCircle((int)ballX, (int)ballY, 15, Color.WHITE);

                Raylib.DrawRectangle(2, (int)LY, LW, LH, Color.WHITE);

                Raylib.DrawRectangle(788, (int)RY, RW, RH, Color.WHITE);

                Raylib.EndDrawing();
            }

            
            
        }
    }
}
