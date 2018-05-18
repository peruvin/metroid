class MovableSprite : Sprite
{
    const byte TOTAL_MOVEMENTS = 15;
    const byte SPRITE_CHANGE = 15;
    

    public enum SpriteMovement { LEFT, RIGHT, STILL_LEFT, STILL_RIGHT, STILL_LEFT_UP,
                                 STILL_RIGHT_UP, CHROUCH_LEFT, CHROUCH_RIGHT, LEFT_UP_DIAGONAL,
                                 RIGHT_UP_DIAGONAL, STILL_LEFT_UP_DIAGONAL, STILL_RIGHT_UP_DIAGONAL,
                                 CHROUCH_LEFT_DOWN_DIAGONAL, CHROUCH_RIGHT_DOWN_DIAGONAL, BALL_FORM }

    public SpriteMovement CurrentDirection { get; set; }
    byte CurrentSprite { get; set; }
    byte currentSpriteChange;

    public int[][] SpriteXCoordinates = new int[TOTAL_MOVEMENTS][];
    public int[][] SpriteYCoordinates = new int[TOTAL_MOVEMENTS][];

    public MovableSprite(Image SpriteSheet) : base(SpriteSheet)
    {
        CurrentDirection = SpriteMovement.LEFT;
        CurrentSprite = 0;
        currentSpriteChange = 0;
    }

    public void Animate(SpriteMovement movement, byte spriteChange)
    {
        if (movement != CurrentDirection)
        {
            CurrentDirection = movement;
            CurrentSprite = 0;
            currentSpriteChange = 0;
        }
        else
        {
            currentSpriteChange++;
            if (currentSpriteChange >= spriteChange)
            {
                currentSpriteChange = 0;
                CurrentSprite = (byte)((CurrentSprite + 1) % SpriteXCoordinates[(int)CurrentDirection].Length);
            }
        }
        UpdateSpriteCoordinates();
    }

    public void UpdateSpriteCoordinates()
    {
        SpriteX = (short)(SpriteXCoordinates[(int)CurrentDirection][CurrentSprite]);
        SpriteY = (short)(SpriteYCoordinates[(int)CurrentDirection][CurrentSprite]);
    }
}

