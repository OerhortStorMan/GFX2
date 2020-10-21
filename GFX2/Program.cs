using System;
using Raylib_cs;

namespace GFX2
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Ping Pong");

            Color myColor = new Color(0, 0, 0, 0);

            //left Y pos
            float LY = 0;
            //left height
            int LH = 80;

            //right y pos
            float RY = 0;
            //right height
            int RH = 80;

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
                        LY = LY - 0.5f;
                    }
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    if (LY <= 800 - LH)
                    {
                        LY = LY + 0.5f;
                    }
                    
                }

                //Right movement


                Raylib.BeginDrawing();

                Raylib.ClearBackground(myColor);

                Raylib.DrawCircle((int)ballX, (int)ballY, 15, Color.WHITE);

                Raylib.DrawRectangle(2, (int)LY, 10, LH, Color.WHITE);

                Raylib.DrawRectangle(788, (int)RY, 10, RH, Color.WHITE);

                Raylib.EndDrawing();
            }

            
            
        }
    }
}
