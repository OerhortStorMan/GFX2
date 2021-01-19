using System;

namespace GFX2
{
    public class RightBlock : GameObject
    {
        //RIGHT BLOCK
                //Right height
                public static int RH = 150;
                //Right width
                public static int RW = 10;

                //Right y pos
                public static float RY = (Window.windowH/2)-(RH/2);
                //Right x pos
                public static float RX = Window.windowW-15-RW;

                //Right speed
                public static float RS = 7f;

                //Right score
                public static int RSC = 0;
    }
}
