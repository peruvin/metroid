using System;
using System.Threading;
using System.Collections.Generic;



class GameScreen : Screen
{
    public Player character { get; set; }
    public List<Weapon> weaponList { get; set; }
    public List<Room> roomList { get; set; }

    public GameScreen(Hardware hardware) : base(hardware)
    {
        character = new Player();
        weaponList = new List<Weapon>();

    }

    public override void Show()
    {

        int keyPressed;

        do
        {
            keyPressed = hardware.KeyPressed();

            // 1. Draw everything
            hardware.ClearScreen();
            hardware.DrawSprite(character.SpriteSheet, character.X, character.Y, character.SpriteX, character.SpriteY, character.SpriteWidth, character.SpriteHeight);
            Weapon.DrawAllShots(weaponList, hardware);

            hardware.UpdateScreen();


            // 2. Move character from keyboard input


            
            character.MovePlayer(hardware);
            character.CreateNewShots(hardware,weaponList);
            // 3. Move enemies and objects

            // 4. Check collisions and update game state

            // 5. Pause game

            Thread.Sleep(1);

        }
        while (keyPressed != Hardware.KEY_ESC);
    }
}
