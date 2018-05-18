using System;
using System.Collections.Generic;



class Weapon : MovableSprite
{
    public int Damage { get; set; }
    public short XIncrement { get; set; }
    public short YIncrement { get; set; }
    public Player ShootBy { get; set; }
    public bool CanShoot;

    public Weapon(short XIncrement, short YIncrement, int Damage, Player shootBy): base(new Image("img/weapon.png", 445, 1168))
    {
        this.XIncrement = XIncrement;
        this.YIncrement = YIncrement;
        this.Damage = Damage;
        this.ShootBy = shootBy;
        CanShoot = false;
    }

    public void DrawAllShots(List<Weapon> weaponList, Hardware hardware)
    {
        foreach(Weapon shot in weaponList)
        {
            hardware.DrawSprite(shot.SpriteSheet, shot.X, shot.Y, shot.SpriteX, shot.SpriteY, shot.SpriteWidth, shot.SpriteHeight);
            shot.X += shot.XIncrement;
            shot.Y += shot.YIncrement;
        }
    }

    public virtual void CreateNewShots(string aimdirection, Hardware hardware, List<Weapon> weaponList, Player character)
    {
        /*For now, it always creates a BadicBeam shot, later, I will add another weapon parameter to create shots from that specific class*/

        if (hardware.IsKeyPressed(Hardware.KEY_M))
        {
            CanShoot = true;
        }

        if (!hardware.IsKeyPressed(Hardware.KEY_M) && CanShoot)
        {
            BasicBeam tempbeam = null;

            switch (aimdirection)
            {
                case "LEFT":
                    tempbeam = new BasicBeam(-1, 0, character);
                    tempbeam.X = character.X;
                    tempbeam.Y = (short)(character.Y);
                    break;
                case "RIGHT":
                    tempbeam = new BasicBeam(1, 0, character);
                    tempbeam.X = (short)(character.X);
                    tempbeam.Y = (short)(character.Y);
                    break;
                case "LEFT_UP_DIAGONAL":
                    tempbeam = new BasicBeam(-1, -1, character);
                    tempbeam.X = (short)(character.X);
                    tempbeam.Y = (short)(character.Y);
                    break;
                case "RIGHT_UP_DIAGONAL":
                    tempbeam = new BasicBeam(1, -1, character);
                    tempbeam.X = (short)(character.X);
                    tempbeam.Y = (short)(character.Y);
                    break;
                case "CHROUCH_LEFT":
                    tempbeam = new BasicBeam(-1, 0, character);
                    tempbeam.X = (short)(character.X);
                    tempbeam.Y = (short)(character.Y);
                    break;
                case "CHROUCH_RIGHT":
                    tempbeam = new BasicBeam(1, 0, character);
                    tempbeam.X = (short)(character.X);
                    tempbeam.Y = (short)(character.Y);
                    break;
                case "CHROUCH_LEFT_DOWN_DIAGONAL":
                    tempbeam = new BasicBeam(-1, 1, character);
                    tempbeam.X = (short)(character.X);
                    tempbeam.Y = (short)(character.Y);
                    break;
                case "CHROUCH_LEFT_UP_DIAGONAL":
                    tempbeam = new BasicBeam(1, 1, character);
                    tempbeam.X = (short)(character.X);
                    tempbeam.Y = (short)(character.Y);
                    break;
                default:
                    break;
            }

            if (tempbeam != null)
            {
                weaponList.Add(tempbeam);
            }


        }

    }

}

