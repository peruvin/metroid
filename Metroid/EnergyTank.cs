using System;


class EnergyTank : Upgrade
{
    public EnergyTank(short X, short Y) : base(X,Y)
    {
        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.STILL_CENTER] = new int[] { 244 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.STILL_CENTER] = new int[] { 0 };
    }
}
