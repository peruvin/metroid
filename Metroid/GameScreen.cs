using System;
using System.Threading;
using System.Collections.Generic;

public struct InfoNewRoom
{
    public int numRoom;
    public short Xplayer;
    public short Yplayer;

}

class GameScreen : Screen
{


    /*TODO: move the List of weapons and the player to the CompleteRoom class*/
    public Map Mapper { get; set; }
    public List<CompleteRoom> AllRooms { get; set; }
    public int PosCurrentRoom { get; set; }
    public Player character { get; set; }
    InfoNewRoom newroom { get; set; }
    public short OldXmap;



    public GameScreen(Hardware hardware) : base(hardware)
    {
        AllRooms = new List<CompleteRoom>();
        Mapper = new Map();
        PosCurrentRoom = 0;
        character = new Player();

    }


    
    public override void Show()
    {

        int keyPressed;

        

        /*This lines are to load the map from a file in the map class*/
        
        
        Mapper.WriteMap();
        Mapper.LoadMap(AllRooms);
        character.MoveTo(20, 20);

        do
        {
            keyPressed = hardware.KeyPressed();

            // 1. Draw everything
            hardware.ClearScreen();

            
            AllRooms[PosCurrentRoom].DrawPlayer(hardware, character);
            AllRooms[PosCurrentRoom].DrawAllShots(hardware);
            AllRooms[PosCurrentRoom].DrawAllBlocks(hardware);
            AllRooms[PosCurrentRoom].DrawAllEnemies(hardware);
            AllRooms[PosCurrentRoom].DrawAllUpgrades(hardware);
            AllRooms[PosCurrentRoom].DrawAllDoors(hardware);
            /*
            AllRooms[PosCurrentRoom].DrawHud(hardware);
            */
            hardware.UpdateScreen();


            // 2. Move character from keyboard input
            OldXmap = AllRooms[PosCurrentRoom].Xmap;
            
            character.FillOldCoordinates();
            character.MovePlayer(hardware,AllRooms[PosCurrentRoom]);
            AllRooms[PosCurrentRoom].CreateNewShots(hardware, character);
            // 3. Move enemies and objects

            // 4. Check collisions and update game state


            
            
            AllRooms[PosCurrentRoom].PlayerBlockCollisions(character,OldXmap);
            AllRooms[PosCurrentRoom].WeaponBlockCollisions();

            newroom = AllRooms[PosCurrentRoom].PlayerDoorCollisions(character);
            if (newroom.numRoom >= 0)
            {
                /*If the player collides width a door, he will move to the room where the door is pointing*/
                AllRooms[PosCurrentRoom].WeaponList.Clear();
                PosCurrentRoom = newroom.numRoom;
                character.MoveTo(newroom.Xplayer, newroom.Yplayer);

            }

            // 5. Pause game

            Thread.Sleep(1);

        }
        while (keyPressed != Hardware.KEY_ESC);
    }
}
