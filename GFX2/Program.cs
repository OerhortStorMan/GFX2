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

            float LY = 0;
            float RY = 0;

            float ballX = 400;
            float ballY = 300;

            Random generator = new Random();
            //Så länge fönstret inte ska stängas; fortsätt while
            while(!Raylib.WindowShouldClose())
            {

                Raylib.BeginDrawing();

                Raylib.ClearBackground(myColor);

                Raylib.DrawRectangle(2, (int)LY, 10, 30, Color.WHITE);

                Raylib.DrawRectangle(2, (int)RY, 40, 40, Color.RED);

                Raylib.EndDrawing();
            }

            
            
        }
    }
}
