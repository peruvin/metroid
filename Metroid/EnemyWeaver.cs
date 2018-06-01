using System.Collections.Generic;


class EnemyWeaver : Enemy
{
    bool CanAttack { get; set; }
    bool IsReloading { get; set; }


    public EnemyWeaver(short X, short Y):base(X, Y,new Image("img/weaver.png", 135, 124),20)
    {
        CanAttack = false;
        IsReloading = false;
        /*Uncompleted Coordinates*/
        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.LEFT] = new int[] { 10 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.LEFT] = new int[] { 10 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.RIGHT] = new int[] { 0 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.RIGHT] = new int[] { 0 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.STILL_LEFT] = new int[] { 0 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.STILL_LEFT] = new int[] { 0 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.STILL_RIGHT] = new int[] { 0 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.STILL_RIGHT] = new int[] {  0};
    }

    public bool IsPlayerInRange(Player character, short XOffset)
    {
        if(character.X==X)
        {
            CanAttack = true;
            Attack(character,XOffset);
            return true;
        }
        return false;
    }

    public void Attack(Player character, short XOffset)
    {
        if(this.CollidesWith(character,XOffset))
        {
            character.GetDamage(this);
            CanAttack = false;
            IsReloading = true;
        }
        else if(CanAttack)
        {
            Y = Y++;
        }
        
    }

    public void BlockCollisions(List<Sprite> blocklist, short xOffset)
    {
        foreach(Sprite block in blocklist)
        {
            if(this.CollidesWith(block, xOffset)&&CanAttack)
            {
                CanAttack = false;
                IsReloading = true;
            }
            else if(this.CollidesWith(block, xOffset) && CanAttack)
            {
                IsReloading = false;
            }
        }
    }

    public void ReloadAttack()
    {
        if(IsReloading)
        {
            Y = Y--;
        }        
    }
}

