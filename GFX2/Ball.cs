using System;

namespace GFX2
{
    public class Ball : GameObject
    {
        //BALL
                //Ball radius
                public int R = 15;

                //Ball speed constant
                public float xConstant = 5f;
                public float yConstant = 5f;

                //Ball speed increase constant
                public float speedIncreaseConstant = 5f; //For resetting speed after scoring
                public float speedIncreaseVar = 1.0002f; //The speed increaser

                // y pos
                public int Y; 
                // x pos
                public int X; 
                
                

        public Ball(int X, int Y)
        {
            //Random gen for start position


            this.X = X;
            this.Y = Y;

        }
    }
}
