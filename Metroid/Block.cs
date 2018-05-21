class Block : MovableSprite
{

    public Block(short X, short Y) : base(new Image("img/weapon.png", 445, 1168))
    {
        this.X = X;
        this.Y = Y;
    }
}

