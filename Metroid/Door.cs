using System;



class Door : MovableSprite
{
    public int GoTo { get; set; }
    public int XApparitionPlayer { get; set; }
    public int YApparitionPlater { get; set; }
    

    public Door(short X, short Y) : base(new Image("img/1718.png", 950, 950))
    {
        this.X = X;
        this.Y = Y;
        SpriteWidth = 16;
        SpriteHeight = 16;     
    }
}

