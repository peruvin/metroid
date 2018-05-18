using System.Collections.Generic;


class Player : MovableSprite
{



    public short[] HealthPoints { get; set; }
    public string LastMovement { get; set; }
    public bool IsChrouching { get; set; }
    public bool IsBallForm { get; set; }
    public bool CanConvertToBall { get; set; }
    public string AimDirection { get; set; }

    public Weapon PrimaryWeapon {get;set;}
    public Weapon MissileWeapon { get; set; }
    public Weapon SphereBombs { get; set; }


    public Player() : base(new Image("img/samus.gif", 1333, 757))
    {
        LastMovement = "LEFT";
        IsChrouching = false;
        IsBallForm = false;
        CanConvertToBall = false;

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



        /*Uncompleted coordinates*/


        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_LEFT_DOWN_DIAGONAL] = new int[] { 317 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_LEFT_DOWN_DIAGONAL] = new int[] { 299 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_RIGHT_DOWN_DIAGONAL] = new int[] { 442 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.CHROUCH_RIGHT_DOWN_DIAGONAL] = new int[] { 299 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.BALL_FORM] = new int[] {720,743,766,788};
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.BALL_FORM] = new int[] { 107,107,107,107};
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
            BasicBeam tempbeam;

            switch (AimDirection)
            {
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
                case "CHROUCH_LEFT_UP_DIAGONAL":
                    tempbeam = new BasicBeam(1, 1, this);
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


    public void MovePlayer(Hardware hardware)
    {

        /*TODO: set AimDirection to it's value when moving*/
        if (hardware.IsKeyPressed(Hardware.KEY_A))
        {
            MoveTo((short)(X - 1), Y);

            if (IsBallForm)
            {
                Animate(MovableSprite.SpriteMovement.BALL_FORM, MOVE_ANIMATION_DELAY);
            }
            else if (hardware.IsKeyPressed(Hardware.KEY_SHIFT) || hardware.IsKeyPressed(Hardware.KEY_W))
            {
                Animate(MovableSprite.SpriteMovement.LEFT_UP_DIAGONAL, MOVE_ANIMATION_DELAY);
            }
            else
            {
                Animate(MovableSprite.SpriteMovement.LEFT, MOVE_ANIMATION_DELAY);
            }

            LastMovement = "LEFT";
            IsChrouching = false;
            CanConvertToBall = false;
        }

        if (hardware.IsKeyPressed(Hardware.KEY_D))
        {
            MoveTo((short)(X + 1), Y);

            if (IsBallForm)
            {
                Animate(MovableSprite.SpriteMovement.BALL_FORM, MOVE_ANIMATION_DELAY);
            }
            else if (hardware.IsKeyPressed(Hardware.KEY_SHIFT) || hardware.IsKeyPressed(Hardware.KEY_W))
            {
                Animate(MovableSprite.SpriteMovement.RIGHT_UP_DIAGONAL, MOVE_ANIMATION_DELAY);
            }
            else
            {
                Animate(MovableSprite.SpriteMovement.RIGHT, MOVE_ANIMATION_DELAY);
            }
            LastMovement = "RIGHT";
            IsChrouching = false;
            CanConvertToBall = false;
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


        if ((!hardware.IsKeyPressed(Hardware.KEY_D)) && (!hardware.IsKeyPressed(Hardware.KEY_A)))
        {
            if (LastMovement == "LEFT")
            {
                if (hardware.IsKeyPressed(Hardware.KEY_W))
                {
                    Animate(MovableSprite.SpriteMovement.STILL_LEFT_UP, 100);
                    IsChrouching = false;
                    CanConvertToBall = false;
                }
                else
                {
                    if (IsChrouching)
                    {
                        if (!hardware.IsKeyPressed(Hardware.KEY_SHIFT))
                        {
                            Animate(MovableSprite.SpriteMovement.CHROUCH_LEFT, 100);
                        }
                        else
                        {
                            Animate(MovableSprite.SpriteMovement.CHROUCH_LEFT_DOWN_DIAGONAL, 100);
                        }
                    }
                    else if (IsBallForm)
                        Animate(MovableSprite.SpriteMovement.BALL_FORM, STILL_ANIMATION_DELAY);
                    else if (hardware.IsKeyPressed(Hardware.KEY_SHIFT))
                        Animate(MovableSprite.SpriteMovement.STILL_LEFT_UP_DIAGONAL, STILL_ANIMATION_DELAY);
                    else
                        Animate(MovableSprite.SpriteMovement.STILL_LEFT, STILL_ANIMATION_DELAY);
                }
            }
            else if (LastMovement == "RIGHT")
            {
                if (hardware.IsKeyPressed(Hardware.KEY_W))
                {
                    Animate(MovableSprite.SpriteMovement.STILL_RIGHT_UP, STILL_ANIMATION_DELAY);
                    IsChrouching = false;
                    CanConvertToBall = false;
                }
                else
                {
                    if (IsChrouching)
                    {
                        if (!hardware.IsKeyPressed(Hardware.KEY_SHIFT))
                        {
                            Animate(MovableSprite.SpriteMovement.CHROUCH_RIGHT, STILL_ANIMATION_DELAY);
                        }
                        else
                        {
                            Animate(MovableSprite.SpriteMovement.CHROUCH_RIGHT_DOWN_DIAGONAL, STILL_ANIMATION_DELAY);
                        }
                    }
                    else if (IsBallForm)
                        Animate(MovableSprite.SpriteMovement.BALL_FORM, STILL_ANIMATION_DELAY);
                    else if (hardware.IsKeyPressed(Hardware.KEY_SHIFT))
                        Animate(MovableSprite.SpriteMovement.STILL_RIGHT_UP_DIAGONAL, STILL_ANIMATION_DELAY);
                    else
                        Animate(MovableSprite.SpriteMovement.STILL_RIGHT, STILL_ANIMATION_DELAY);
                }

            }
            else
            {

            }
        }
    }
}

