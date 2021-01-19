using System;
using Raylib_cs;

namespace GFX2
{
    public class GameObject
    {
        //DRAW METHOD
        public static void Draw(Ball ball, Block right, Block left, float midW)
        {
            //Middle line
                Raylib.DrawRectangle((int)((Window.windowW/2)-(midW/2)), 0, (int)midW, Window.windowH, Color.GRAY);

            //Score
                Raylib.DrawText(right.SC.ToString(), (Window.windowW/2)-(Window.windowW/4), 5, 250, Color.GRAY);

                Raylib.DrawText(left.SC.ToString(), (Window.windowW/2)+(Window.windowH/4), 5, 250, Color.GRAY);
            
            //Draw ball if within window borders
                if (ball.X > 0 && ball.X < Window.windowW)
                {
                    Raylib.DrawCircle((int)ball.X, (int)ball.Y, ball.R, Color.WHITE);
                }
            
            //Blocks
                Raylib.DrawRectangle((int)right.X, (int)right.Y, right.W, right.H, Color.WHITE);

                Raylib.DrawRectangle((int)left.X, (int)left.Y, left.W, left.H, Color.WHITE);
        }
    }
}
