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
    public List<Door> DoorList { get; set; }
    public List<Enemy> EnemyList { get; set; }
    public List<Upgrade> UpgradeList { get; set; }


    public CompleteRoom(string id)
    {
        this.Id = id;
        RoomList = new List<SquareRoom>();
        BlocksList = new List<Sprite>();
        WeaponList = new List<Weapon>();
        character = new Player();
        DoorList = new List<Door>();
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
            hardware.DrawSprite(shot.SpriteSheet, shot.X, shot.Y, shot.SpriteX, shot.SpriteY, shot.SpriteWidth, shot.SpriteHeight);

        }
    }

    public void DrawAllDoors(Hardware hardware)
    {
        foreach(Door door in DoorList)
        {
            hardware.DrawSprite(door.SpriteSheet, door.X, door.Y, door.SpriteX, door.SpriteY, door.SpriteWidth, door.SpriteHeight);
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

    public InfoNewRoom PlayerDoorCollisions()
    {
        InfoNewRoom infomovingroom = new InfoNewRoom();

        infomovingroom.numRoom = -1;
        infomovingroom.Xplayer = -1;
        infomovingroom.Xplayer = -1;

        foreach(Door door in DoorList)
        {
            if(character.CollidesWith(door))
            {
                infomovingroom.numRoom = door.GoTo;
                infomovingroom.Xplayer = door.XApparitionPlayer;
                infomovingroom.Xplayer = door.YApparitionPlayer;
            }
        }

        return infomovingroom;
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
        character.CreateNewShots(hardware, WeaponList);
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




