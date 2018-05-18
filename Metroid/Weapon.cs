using System;
using System.Collections.Generic;



class Weapon : MovableSprite
{
    public int Damage { get; set; }
    public short XIncrement { get; set; }
    public short YIncrement { get; set; }
    public Player ShootBy { get; set; }
    public bool CanShoot { get; set; }

    public Weapon(short XIncrement, short YIncrement, int Damage, Player shootBy): base(new Image("img/weapon.png", 445, 1168))
    {
        this.XIncrement = XIncrement;
        this.YIncrement = YIncrement;
        this.Damage = Damage;
        this.ShootBy = shootBy;
        CanShoot = false;
    }

    public static void DrawAllShots(List<Weapon> weaponList, Hardware hardware)
    {
        foreach(Weapon shot in weaponList)
        {
            /*TODO: Remove the previous position of the shot before drawing the new one*/
            hardware.DrawSprite(shot.SpriteSheet, shot.X, shot.Y, shot.SpriteX, shot.SpriteY, shot.SpriteWidth, shot.SpriteHeight);
            shot.X += shot.XIncrement;
            shot.Y += shot.YIncrement;
        }
    }

    

}

