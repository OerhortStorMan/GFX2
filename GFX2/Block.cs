using System;
using Raylib_cs;

namespace GFX2
{
    public class Block : GameObject
    {
        //BLOCK
                //Height
                public  int H = 150;
                //Width
                public  int W = 10;

                //Y pos
                public  float Y; 
                //X pos
                public  float X; 

                //Speed
                public  float S = 7f;

                //Score
                public  int SC = 0;

        //BLOCK METHOD FOR CREATING BLOCKS
            public Block(float X, float Y)
            {
                this.Y = Y - H/2;
                this.X = X;
            }
        //CALCULATE MOVEMENT
            public void Calculate(string id)
            {
                //BLOCK MOVEMENT
                    //Left movement
                    if (id == "left")
                    {
                        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && this.Y >= 0)
                        {
                            this.Y = this.Y - this.S;
                        }

                        if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && this.Y <= (Window.windowH-this.H))
                        {
                            this.Y = this.Y + this.S;
                        }
                    }
                        

                    //Right movement
                    if (id == "right")
                    {
                        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP) && this.Y >= 0)
                        {
                            this.Y = this.Y - this.S;
                        }

                        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) && this.Y <= (Window.windowH-this.H))
                        {
                            this.Y = this.Y + this.S;
                        }
                    }
                        
            }
    }
}
