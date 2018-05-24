using System.Collections.Generic;


class Player : MovableSprite
{

    const short MAX_VERTICAL_SPEED = 16;
    const short VERTICAL_SPEED_DECREMENT = 2;

    public short[] HealthPoints { get; set; }
    public string LastMovement { get; set; }
    public string AimDirection { get; set; }

    public bool IsChrouching { get; set; }
    public bool IsBallForm { get; set; }
    public bool CanConvertToBall { get; set; }
    public bool IsAimingDiagonal { get; set; }
    public bool IsLookingUp { get; set; }
    public bool IsFalling { get; set; }
    public bool IsJumping { get; set; }

    public short VerticalSpeed { get; set; }

    public short OldX;
    public short OldY;

    public Weapon PrimaryWeapon {get;set;}
    public Weapon MissileWeapon { get; set; }
    public Weapon SphereBombs { get; set; }


    public Player() : base(new Image("img/samus.gif", 1333, 757))
    {
        LastMovement = "LEFT";
        AimDirection = "LEFT";

        IsChrouching = false;
        IsBallForm = false;
        CanConvertToBall = false;
        IsAimingDiagonal = false;
        IsLookingUp = false;
        IsFalling = false;
        IsJumping = false;
        VerticalSpeed = 0;

        PrimaryWeapon = new BasicBeam(1, 1, this);


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



        


        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_LEFT_DOWN_DIAGONAL] = new int[] { 322 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_LEFT_DOWN_DIAGONAL] = new int[] { 171 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_RIGHT_DOWN_DIAGONAL] = new int[] {  434 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_RIGHT_DOWN_DIAGONAL] = new int[] { 171 };

