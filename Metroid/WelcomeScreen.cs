/*
 *  * V.0.0.4 17/05/2018 - Javier Saorín Vidal: Added a background image, a
 *   title image and a simple animation.
 */

class WelcomeScreen : Screen
{
    Image title;
    Image background;
    Image[] samusBlink;
    Font font;
    bool exit;
    private int actualImage;
    private int step;

    public WelcomeScreen(Hardware hardware) : base(hardware)
    {
        step = 0;
        actualImage = 0;
        samusBlink = new Image[4];

        samusBlink[0] = new Image("img/s1.png", 300, 212);
        samusBlink[1] = new Image("img/s2.png", 300, 212);
        samusBlink[2] = new Image("img/s3.png", 300, 212);
        samusBlink[3] = new Image("img/s4.png", 300, 212);

        background = new Image("img/stars.png", 800, 500);
        title = new Image("./img/title.png", 300, 120);
        // font = new Font("./font/VeraSansBold.ttf", 22);
    }

    private void AnimateSamus()
    {
        if (actualImage > 3)
            actualImage = 0;

        samusBlink[actualImage].MoveTo(
            (short)((Program.SCREEN_WIDTH / 2) - (title.ImageWidth / 2)), 300);

        hardware.DrawImage(samusBlink[actualImage]);

        if (step > 40)
        {
            actualImage++;
            step = 0;
        }
        step++;      
    }

    public override void Show()
    {
        title.MoveTo(
               (short)((Program.SCREEN_WIDTH / 2) - (title.ImageWidth / 2)),
               50);
        background.MoveTo(0, 0);

        do
        {
            hardware.ClearScreen();
            hardware.DrawImage(background);
            hardware.DrawImage(title);
            AnimateSamus();
            
            hardware.UpdateScreen();

            if (hardware.IsKeyPressed(Hardware.KEY_SPACE))
                exit = true;
        }
        while (!exit);
    }
}

