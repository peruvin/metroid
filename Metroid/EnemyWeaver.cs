
class EnemyWeaver : Enemy
{
    public EnemyWeaver(short X, short Y):base(X, Y,new Image("img/weaver.png", 135, 124))
    {
        /*Uncompleted Coordinates*/
        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.LEFT] = new int[] { 10 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.LEFT] = new int[] { 10 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.RIGHT] = new int[] { 0 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.RIGHT] = new int[] { 0 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.STILL_LEFT] = new int[] { 0 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.STILL_LEFT] = new int[] { 0 };

        SpriteXCoordinates[(int)MovableSprite.SpriteMovement.STILL_RIGHT] = new int[] { 0 };
        SpriteYCoordinates[(int)MovableSprite.SpriteMovement.STILL_RIGHT] = new int[] {  0};
    }
}

