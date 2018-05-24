using System;


class MenuScreen : Screen
{
    Image Background;
    Image Menu;
    Image Finger;
    string[] Options;
    bool exit;
    int currPos;

    public MenuScreen(Hardware hardware) : base(hardware)
    {
        
        Background = new Image("img/stars.png", 800, 500);
        Menu = new Image("img/menuOptions.png",600,300);
        Finger = new Image("img/finger.png",296,171);
        exit = false;
        Options = new string[4];
        currPos = 0;
    }


    public override void Show()
    {
        Background.MoveTo(0,0);
        Menu.MoveTo(10,100);
        Finger.MoveTo(30,100);
        Options[0] = "PLAY";
        Options[1] = "CONTROLS";
        Options[2] = "CREDITS";
        Options[3] = "EXIT";
        int OptionSelected=-1;

        do
        {
            hardware.ClearScreen();
            hardware.DrawImage(Background);
            hardware.DrawImage(Menu);
            hardware.DrawImage(Finger);
            hardware.UpdateScreen();

            if (hardware.IsKeyPressed(Hardware.KEY_SPACE))
            {
                OptionSelected = currPos;
            }

            if (hardware.IsKeyPressed(Hardware.KEY_W)) 
            {
                if(currPos==0)
                {
                    currPos = 3;
                    Finger.MoveTo(30, 400);
                }
                else
                {
                    currPos--;
                    Finger.MoveTo(30, (short)(Finger.Y-100));
                }
            }
            else if (hardware.IsKeyPressed(Hardware.KEY_S))
            {
                if (currPos == 3)
                {
                    currPos = 0;
                    Finger.MoveTo(30, 100);
                }
                else
                {
                    currPos++;
                    Finger.MoveTo(30, (short)(Finger.Y + 100));
                }
            }
                
        }
        while (OptionSelected!=0);
    }
}
