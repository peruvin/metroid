
class Upgrade : MovableSprite
{
    public Upgrade(short X, short Y) :base(new Image("img/upgrades.png", 1333, 757))
    {
        this.X = X;
        this.Y = Y;
        SpriteWidth = 16;
        SpriteHeight = 16;
    }
}

