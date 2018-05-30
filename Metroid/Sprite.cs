using System;
using System.Collections.Generic;



class Sprite
{
    /*
    public static Image SpriteSheet = new Image("img/samus.gif", 1333, 757);
    */
    public Image SpriteSheet { get; set; }

    public short X { get; set; }
    public short Y { get; set; }

    public short SpriteX { get; set; }
    public short SpriteY { get; set; }

    public short SpriteWidth { get; set; }
    public short SpriteHeight { get; set; }

    public short HitboxXMarginLeft { get; set; }
    public short HitboxXMarginRight { get; set; }
    public short HitboxYMarginUp { get; set; }
    public short HitboxYMarginDown { get; set; }


    public Sprite(Image SpriteSheet)
    {
        HitboxXMarginLeft = 0;
        HitboxXMarginRight = 0;
        HitboxYMarginUp = 0;
        HitboxYMarginDown = 0;
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


        return (
                X + SpriteWidth-(HitboxXMarginRight) > (sp.X+sp.HitboxXMarginLeft) && 
                X+HitboxXMarginLeft < sp.X + sp.SpriteWidth-(sp.HitboxXMarginRight) &&
                Y + SpriteHeight -(HitboxYMarginDown) > (sp.Y+sp.HitboxYMarginUp) && 
                Y+HitboxYMarginUp < sp.Y + sp.SpriteHeight-(sp.HitboxYMarginDown)
                );
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
        return (X + w1 - (HitboxXMarginRight) >= sprite.X+sprite.HitboxXMarginLeft && 
                X+HitboxXMarginLeft <= sprite.X + w2 - (sprite.HitboxXMarginRight) &&
                Y + h1  -(HitboxYMarginDown)>= sprite.Y+sprite.HitboxYMarginUp && 
                Y +HitboxYMarginUp <= sprite.Y + h2 -sprite.HitboxYMarginDown);
    }

    public void Fall()
    {
        Y++;
    }

    public bool IsOver(Sprite sprite)
    {
        return  (this.CollidesWith(sprite, (short)(this.SpriteWidth-1), (short)(this.SpriteHeight - 1),
                (short)(sprite.SpriteWidth - 1), (short)(sprite.SpriteHeight-1)) &&
                sprite.Y >= this.Y + this.SpriteHeight * 0.9);
    }

    public bool IsRight(Sprite sprite)
    {
        return  (this.CollidesWith(sprite, (short)(this.SpriteWidth - 1), (short)(this.SpriteHeight - 1),
                (short)(sprite.SpriteWidth - 1), (short)(sprite.SpriteHeight - 1)) &&
                sprite.X >= this.X + this.SpriteWidth * 0.9);
    }

    public bool IsLeft(Sprite sprite)
    {
        return  (this.CollidesWith(sprite, (short)(this.SpriteWidth - 1), (short)(this.SpriteHeight - 1),
                (short)(sprite.SpriteWidth - 1), (short)(sprite.SpriteHeight - 1)) &&
                this.X >= sprite.X + sprite.SpriteWidth * 0.9);
    }


}

