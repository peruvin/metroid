using System;
using System.Collections.Generic;



class Sprite
{
    /*
    public static Image SpriteSheet = new Image("img/samus.gif", 1333, 757);
    */
    public Image SpriteSheet { get; set; }
    public short SpriteWidth { get;set; }
    public short SpriteHeight { get;set; }

    public short X { get; set; }
    public short Y { get; set; }
    public short SpriteX { get; set; }
    public short SpriteY { get; set; }

    public Sprite(Image SpriteSheet)
    {
        SpriteWidth = 34;
        SpriteHeight = 48;
        this.SpriteSheet = SpriteSheet;
    }

    public void MoveTo(short x, short y)
    {
        X = x;
        Y = y;
    }


}

