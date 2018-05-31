using System;


class MenuScreen : Screen
{
    Image Background;
    Image MenuEsp;
    Image MenuEn;
    Image Finger;
    int currPos;
    bool CanGoUp { get; set; }
    bool CanGoDown { get; set; }
    bool CanSelect { get; set; }

    public MenuScreen(Hardware hardware) : base(hardware)
    {
        
        Background = new Image("img/stars.png", 800, 500);
        MenuEsp = new Image("img/OptionsES.png",600,300);
        MenuEn = new Image("img/OptionsEN.png", 600, 300);
        Finger = new Image("img/finger.png",296,171);
        currPos = 0;
        CanGoUp = false;
        CanGoDown = false;
        CanSelect = false;
        
    }


    public override void Show()
    {
        Background.MoveTo(0,0);
        MenuEn.MoveTo(50,105);
        MenuEsp.MoveTo(50, 105);
        Finger.MoveTo(5,100);
        int OptionSelected=-1;
        string lang = "EN";
        do
        {
            
            do
            {
                OptionSelected = -1;
                hardware.ClearScreen();
                hardware.DrawImage(Background);
                if (lang == "EN")
                {
                    hardware.DrawImage(MenuEn);
                }
                else if (lang == "ES")
                {
                    hardware.DrawImage(MenuEsp);
                }


                hardware.DrawImage(Finger);
                hardware.UpdateScreen();

                if (hardware.IsKeyPressed(Hardware.KEY_SPACE))
                {
                    CanSelect = true;
                }

                if (!hardware.IsKeyPressed(Hardware.KEY_SPACE) && CanSelect)
                {
                    OptionSelected = currPos;
                    CanSelect = false;
                }



                if (hardware.IsKeyPressed(Hardware.KEY_W))
                {
                    CanGoUp = true;
                }

                if (hardware.IsKeyPressed(Hardware.KEY_S))
                {
                    CanGoDown = true;
                }

                if (!hardware.IsKeyPressed(Hardware.KEY_W) && CanGoUp)
                {
                    CanGoUp = false;
                    if (currPos == 0)
                    {
                        currPos = 4;
                        Finger.MoveTo(5, 200);
                    }
                    else
                    {
                        currPos--;
                        Finger.MoveTo(5, (short)(Finger.Y - 25));
                    }
                }

                if (!hardware.IsKeyPressed(Hardware.KEY_S) && CanGoDown)
                {
                    CanGoDown = false;
                    if (currPos == 4)
                    {
                        currPos = 0;
                        Finger.MoveTo(5, 100);
                    }
                    else
                    {
                        currPos++;
                        Finger.MoveTo(5, (short)(Finger.Y + 25));
                    }
                }


            }
            while (OptionSelected == -1);

            /*Switch case here, to call different methods*/

            switch (OptionSelected)
            {
                case 1:
                    if(lang=="ES")
                    {
                        lang = "EN";
                    }
                    else if(lang=="EN")
                    {
                        lang = "ES";
                    }
                    
                    break;
                default:
                    break;
                    
            }
        } while (OptionSelected!=0);
        
            
    }
}
