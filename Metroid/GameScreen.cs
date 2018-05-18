using System;
using System.Threading;
using System.Collections.Generic;



class GameScreen : Screen
{
    Player character;
    List<Weapon> weaponList;

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
            hardware.UpdateScreen();


            // 2. Move character from keyboard input



            MovePlayer();
            // 3. Move enemies and objects

            // 4. Check collisions and update game state

            // 5. Pause game

            Thread.Sleep(1);

        }
        while (keyPressed != Hardware.KEY_ESC);
    }


    /*This function has to move to the Player class */
    public void MovePlayer()
    {
        if (hardware.IsKeyPressed(Hardware.KEY_A))
        {
            character.MoveTo((short)(character.X - 1), character.Y);

            if (character.IsBallForm)
            {
                character.Animate(MovableSprite.SpriteMovement.BALL_FORM, 15);
            }
            else if (hardware.IsKeyPressed(Hardware.KEY_SHIFT) || hardware.IsKeyPressed(Hardware.KEY_W))
            {
                character.Animate(MovableSprite.SpriteMovement.LEFT_UP_DIAGONAL, 15);
            }
            else
            {
                character.Animate(MovableSprite.SpriteMovement.LEFT, 15);
            }

            character.LastMovement = "LEFT";
            character.IsChrouching = false;
            character.CanConvertToBall = false;
        }

        if (hardware.IsKeyPressed(Hardware.KEY_D))
        {
            character.MoveTo((short)(character.X + 1), character.Y);

            if (character.IsBallForm)
            {
                character.Animate(MovableSprite.SpriteMovement.BALL_FORM, 15);
            }
            else if (hardware.IsKeyPressed(Hardware.KEY_SHIFT) || hardware.IsKeyPressed(Hardware.KEY_W))
            {
                character.Animate(MovableSprite.SpriteMovement.RIGHT_UP_DIAGONAL, 15);
            }
            else
            {
                character.Animate(MovableSprite.SpriteMovement.RIGHT, 15);
            }
            character.LastMovement = "RIGHT";
            character.IsChrouching = false;
            character.CanConvertToBall = false;
        }


        if (hardware.IsKeyPressed(Hardware.KEY_S) && character.IsBallForm == false && character.IsChrouching == false)
        {
            character.IsChrouching = true;
        }

        if ((!hardware.IsKeyPressed(Hardware.KEY_S)) && character.IsChrouching)
        {
            character.CanConvertToBall = true;
        }

        if (hardware.IsKeyPressed(Hardware.KEY_S) && character.IsBallForm == false && character.IsChrouching == true && character.CanConvertToBall == true)
        {
            character.IsChrouching = false;
            character.IsBallForm = true;
        }

        if (hardware.IsKeyPressed(Hardware.KEY_W) && character.IsBallForm == true)
        {
            character.IsChrouching = false;
            character.IsBallForm = false;
            character.CanConvertToBall = false;
        }


        if ((!hardware.IsKeyPressed(Hardware.KEY_D)) && (!hardware.IsKeyPressed(Hardware.KEY_A)))
        {
            if (character.LastMovement == "LEFT")
            {
                if (hardware.IsKeyPressed(Hardware.KEY_W))
                {
                    character.Animate(MovableSprite.SpriteMovement.STILL_LEFT_UP, 100);
                    character.IsChrouching = false;
                    character.CanConvertToBall = false;
                }
                else
                {
                    if (character.IsChrouching)
                    {
                        if (!hardware.IsKeyPressed(Hardware.KEY_SHIFT))
                        {
                            character.Animate(MovableSprite.SpriteMovement.CHROUCH_LEFT, 100);
                        }
                        else
                        {
                            character.Animate(MovableSprite.SpriteMovement.CHROUCH_LEFT_DOWN_DIAGONAL, 100);
                        }
                    }
                    else if (character.IsBallForm)
                        character.Animate(MovableSprite.SpriteMovement.BALL_FORM, 15);
                    else if (hardware.IsKeyPressed(Hardware.KEY_SHIFT))
                        character.Animate(MovableSprite.SpriteMovement.STILL_LEFT_UP_DIAGONAL, 100);
                    else
                        character.Animate(MovableSprite.SpriteMovement.STILL_LEFT, 100);
                }
            }
            else if (character.LastMovement == "RIGHT")
            {
                if (hardware.IsKeyPressed(Hardware.KEY_W))
                {
                    character.Animate(MovableSprite.SpriteMovement.STILL_RIGHT_UP, 100);
                    character.IsChrouching = false;
                    character.CanConvertToBall = false;
                }
                else
                {
                    if (character.IsChrouching)
                    {
                        if (!hardware.IsKeyPressed(Hardware.KEY_SHIFT))
                        {
                            character.Animate(MovableSprite.SpriteMovement.CHROUCH_RIGHT, 100);
                        }
                        else
                        {
                            character.Animate(MovableSprite.SpriteMovement.CHROUCH_RIGHT_DOWN_DIAGONAL, 100);
                        }
                    }
                    else if (character.IsBallForm)
                        character.Animate(MovableSprite.SpriteMovement.BALL_FORM, 15);
                    else if (hardware.IsKeyPressed(Hardware.KEY_SHIFT))
                        character.Animate(MovableSprite.SpriteMovement.STILL_RIGHT_UP_DIAGONAL, 100);
                    else
                        character.Animate(MovableSprite.SpriteMovement.STILL_RIGHT, 100);
                }

            }
            else
            {

            }
        }
    }
}
