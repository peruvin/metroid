using System;



class Door : MovableSprite
{
    public int GoTo { get; set; }
    public short XApparitionPlayer { get; set; }
    public short YApparitionPlayer { get; set; }
    

    public Door(short X, short Y, int GoTo, short XAppPlayer, short YAppPlayer) : base(new Image("img/1718.png", 950, 950))
    {
        this.GoTo = GoTo;
        this.XApparitionPlayer = XAppPlayer;
        this.YApparitionPlayer = YAppPlayer;
        this.X = X;
        this.Y = Y;
        SpriteWidth = 16;
        SpriteHeight = 16;

    }

    public void ChangeDestination(int goTo, short xApparitionPlayer, short yApparitionplayer)
    {
        this.GoTo = goTo;
        this.XApparitionPlayer = xApparitionPlayer;
        this.YApparitionPlayer = YApparitionPlayer;
    }
}

