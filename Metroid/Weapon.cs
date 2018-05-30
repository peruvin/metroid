using System;
using System.Collections.Generic;




class Weapon : MovableSprite
{
    public int Damage { get; set; }
    public short XIncrement { get; set; }
    public short YIncrement { get; set; }
    public Player ShootBy { get; set; }
    public bool CanShoot { get; set; }
    public bool IsVisible { get; set; }
    public bool IsDetonated { get; set; }
    public short FramesDetonating { get; set; }
    public bool IsCharged { get; set; }

    public Weapon(short XIncrement, short YIncrement, int Damage, Player shootBy) : base(new Image("img/weapon.png", 445, 1168))
    {
        this.XIncrement = XIncrement;
        this.YIncrement = YIncrement;
        this.Damage = Damage;
        this.ShootBy = shootBy;
        CanShoot = false;
        IsVisible = true;
        IsDetonated = false;
        IsCharged = false;
        FramesDetonating = 0;
    }

    public void MoveShot()
    {
        if (IsVisible)
        {
            Animate(MovableSprite.SpriteMovement.LEFT, 20);

            X += XIncrement;
            Y += YIncrement;
        }
        else if (!IsDetonated)
        {
            XIncrement = 0;
            YIncrement = 0;
            FramesDetonating++;
            FiniteAnimate(MovableSprite.SpriteMovement.DETONATION, 200);
            if (FramesDetonating > 60)
            {
                IsDetonated = true;
            }

        }
    }
}

