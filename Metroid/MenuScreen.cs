using System;


class MenuScreen : Screen
{
    Image Background;
    Image Menu;
    Image Finger;
    int currPos;
    bool CanGoUp { get; set; }
    bool CanGoDown { get; set; }
    bool CanSelect { get; set; }

    public MenuScreen(Hardware hardware) : base(hardware)
    {
        
        Background = new Image("img/stars.png", 800, 500);
        Menu = new Image("img/menuOptions.png",600,300);
        Finger = new Image("img/finger.png",296,171);
        currPos = 0;
        CanGoUp = false;
        CanGoDown = false;
        CanSelect = false;
    }


    public override void Show()
    {
        Background.MoveTo(0,0);
        Menu.MoveTo(10,100);
        Finger.MoveTo(30,100);
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
                CanSelect = true;
            }

            if (!hardware.IsKeyPressed(Hardware.KEY_SPACE)&&CanSelect)
            {
                OptionSelected = currPos;
            }

            if (hardware.IsKeyPressed(Hardware.KEY_W)) 
            {
                CanGoUp = true;
            }

            if (hardware.IsKeyPressed(Hardware.KEY_S))
            {
                CanGoDown = true;
            }

            if (!hardware.IsKeyPressed(Hardware.KEY_W)&&CanGoUp)
            {
                CanGoUp = false;
                if (currPos == 0)
                {
                    currPos = 3;
                    Finger.MoveTo(30, 300);
                }
                else
                {
                    currPos--;
                    Finger.MoveTo(30, (short)(Finger.Y - 65));
                }
            }

            if (!hardware.IsKeyPressed(Hardware.KEY_S) && CanGoDown)
            {
                CanGoDown = false;
                if (currPos == 3)
                {
                    currPos = 0;
                    Finger.MoveTo(30, 100);
                }
                else
                {
                    currPos++;
                    Finger.MoveTo(30, (short)(Finger.Y + 65));
                }
            }


        }
        while (OptionSelected!=0);
    }
}
