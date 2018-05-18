
class Player : MovableSprite
{
    public short[] HealthPoints { get; set; }
    public string LastMovement { get; set; }
    public bool IsChrouching { get; set; }
    public bool IsBallForm { get; set; }
    public bool CanConvertToBall { get; set; }
    public string AimDirection { get; set; }

    public Player() : base(new Image("img/samus.gif", 1333, 757))
    {
        LastMovement = "LEFT";
        IsChrouching = false;
        IsBallForm = false;
        CanConvertToBall = false;
        

        //Coordinates of the animated images in the spritesheet

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.LEFT] = new int[] { 12, 48, 88, 131, 179, 223, 263, 298, 339, 386};
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.LEFT] = new int[] { 296, 296, 296, 296, 296, 296, 296, 296, 296, 296 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.RIGHT] = new int[] { 438 , 475 , 519, 569, 613, 650, 691, 735, 782, 827};
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.RIGHT] = new int[] { 296, 296, 296, 296, 296, 296, 296, 296, 296, 296 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.STILL_LEFT] = new int[] {151,190,231 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.STILL_LEFT] = new int[] {56,56,56};

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.STILL_RIGHT]= new int[] {343,387,427 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.STILL_RIGHT]= new int[] {56,56,56 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.STILL_LEFT_UP] = new int[] { 483, 524, 568 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.STILL_LEFT_UP] = new int[] { 172, 172, 172 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.STILL_RIGHT_UP] = new int[] { 692, 728, 760 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.STILL_RIGHT_UP] = new int[] { 172, 172, 172 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_LEFT] = new int[] { 10 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_LEFT] = new int[] { 171};
                                                          
        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_RIGHT] = new int[] { 117 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_RIGHT] = new int[] { 171 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.LEFT_UP_DIAGONAL] = new int[] { 17, 53, 92, 136, 181, 228, 266, 303, 348, 389 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.LEFT_UP_DIAGONAL] = new int[] { 356, 356, 356, 356, 356, 356, 356, 356, 356, 356 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.RIGHT_UP_DIAGONAL] = new int[] { 430, 466, 509, 561, 607, 646, 685, 729, 779, 825 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.RIGHT_UP_DIAGONAL] = new int[] { 356, 356, 356, 356, 356, 356, 356, 356, 356, 356 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.STILL_LEFT_UP_DIAGONAL] = new int[] { 8, 47, 86 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.STILL_LEFT_UP_DIAGONAL] = new int[] { 117, 117, 117 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.STILL_RIGHT_UP_DIAGONAL] = new int[] { 198, 238, 277 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.STILL_RIGHT_UP_DIAGONAL] = new int[] { 117, 117, 117 };



        /*Uncompleted coordinates*/


        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_LEFT_DOWN_DIAGONAL] = new int[] { 317 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_LEFT_DOWN_DIAGONAL] = new int[] { 299 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_RIGHT_DOWN_DIAGONAL] = new int[] { 442 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_RIGHT_DOWN_DIAGONAL] = new int[] { 299 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.BALL_FORM] = new int[] {720,743,766,788};
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.BALL_FORM] = new int[] { 107,107,107,107};
    }
}

