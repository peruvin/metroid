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

    public bool CollidesWith(Sprite sp)
    {
        return (X + SpriteWidth > sp.X && X < sp.X + sp.SpriteWidth &&
                Y + SpriteHeight > sp.Y && Y < sp.Y + sp.SpriteHeight);
    }

    public bool CollidesWith(List<Sprite> sprites)
    {
        foreach (Sprite sp in sprites)
            if (this.CollidesWith(sp))
                return true;
        return false;
    }

    public bool CollidesWith(Sprite sprite, short w1, short h1, short w2, short h2)
    {
        return (X + w1 >= sprite.X && X <= sprite.X + w2 &&
                Y + h1 >= sprite.Y && Y <= sprite.Y + h2);
    }

    public void Fall()
    {
        this.Y++;
    }

    public bool IsOver(Sprite sprite)
    {
        return (this.CollidesWith(sprite, this.SpriteWidth, this.SpriteHeight,
            sprite.SpriteWidth, sprite.SpriteHeight) &&
            sprite.Y >= this.Y + this.SpriteHeight * 0.9);
    }


}

