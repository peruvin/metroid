using System;


class Program
{

    public const short SCREEN_WIDTH = 800;
    public const short SCREEN_HEIGHT = 500;

    public static void Start()
    {
        Hardware hardware = new Hardware(800, 600, 24, false);

        WelcomeScreen welcome = new WelcomeScreen(hardware);
        CreditsScreen credits = new CreditsScreen(hardware);
        MenuScreen menu = new MenuScreen(hardware);
        GameScreen game = new GameScreen(hardware);

        welcome.Show();
        menu.Show();
        game.Show();
        credits.Show();

        
    }

    static void Main(string[] args)
    {
        Start();

        /*
         * Controls:
         * A - move left
         * D - move right
         * S - chrouch,turn into ball
         * W - aim up
         * SPACE - jump
         * SHIFT - aim diagonally
         * M - shoot
         * ESC - exit
         * 
         * Check @Hardware class to see all keys availiable
         */
    }


}

