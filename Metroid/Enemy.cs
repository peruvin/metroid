

class Enemy : MovableSprite
{
    public bool IsAttacking;

    public Enemy(short X, short Y,Image SpriteSheet):base(SpriteSheet)
    {
        this.X = X;
        this.Y = Y;
        SpriteWidth = 32;
        SpriteHeight = 28;
        IsAttacking = false;
    }

    public bool IsPlayerInRange(Player character)
    {
        if(character.Y==Y)
        {
            return true;
        }

        return false;

    }
}

