class Block : MovableSprite
{

    public Block(short X, short Y) : base(new Image("img/1718.png", 950, 950))
    {
        this.X = X;
        this.Y = Y;
        SpriteWidth = 16;
        SpriteHeight = 16;


        /*Unfinished coordinates*/
        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.STILL_CENTER] = new int[] { 35 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.STILL_CENTER] = new int[] { 35 };
    }
}

