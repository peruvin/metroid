using System.Collections.Generic;

class Map
{
    public List<Room> RoomList;
    public Image SpriteSheet;

    public Map()
    {
        SpriteSheet = new global::Image("map.png",162,252);
    }
}

