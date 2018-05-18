using System.Collections.Generic;
using System.IO;

class Room
{
    public string Id { get; set; }

    public Room AdjacentLeft { get; set; }
    public Room AdjacentRight { get; set; }
    public Room AdjacentUp { get; set; }
    public Room AdjacentDown { get; set; }

    public int DoorLeft { get; set; }
    public int DoorRight { get; set; }
    public int DoorUp { get; set; }
    public int DoorDown { get; set; }

    public Image Background { get; set; }
    public List<Block> BlocksList {get; set;}


    public Room(string id)
    {
        /*TODO: Read the room from a file and put the correct filename*/

        Background = new Image("img/s1.png", 300, 212);
        this.Id = id;
        /*
        string line;
        try
        { 
            StreamReader file = File.OpenText(id + ".dat");

            do
            {

            }
            while ();
        }
        catch()
        { }

        */
    }

}

