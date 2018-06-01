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

    public bool CollidesWith(Sprite sp, short xOffset)
    {


        return (
                X +  xOffset + SpriteWidth-(HitboxXMarginRight) > (sp.X+sp.HitboxXMarginLeft) && 
                X + xOffset + HitboxXMarginLeft < sp.X + sp.SpriteWidth-(sp.HitboxXMarginRight) &&
                Y  + SpriteHeight -(HitboxYMarginDown) > (sp.Y+sp.HitboxYMarginUp) && 
                Y  + HitboxYMarginUp < sp.Y + sp.SpriteHeight-(sp.HitboxYMarginDown)
                );
    }

    public bool CollidesWith(List<Sprite> sprites, short xOffset)
    {
        foreach (Sprite sp in sprites)
            if (this.CollidesWith(sp, xOffset))
                return true;
        return false;
    }

    public bool CollidesWith(Sprite sprite, short w1, short h1, short w2, short h2, short xOffset)
    {
        return (X + xOffset + w1 - (HitboxXMarginRight) >= sprite.X+sprite.HitboxXMarginLeft && 
                X + xOffset + HitboxXMarginLeft <= sprite.X + w2 - (sprite.HitboxXMarginRight) &&
                Y + h1  -(HitboxYMarginDown)>= sprite.Y+sprite.HitboxYMarginUp && 
                Y +HitboxYMarginUp <= sprite.Y + h2 -sprite.HitboxYMarginDown);
    }

    public void Fall()
    {
        Y++;
    }

    public bool IsOver(Sprite sprite, short xOffset)
    {
        return  (this.CollidesWith(sprite, (short)(this.SpriteWidth-1), (short)(this.SpriteHeight - 1),
                (short)(sprite.SpriteWidth - 1), (short)(sprite.SpriteHeight-1), xOffset) &&
                sprite.Y > this.Y + this.SpriteHeight * 0.9);
    }

    public bool IsDown(Sprite sprite, short xOffset)
    {
        return (this.CollidesWith(sprite, (short)(this.SpriteWidth - 1), (short)(this.SpriteHeight - 1),
                (short)(sprite.SpriteWidth - 1), (short)(sprite.SpriteHeight - 1), xOffset) &&
                this.Y > sprite.Y + sprite.SpriteHeight * 0.9);
    }


    /*TODO: Repair IsRight and IsLeft functions*/
    public bool IsRight(Sprite sprite, short xOffset)
    {
        return  (this.CollidesWith(sprite, (short)(this.SpriteWidth - 1), (short)(this.SpriteHeight - 1),
                (short)(sprite.SpriteWidth - 1), (short)(sprite.SpriteHeight - 1), xOffset) &&
                this.X+(this.SpriteWidth*0.9)<sprite.X);
    }

    public bool IsLeft(Sprite sprite, short xOffset)
    {
        return  (this.CollidesWith(sprite, (short)(this.SpriteWidth - 1), (short)(this.SpriteHeight - 1),
                (short)(sprite.SpriteWidth - 1), (short)(sprite.SpriteHeight - 1), xOffset) &&
                this.X > sprite.X + (sprite.SpriteWidth * 0.9));
    }




}

