using System;
using System.Collections.Generic;



class BasicBeam : Weapon
{
    

    public BasicBeam(short xinc, short yinc, Player shootBy) : base(xinc, yinc, 100, shootBy)
    {



        // Coordinates of the weapon firing in all directions 


        /*TODO: Uncompleted coordinates*/

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.LEFT] = new int[] {  1};
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.LEFT] = new int[] { 1 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.RIGHT] = new int[] { 1};
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.RIGHT] = new int[] { 1};

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_LEFT] = new int[] { 1 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_LEFT] = new int[] {  1};

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_RIGHT] = new int[] {  1};
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_RIGHT] = new int[] { 1 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.LEFT_UP_DIAGONAL] = new int[] { 1};
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.LEFT_UP_DIAGONAL] = new int[] {1 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.RIGHT_UP_DIAGONAL] = new int[] {  1};
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.RIGHT_UP_DIAGONAL] = new int[] {  1};

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_LEFT_DOWN_DIAGONAL] = new int[] { 1 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_LEFT_DOWN_DIAGONAL] = new int[] { 1 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_RIGHT_DOWN_DIAGONAL] = new int[] {   1 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_RIGHT_DOWN_DIAGONAL] = new int[] {   1 };



    }
}
