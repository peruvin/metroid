

class Enemy : MovableSprite
{
    public Enemy(short X, short Y,Image SpriteSheet):base(SpriteSheet)
    {
        this.X = X;
        this.Y = Y;
        SpriteWidth = 32;
        SpriteHeight = 28;
    }
}

