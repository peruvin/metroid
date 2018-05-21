using System.Collections.Generic;

class Map
{
    public List<Room> RoomList;
    public Image SpriteSheet;

    public Map()
    {
        SpriteSheet = new Image("map.png",162,252);
    }
}

