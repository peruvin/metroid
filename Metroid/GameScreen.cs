using System;
using System.Threading;
using System.Collections.Generic;



class GameScreen : Screen
{


    /*TODO: move the List of weapons and the player to the CompleteRoom class*/
    public Player character { get; set; }
    public List<Weapon> weaponList { get; set; }
    public List<CompleteRoom> AllRooms { get; set; }
    public int PosCurrentRoom { get; set; }



    public GameScreen(Hardware hardware) : base(hardware)
    {
        character = new Player();
        weaponList = new List<Weapon>();
        AllRooms = new List<CompleteRoom>();
        PosCurrentRoom = 0;

    }

    public void CreateRooms()
    {
        AllRooms.Add(new CompleteRoom("A"));
        AllRooms[0].AddSquareRoom("1",0,0);
        
        AllRooms[0].AddSquareRoom("2",1,0);
        AllRooms[0].AddSquareRoom("3",0,1);
        
        AllRooms[0].LoadCompleteRoom();
    }

    public override void Show()
    {

        int keyPressed;
        CreateRooms();

        character.MoveTo(20,20);

        do
        {
            keyPressed = hardware.KeyPressed();

            // 1. Draw everything
            hardware.ClearScreen();
            hardware.DrawSprite(character.SpriteSheet, character.X, character.Y, character.SpriteX, character.SpriteY, character.SpriteWidth, character.SpriteHeight);
            Weapon.DrawAllShots(weaponList, hardware);

            /*Temporal map to test the collisions
             TODO: move to a function with bigger rooms*/

            foreach(Block block in AllRooms[0].BlocksList)
            {
                hardware.DrawSprite(block.SpriteSheet, block.X, block.Y, block.SpriteX, block.SpriteY, block.SpriteWidth, block.SpriteHeight);
                block.Animate(MovableSprite.SpriteMovement.STILL_CENTER, 1);
            }

            if (character.IsFalling && character.Y == (short)(Program.SCREEN_HEIGHT - character.SpriteHeight))
            {
                    character.MoveTo(character.X, (short)(Program.SCREEN_HEIGHT - character.SpriteHeight));
                    character.IsFalling = false;
            }

            hardware.UpdateScreen();


            // 2. Move character from keyboard input


            character.FillOldCoordinates();


            character.MovePlayer(hardware);
            character.CreateNewShots(hardware,weaponList);
            // 3. Move enemies and objects

            // 4. Check collisions and update game state


            /*Temporal fall to test the jumps
             TODO: move it into a function and fix the problem with the jump*/
            character.IsFalling = true;

            character.IsFalling = !character.IsJumping;

            foreach (Block block in AllRooms[0].BlocksList)
            {
                if (character.IsOver(block))
                {
                    character.MoveTo(character.X, (short)(block.Y - character.SpriteHeight));
                    character.IsFalling = false;
                    character.IsJumping = false;
                }
            }

            if (character.IsFalling && character.Y == (short)(Program.SCREEN_HEIGHT - character.SpriteHeight))
            {
                character.MoveTo(character.X, (short)(Program.SCREEN_HEIGHT - character.SpriteHeight));
                character.IsFalling = false;
                character.IsJumping = false;
            }




            if (character.CollidesWith(AllRooms[0].BlocksList))
            {
                character.X = character.OldX;
                character.Y = character.OldY;
            }

            // 5. Pause game

            Thread.Sleep(1);

        }
        while (keyPressed != Hardware.KEY_ESC);
    }
}
