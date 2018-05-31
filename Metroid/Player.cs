using System.Collections.Generic;


class Player : MovableSprite
{

    const short MAX_VERTICAL_SPEED = 2;

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
    public int FramesJumping { get; set; }

    public short OldX;
    public short OldY;

    public Weapon PrimaryWeapon {get;set;}
    public Weapon MissileWeapon { get; set; }
    public Weapon SphereBombs { get; set; }

    public int timeCharging { get; set; }


    public Player() : base(new Image("img/samus.gif", 1333, 757))
    {
        LastMovement = "LEFT";
        AimDirection = "LEFT";
        HitboxXMarginLeft = 4;
        HitboxXMarginRight = 4;
        IsChrouching = false;
        IsBallForm = false;
        CanConvertToBall = false;
        IsAimingDiagonal = false;
        IsLookingUp = false;
        IsFalling = false;
        IsJumping = false;
        VerticalSpeed = 0;
        timeCharging = 0;
        FramesJumping=0;

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



    public void CreateNewShots(Hardware hardware, List<Weapon> weaponList,short XOffset)
    {
        /*For now, it always creates a BasicBeam shot, later, I will add another weapon parameter to create shots from that specific class*/

        if (hardware.IsKeyPressed(Hardware.KEY_M))
        {
            PrimaryWeapon.CanShoot = true;
            timeCharging++;
        }

        if(timeCharging>200)
        {
            PrimaryWeapon.IsCharged = true;
        }

        if (!hardware.IsKeyPressed(Hardware.KEY_M) && PrimaryWeapon.CanShoot)
        {
            timeCharging = 0;
            PrimaryWeapon.CanShoot = false;

            short tempweapX;
            short tempweapY;
            short xinc;
            short yinc;

            switch (AimDirection)
            {
                case "LEFT":

                    xinc = -1;
                    yinc = 0;
                    tempweapX = (short)(this.X-8);
                    tempweapY = (short)(this.Y+16);
                    break;
                case "RIGHT":
                    xinc = 1;
                    yinc = 0;
                    tempweapX = (short)(this.X+24);
                    tempweapY = (short)(this.Y+16);
                    break;
                case "LEFT_UP_DIAGONAL":
                    xinc = -1;
                    yinc = -1;
                    tempweapX = (short)(this.X-8);
                    tempweapY = (short)(this.Y);
                    break;
                case "RIGHT_UP_DIAGONAL":
                    xinc = 1;
                    yinc = -1;
                    tempweapX = (short)(this.X+24);
                    tempweapY = (short)(this.Y);
                    break;
                case "CHROUCH_LEFT":
                    xinc = -1;
                    yinc = 0;
                    tempweapX = (short)(this.X-8);
                    tempweapY = (short)(this.Y+28);
                    break;
                case "CHROUCH_RIGHT":
                    xinc = 1;
                    yinc = 0;
                    tempweapX = (short)(this.X+24);
                    tempweapY = (short)(this.Y+28);
                    break;
                case "CHROUCH_LEFT_DOWN_DIAGONAL":
                    xinc = -1;
                    yinc = 1;
                    tempweapX = (short)(this.X - 10);
                    tempweapY = (short)(this.Y + 38);
                    break;
                case "CHROUCH_RIGHT_DOWN_DIAGONAL":
                    xinc = 1;
                    yinc = 1;
                    tempweapX = (short)(this.X + 26);
                    tempweapY = (short)(this.Y + 40);
                    break;
                case "UP":
                    xinc = 0;
                    yinc = -1;
                    tempweapX = (short)(this.X);
                    tempweapY = (short)(this.Y);
                    break;
                default:
                    xinc = 1;
                    yinc = 0;
                    tempweapX = (short)(this.X);
                    tempweapY = (short)(this.Y);
                    break;
            }

            if (PrimaryWeapon.IsCharged)
            {
               ChargedBasicBeam temp = new ChargedBasicBeam(xinc, yinc, this);
               temp.MoveTo((short)(tempweapX +XOffset), tempweapY);
               weaponList.Add(temp);
            }
            else
            {
                BasicBeam temp = new BasicBeam(xinc,yinc,this);
                temp.MoveTo((short)(tempweapX+XOffset),tempweapY);
                weaponList.Add(temp);
            }
            PrimaryWeapon.IsCharged = false;


        }

    }

    public void MoveLeft(CompleteRoom room)
    {

        if (X == Program.SCREEN_WIDTH / 2 && room.Xmap>0)
        {
            room.Xmap--;
        }
        else
        {
            MoveTo((short)(X - 1), Y);
        }
            

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

    public void MoveRight(CompleteRoom room)
    {
        if(X == Program.SCREEN_WIDTH/2 && room.Xmap < room.Width -Program.SCREEN_WIDTH)
        {
            room.Xmap++;
        }
        else
        {
            MoveTo((short)(X + 1), Y);
        }
        

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

    public void MovePlayer(Hardware hardware, CompleteRoom room)
    {

        
        if(IsBallForm)
        {
            HitboxYMarginUp = 33;      
        }
        else
        {
            HitboxYMarginUp = 17;
        }
        
        if (IsFalling)
        {
            Fall();
        }

        if (IsJumping)
        {
            FramesJumping++;
            MoveTo(X, (short)(Y + VerticalSpeed));
            if(FramesJumping>100)
            {
                IsJumping = false;
                IsFalling = true;
                FramesJumping = 0;
            }
        }


        if (hardware.IsKeyPressed(Hardware.KEY_SPACE)&&!IsJumping&&!IsFalling)
        {
            IsJumping = true;
            VerticalSpeed = (short)(-1 * MAX_VERTICAL_SPEED);
            FramesJumping = 0;
        }



        if (hardware.IsKeyPressed(Hardware.KEY_A))
        {
            if(hardware.IsKeyPressed(Hardware.KEY_W))
            {
                IsAimingDiagonal = true;
            }
            MoveLeft(room);
        }

        if (hardware.IsKeyPressed(Hardware.KEY_D))
        {
            if (hardware.IsKeyPressed(Hardware.KEY_W))
            {
                IsAimingDiagonal = true;
            }
            MoveRight(room);
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

