using System;
using Raylib_cs;

namespace GFX2
{
    public class Ball : GameObject
    {
        //BALL
            //Ball radius
            public int R = 15;

            //Ball speed constant (I use one X and one Y to differenciate between Y bounces and X bounces)
            public float xConstant = 5f;
            public float yConstant = 5f;

            //Ball speed increase constant
            public float speedIncreaseConstant = 5f; //For resetting speed after scoring
            public float speedIncreaseVar = 1.0002f; //The speed increaser

            //Y pos
            public int Y; 
            //X pos
            public int X; 
            
            //Defining blocks for calculating bounce
            public Block right;
            public Block left;
        
        //POSITIONS FOR WHEN SPAWNING BALL
            public Ball(int X, int Y)
            {
                    this.X = X;
                    this.Y = Y;
            }

        //CALCULATE BALL
            public void Calculate()
            {
                    //Random generator for new pos
                        Random generator = new Random();

                    //BALL MOVEMENT
                        //Speed increase
                            xConstant = xConstant*speedIncreaseVar;
                            yConstant = yConstant*speedIncreaseVar;

                        //Ball Y movement + Y bounce (reverse direction)
                            //Ball diagonal movement
                            if (Y < (Window.windowH-R)) 
                            {
                                Y += (int)yConstant;
                            }

                            //Ball top bounce
                            if (Y > (Window.windowH-R+1))
                            {
                                yConstant *= -1;
                                Y += (int)yConstant;
                            }
                            //Ball bottom bounce
                            if (Y < R+1)
                            {
                                yConstant *= -1;
                                Y += (int)yConstant;
                            }

                        //Ball X movement + X bounce (reverse direction)
                            //Main movement
                            X += (int)xConstant;

                            //Right bounce
                            if (Y > (right.Y-5) && Y < (right.Y+right.H+5) && X > (right.X-R))
                            {
                                //Change direction
                                    xConstant *= -1;
                                
                                //Speed increase on bounce
                                    xConstant = xConstant*speedIncreaseVar;
                                    yConstant = yConstant*speedIncreaseVar;
                            }

                            //Left bounce
                            if (Y > (left.Y-5) && Y < (left.Y+left.H+5) && X < (left.X+R*2))
                            {
                                //Change direction
                                    xConstant *= -1;
                                
                                //Speed increase on bounce
                                    xConstant = xConstant*speedIncreaseVar;
                                    yConstant = yConstant*speedIncreaseVar;
                            }

                    //POINT SYSTEM
                        //Right scores
                            if (X > right.X)
                            {
                                //Score increase
                                    right.SC++;

                                //Reset ball to new position
                                    this.X = generator.Next(Window.windowW/4, ((Window.windowW/4)*3));
                                    this.Y = generator.Next(Window.windowH/4,((Window.windowH/4)*3));

                                //Reset speed
                                    xConstant = speedIncreaseConstant;
                                    yConstant = speedIncreaseConstant;
                            }
                            
                        //Left scores
                            else if (X < (left.X+left.W))
                            {
                                //Score increase
                                    left.SC++;

                                //Reset ball to new position                               
                                    this.X = generator.Next(Window.windowW/4, ((Window.windowW/4)*3));
                                    this.Y = generator.Next(Window.windowH/4,((Window.windowH/4)*3));

                                //Reset speed
                                    xConstant = speedIncreaseConstant;
                                    yConstant = speedIncreaseConstant;
                            }
            }
    }
}
