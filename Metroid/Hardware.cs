using System;
using Tao.Sdl;


class Hardware
{
    short screenWidth;
    short screenHeight;
    short colorDepth;
    IntPtr screen;

    public const int KEY_ESC = Sdl.SDLK_ESCAPE;
    public const int KEY_A = Sdl.SDLK_a;
    public const int KEY_D = Sdl.SDLK_d;
    public const int KEY_W = Sdl.SDLK_w;
    public const int KEY_S = Sdl.SDLK_s;
    public const int KEY_SHIFT = Sdl.SDLK_LSHIFT;
    public const int KEY_M = Sdl.SDLK_m;
    public const int KEY_SPACE = Sdl.SDLK_SPACE;

    public Hardware(short width, short height, short depth, bool fullScreen)
    {
        screenWidth = width;
        screenHeight = height;
        colorDepth = depth;

        int flags = Sdl.SDL_HWSURFACE | Sdl.SDL_DOUBLEBUF | Sdl.SDL_ANYFORMAT;

        if(fullScreen)
        {
            flags = flags | Sdl.SDL_FULLSCREEN;
        }

        Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);

        screen = Sdl.SDL_SetVideoMode(screenWidth, screenHeight, colorDepth, flags);

        Sdl.SDL_Rect rect = new Sdl.SDL_Rect(0,0,screenWidth,screenHeight);

        Sdl.SDL_SetClipRect(screen, ref rect);
    }

    ~Hardware()
    {
        Sdl.SDL_Quit();
    }

    // Draws an image in its current coordinates
    public void DrawImage(Image img)
    {
        Sdl.SDL_Rect source = new Sdl.SDL_Rect(0, 0, img.ImageWidth,
            img.ImageHeight);
        Sdl.SDL_Rect target = new Sdl.SDL_Rect(img.X, img.Y,
            img.ImageWidth, img.ImageHeight);
        Sdl.SDL_BlitSurface(img.ImagePtr, ref source, screen, ref target);
    }

    public void ClearScreen()
    {
        Sdl.SDL_Rect source = new Sdl.SDL_Rect(0, 0, screenWidth, screenHeight);
        Sdl.SDL_FillRect(screen, ref source, 0);
    }

    public void UpdateScreen()
    {
        Sdl.SDL_Flip(screen);
    }

    // Draws a sprite from a sprite sheet in the specified X and Y position of the screen
    // The sprite to be drawn is determined by the x and y coordinates within the image, and the width and height to be cropped
    public void DrawSprite(Image image, short xScreen, short yScreen, short x, short y, short width, short height)
    {
        Sdl.SDL_Rect src = new Sdl.SDL_Rect(x, y, width, height);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect(xScreen, yScreen, width, height);
        Sdl.SDL_BlitSurface(image.ImagePtr, ref src, screen, ref dest);
    }

    // Writes a text in the specified coordinates
    public void WriteText(IntPtr textAsImage, short x, short y)
    {
        Sdl.SDL_Rect src = new Sdl.SDL_Rect(0, 0, screenWidth, screenHeight);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect(x, y, screenWidth, screenHeight);
        Sdl.SDL_BlitSurface(textAsImage, ref src, screen, ref dest);
    }

    public int KeyPressed()
    {
        int pressed = -1;

        Sdl.SDL_PumpEvents();
        Sdl.SDL_Event keyEvent;
        if (Sdl.SDL_PollEvent(out keyEvent) == 1)
        {
            if (keyEvent.type == Sdl.SDL_KEYDOWN)
            {
                pressed = keyEvent.key.keysym.sym;
            }
        }

        return pressed;
    }

    public bool IsKeyPressed(int key)
    {
        bool pressed = false;
        Sdl.SDL_PumpEvents();
        Sdl.SDL_Event evt;
        Sdl.SDL_PollEvent(out evt);
        int numKeys;
        byte[] keys = Sdl.SDL_GetKeyState(out numKeys);
        if (keys[key] == 1)
            pressed = true;
        return pressed;
    }
}

