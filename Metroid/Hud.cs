
class Hud : MovableSprite
{
    public Hud() : base(new Image("img/hud.png", 416, 259))
    {
        X = 0;
        Y = 0;
        SpriteWidth = 250;
        SpriteHeight = 50;

        /*Unfinished coordinates*/
        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.STILL_CENTER] = new int[] { 10 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.STILL_CENTER] = new int[] { 10 };
    }
}