        /*Uncompleted coordinates*/

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.BALL_FORM] = new int[] {720,743,766,788};
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.BALL_FORM] = new int[] { 107,107,107,107};
    }

    public void FillOldCoordinates()
    {
        OldX = X;
        OldY = Y;
    }



    public void CreateNewShots(Hardware hardware, List<Weapon> weaponList)
    {
        /*For now, it always creates a BasicBeam shot, later, I will add another weapon parameter to create shots from that specific class*/

        if (hardware.IsKeyPressed(Hardware.KEY_M))
        {
            PrimaryWeapon.CanShoot = true;
        }

        if (!hardware.IsKeyPressed(Hardware.KEY_M) && PrimaryWeapon.CanShoot)
        {
            PrimaryWeapon.CanShoot = false;
            BasicBeam tempbeam;

            switch (AimDirection)
            {
                /*TODO: Starting X and Y will change slightly their positions*/
                case "LEFT":
                    tempbeam = new BasicBeam(-1, 0, this);
                    tempbeam.X = this.X;
                    tempbeam.Y = (short)(this.Y);
                    break;
                case "RIGHT":
                    tempbeam = new BasicBeam(1, 0, this);
                    tempbeam.X = (short)(this.X);
                    tempbeam.Y = (short)(this.Y);
                    break;
                case "LEFT_UP_DIAGONAL":
                    tempbeam = new BasicBeam(-1, -1, this);
                    tempbeam.X = (short)(this.X);
                    tempbeam.Y = (short)(this.Y);
                    break;
                case "RIGHT_UP_DIAGONAL":
                    tempbeam = new BasicBeam(1, -1, this);
                    tempbeam.X = (short)(this.X);
                    tempbeam.Y = (short)(this.Y);
                    break;
                case "CHROUCH_LEFT":
                    tempbeam = new BasicBeam(-1, 0, this);
                    tempbeam.X = (short)(this.X);
                    tempbeam.Y = (short)(this.Y);
                    break;
                case "CHROUCH_RIGHT":
                    tempbeam = new BasicBeam(1, 0, this);
                    tempbeam.X = (short)(this.X);
                    tempbeam.Y = (short)(this.Y);
                    break;
                case "CHROUCH_LEFT_DOWN_DIAGONAL":
                    tempbeam = new BasicBeam(-1, 1, this);
                    tempbeam.X = (short)(this.X);
                    tempbeam.Y = (short)(this.Y);
                    break;
                case "CHROUCH_RIGHT_DOWN_DIAGONAL":
                    tempbeam = new BasicBeam(1, 1, this);
                    tempbeam.X = (short)(this.X);
                    tempbeam.Y = (short)(this.Y);
                    break;
                case "UP":
                    tempbeam = new BasicBeam(0, -1, this);
                    tempbeam.X = (short)(this.X);
                    tempbeam.Y = (short)(this.Y);
                    break;
                default:
                    tempbeam = new BasicBeam(1, 1, this);
                    break;
            }

            if (tempbeam != null)
            {
                weaponList.Add(tempbeam);
            }


        }

    }

    public void MoveLeft()
    {
        MoveTo((short)(X - 1), Y);

        if (IsBallForm)
        {
            Animate(MovableSprite.SpriteMovement.BALL_FORM, MOVE_ANIMATION_DELAY);
        }
        else if (IsAimingDiagonal)
        {
            Animate(MovableSprite.SpriteMovement.LEFT_UP_DIAGONAL, MOVE_ANIMATION_DELAY);
            AimDirection = "LEFT_UP_DIAGONAL";
        }
        else
        {
            Animate(MovableSprite.SpriteMovement.LEFT, MOVE_ANIMATION_DELAY);
            AimDirection = "LEFT";
        }

        LastMovement = "LEFT";
        IsChrouching = false;
        CanConvertToBall = false;

    }

    public void MoveRight()
    {
        MoveTo((short)(X + 1), Y);

        if (IsBallForm)
        {
            Animate(MovableSprite.SpriteMovement.BALL_FORM, MOVE_ANIMATION_DELAY);
        }
        else if (IsAimingDiagonal)
        {
            Animate(MovableSprite.SpriteMovement.RIGHT_UP_DIAGONAL, MOVE_ANIMATION_DELAY);
            AimDirection = "RIGHT_UP_DIAGONAL";
        }
        else
        {
            Animate(MovableSprite.SpriteMovement.RIGHT, MOVE_ANIMATION_DELAY);
            AimDirection = "RIGHT";
        }
        LastMovement = "RIGHT";
        IsChrouching = false;
        CanConvertToBall = false;
    }

    public void StillLeft()
    {
        if (IsLookingUp)
        {
            AimDirection = "UP";
            Animate(MovableSprite.SpriteMovement.STILL_LEFT_UP, 100);
            IsChrouching = false;
            CanConvertToBall = false;
        }
        else
        {
            if (IsChrouching)
            {
                if (!IsAimingDiagonal)
                {
                    Animate(MovableSprite.SpriteMovement.CHROUCH_LEFT, 100);
                    AimDirection = "CHROUCH_LEFT";
                }
                else
                {
                    Animate(MovableSprite.SpriteMovement.CHROUCH_LEFT_DOWN_DIAGONAL, 100);
                    AimDirection = "CHROUCH_LEFT_DOWN_DIAGONAL";
                }
            }
            else if (IsBallForm)
            {
                Animate(MovableSprite.SpriteMovement.BALL_FORM, STILL_ANIMATION_DELAY);
            }
            else if (IsAimingDiagonal)
            {
                Animate(MovableSprite.SpriteMovement.STILL_LEFT_UP_DIAGONAL, STILL_ANIMATION_DELAY);
                AimDirection = "LEFT_UP_DIAGONAL";
            }
            else
            {
                Animate(MovableSprite.SpriteMovement.STILL_LEFT, STILL_ANIMATION_DELAY);
                AimDirection = "LEFT";
            }
                
        }
    }

    public void StillRight()
    {
        if (IsLookingUp)
        {
            Animate(MovableSprite.SpriteMovement.STILL_RIGHT_UP, STILL_ANIMATION_DELAY);
            AimDirection = "UP";
            IsChrouching = false;
            CanConvertToBall = false;
        }
        else
        {
            if (IsChrouching)
            {
                if (!IsAimingDiagonal)
                {
                    Animate(MovableSprite.SpriteMovement.CHROUCH_RIGHT, STILL_ANIMATION_DELAY);
                    AimDirection = "CHROUCH_RIGHT";
                }
                else
                {
                    Animate(MovableSprite.SpriteMovement.CHROUCH_RIGHT_DOWN_DIAGONAL, STILL_ANIMATION_DELAY);
                    AimDirection = "CHROUCH_RIGHT_DOWN_DIAGONAL";
                }
            }
            else if (IsBallForm)
            {
                Animate(MovableSprite.SpriteMovement.BALL_FORM, STILL_ANIMATION_DELAY);
            }
            else if (IsAimingDiagonal)
            {
                Animate(MovableSprite.SpriteMovement.STILL_RIGHT_UP_DIAGONAL, STILL_ANIMATION_DELAY);
                AimDirection = "RIGHT_UP_DIAGONAL";
            }
            else
            {
                Animate(MovableSprite.SpriteMovement.STILL_RIGHT, STILL_ANIMATION_DELAY);
                AimDirection = "RIGHT";
            }
                
        }
    }

    public void MovePlayer(Hardware hardware)
    {

        /* Temporal code to jump and fall
         TODO: create the Jump function and fix the Jump itself*/
        
        if (IsFalling)
        {
            Fall();
        }

        if (IsJumping)
        {
            MoveTo(X, (short)(Y + VerticalSpeed));
            VerticalSpeed += VERTICAL_SPEED_DECREMENT;
            if(VerticalSpeed>=0)
            {
                IsJumping = false;
                IsFalling = true;
            }
        }


        if (hardware.IsKeyPressed(Hardware.KEY_SPACE)&&!IsJumping&&!IsFalling)
        {
            IsJumping = true;
            VerticalSpeed = (short)(-1 * MAX_VERTICAL_SPEED);
        }



        if (hardware.IsKeyPressed(Hardware.KEY_A))
        {
            if(hardware.IsKeyPressed(Hardware.KEY_W))
            {
                IsAimingDiagonal = true;
            }
            MoveLeft();
        }

        if (hardware.IsKeyPressed(Hardware.KEY_D))
        {
            if (hardware.IsKeyPressed(Hardware.KEY_W))
            {
                IsAimingDiagonal = true;
            }
            MoveRight();
        }


        if (hardware.IsKeyPressed(Hardware.KEY_S) && IsBallForm == false && IsChrouching == false)
        {
            IsChrouching = true;
        }

        if ((!hardware.IsKeyPressed(Hardware.KEY_S)) && IsChrouching)
        {
            CanConvertToBall = true;
        }

        if (hardware.IsKeyPressed(Hardware.KEY_S) && IsBallForm == false && IsChrouching == true && CanConvertToBall == true)
        {
            IsChrouching = false;
            IsBallForm = true;
        }

        if (hardware.IsKeyPressed(Hardware.KEY_W) && IsBallForm == true)
        {
            IsChrouching = false;
            IsBallForm = false;
            CanConvertToBall = false;
        }

        if(hardware.IsKeyPressed(Hardware.KEY_SHIFT))
        {
            IsAimingDiagonal = true;
        }

        if(!hardware.IsKeyPressed(Hardware.KEY_SHIFT))
        {
            IsAimingDiagonal = false;
        }

        if (hardware.IsKeyPressed(Hardware.KEY_W))
        {
            IsLookingUp = true;
        }

        if (!hardware.IsKeyPressed(Hardware.KEY_W))
        {
            IsLookingUp = false;
        }

        if ((!hardware.IsKeyPressed(Hardware.KEY_D)) && (!hardware.IsKeyPressed(Hardware.KEY_A)))
        {
            if (LastMovement == "LEFT")
            {
                StillLeft();
            }
            else if (LastMovement == "RIGHT")
            {
                StillRight();
            }
            else
            {

            }
        }

    }
}

