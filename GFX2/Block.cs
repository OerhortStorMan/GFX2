using System;

namespace GFX2
{
    public class Block : GameObject
    {
        //BLOCK
                // height
                public  int H = 150;
                // width
                public  int W = 10;

                // y pos
                public  float Y; 
                // x pos
                public  float X; 

                // speed
                public  float S = 7f;

                // score
                public  int SC = 0;

        public Block(float X, float Y)
        {
            this.Y = Y - H/2;
            this.X = X;
        }
    }
}
