using System;
using System.Collections.Generic;
using System.IO;


class CompleteRoom
{

    public string Id { get; set; }

    public Player character { get; set; }
    public Hud hud { get; set; }

    public List<Sprite> BlocksList { get; set; }
    public List<Weapon> WeaponList { get; set; }
    public List<SquareRoom> RoomList { get; set; }
    public List<Sprite> DoorList { get; set; }
    public List<Enemy> EnemyList { get; set; }
    public List<Upgrade> UpgradeList { get; set; }


    public CompleteRoom(string id)
    {
        this.Id = id;
        RoomList = new List<SquareRoom>();
        BlocksList = new List<Sprite>();
        WeaponList = new List<Weapon>();
        character = new Player();
        DoorList = new List<Sprite>();
        EnemyList = new List<Enemy>();
        UpgradeList = new List<Upgrade>();
        hud = new Hud();
    }


    /*For now it only draws energy tanks*/
    public void DrawAllUpgrades(Hardware hardware)
    {
        foreach(EnergyTank energytank in UpgradeList)
        {
            hardware.DrawSprite(energytank.SpriteSheet, energytank.X, energytank.Y, energytank.SpriteX, energytank.SpriteY, energytank.SpriteWidth, energytank.SpriteHeight);
            energytank.Animate(MovableSprite.SpriteMovement.STILL_CENTER, 1);
        }
    }

    /*For now it only draws energy weavers*/
    public void DrawAllEnemies(Hardware hardware)
    {
        foreach(EnemyWeaver enemy in EnemyList)
        {
            hardware.DrawSprite(enemy.SpriteSheet, enemy.X, enemy.Y, enemy.SpriteX, enemy.SpriteY, enemy.SpriteWidth, enemy.SpriteHeight);
            enemy.Animate(MovableSprite.SpriteMovement.STILL_LEFT, 1);
        }
    }

    public void DrawAllBlocks(Hardware hardware)
    {
        foreach(Block block in BlocksList)
        {
            hardware.DrawSprite(block.SpriteSheet, block.X, block.Y, block.SpriteX, block.SpriteY, block.SpriteWidth, block.SpriteHeight);
            block.Animate(MovableSprite.SpriteMovement.STILL_CENTER, 1);
        }
    }


    /*TODO:Animate the shot depending on the AimDirection of the Player*/
    public void DrawAllShots(Hardware hardware)
    {
        foreach (Weapon shot in WeaponList)
        {
            shot.MoveShot();
        }
    }

    public void DrawHud(Hardware hardware)
    {
        hud.Animate(MovableSprite.SpriteMovement.STILL_CENTER, 1);
        hardware.DrawSprite(hud.SpriteSheet, hud.X, hud.Y, hud.SpriteX, hud.SpriteY, hud.SpriteWidth, hud.SpriteHeight);
       

    }

    public void DrawPlayer(Hardware hardware)
    {
        hardware.DrawSprite(character.SpriteSheet, character.X, character.Y, character.SpriteX, character.SpriteY, character.SpriteWidth, character.SpriteHeight);

    }

    public void WeaponBlockCollisions()
    {
        foreach (Weapon shot in WeaponList)
        {
            foreach (Block block in BlocksList)
            {
                if (shot.CollidesWith(block))
                {
                    shot.IsVisible = false;
                }
            }
        }
    }

    public int PlayerDoorCollisions()
    {
        int numreturn = -1;
        foreach(Door door in DoorList)
        {
            if(character.CollidesWith(door))
            {
                numreturn = door.GoTo;
            }
        }
        return numreturn;
    }

    public void PlayerBlockCollisions()
    {
        character.IsFalling = true;

        foreach (Block block in BlocksList)
        {
            if (character.IsOver(block))
            {
                character.MoveTo(character.X, (short)(block.Y - character.SpriteHeight));
                character.IsFalling = false;
            }
        }

        if (character.CollidesWith(BlocksList))
        {
            character.X = character.OldX;
            character.Y = character.OldY;
        }
    }

    public void CreateNewShots(Hardware hardware)
    {
        /*For now, it always creates a BasicBeam shot, later, I will add another weapon parameter to create shots from that specific class*/

        if (hardware.IsKeyPressed(Hardware.KEY_M))
        {
            character.PrimaryWeapon.CanShoot = true;
        }

        if (!hardware.IsKeyPressed(Hardware.KEY_M) && character.PrimaryWeapon.CanShoot)
        {
            character.PrimaryWeapon.CanShoot = false;
            BasicBeam tempbeam;

            switch (character.AimDirection)
            {
                /*TODO: Starting X and Y will change slightly their positions*/
                case "LEFT":
                    tempbeam = new BasicBeam(-1, 0, character);
                    tempbeam.X = (short)character.X;
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
                case "CHROUCH_RIGHT_DOWN_DIAGONAL":
                    tempbeam = new BasicBeam(1, 1, character);
                    tempbeam.X = (short)(character.X);
                    tempbeam.Y = (short)(character.Y);
                    break;
                case "UP":
                    tempbeam = new BasicBeam(0, -1, character);
                    tempbeam.X = (short)(character.X);
                    tempbeam.Y = (short)(character.Y);
                    break;
                default:
                    tempbeam = new BasicBeam(1, 1, character);
                    break;
            }

            if (tempbeam != null)
            {
                WeaponList.Add(tempbeam);
            }


        }

    }



    public void AddSquareRoom(string IdSquareRoom,int posXInCompleteRoom,int posYInCompleteRoom)
    {
        RoomList.Add(new SquareRoom(this, IdSquareRoom, posXInCompleteRoom, posYInCompleteRoom));
    }

    public void LoadCompleteRoom()
    {
        foreach(SquareRoom squareroom in RoomList)
        {
            squareroom.Load();
        }
    }

}




