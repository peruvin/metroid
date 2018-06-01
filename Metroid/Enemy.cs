

class Enemy : MovableSprite
{
    public bool IsAttacking { get; set; }
    public short Damage { get; set; }

    public Enemy(short X, short Y,Image SpriteSheet, short Damage) : base(SpriteSheet)
    {
        this.X = X;
        this.Y = Y;
        SpriteWidth = 32;
        SpriteHeight = 28;
        IsAttacking = false;
        this.Damage = Damage;
    }
}

