using System;
using System.Threading;
using System.Collections.Generic;



class GameScreen : Screen
{


    /*TODO: move the List of weapons and the player to the CompleteRoom class*/
    public Map Mapper { get; set; }
    public List<CompleteRoom> AllRooms { get; set; }
    public int PosCurrentRoom { get; set; }



    public GameScreen(Hardware hardware) : base(hardware)
    {
        AllRooms = new List<CompleteRoom>();
        Mapper = new Map();
        PosCurrentRoom = 0;

    }

    

    
    public override void Show()
    {

        int keyPressed;

        

        /*This lines are to load the map from a file in the map class*/
        
        
        Mapper.WriteMap();
        Mapper.LoadMap(AllRooms);
        AllRooms[PosCurrentRoom].character.MoveTo(20, 20);

        do
        {
            keyPressed = hardware.KeyPressed();

            // 1. Draw everything
            hardware.ClearScreen();


            AllRooms[PosCurrentRoom].DrawPlayer(hardware);
            AllRooms[PosCurrentRoom].DrawAllShots(hardware);
            AllRooms[PosCurrentRoom].DrawAllBlocks(hardware);

            hardware.UpdateScreen();


            // 2. Move character from keyboard input


            AllRooms[PosCurrentRoom].character.FillOldCoordinates();
            AllRooms[PosCurrentRoom].character.MovePlayer(hardware);
            AllRooms[PosCurrentRoom].CreateNewShots(hardware);
            // 3. Move enemies and objects

            // 4. Check collisions and update game state


            /*Temporal fall to test the jumps
             TODO: move it into a function when the CompleteRooms are connected*/

            AllRooms[PosCurrentRoom].PlayerCollisions();

            // 5. Pause game

            Thread.Sleep(1);

        }
        while (keyPressed != Hardware.KEY_ESC);
    }
}
