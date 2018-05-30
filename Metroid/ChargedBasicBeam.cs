using System;



class ChargedBasicBeam : Weapon
{
    public ChargedBasicBeam(short xinc, short yinc, Player shootBy) : base(xinc, yinc, 150, shootBy)
    {
        SpriteHeight = 38;
        SpriteWidth = 38;

        HitboxXMarginRight = 8;
        HitboxYMarginDown = 8;

        /*Uncompleted coordinates*/
        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.LEFT] = new int[] { 66, 115 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.LEFT] = new int[] { 326, 326 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.RIGHT] = new int[] { 23 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.RIGHT] = new int[] { 26 };


        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.LEFT_UP_DIAGONAL] = new int[] { 23 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.LEFT_UP_DIAGONAL] = new int[] { 26 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.RIGHT_UP_DIAGONAL] = new int[] { 23 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.RIGHT_UP_DIAGONAL] = new int[] { 26 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_LEFT_DOWN_DIAGONAL] = new int[] { 23 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_LEFT_DOWN_DIAGONAL] = new int[] { 26 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_RIGHT_DOWN_DIAGONAL] = new int[] { 23 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_RIGHT_DOWN_DIAGONAL] = new int[] { 26 };


        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.DETONATION] = new int[] { 161, 209, 260};
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.DETONATION] = new int[] { 326, 326, 326};
    }
}

