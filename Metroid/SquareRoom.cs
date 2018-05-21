using System;
using System.IO;



class SquareRoom
{
    
    
    public const short SQUAREROOM_HEIGHT = 250;
    public const short SQUAREROOM_WIDTH = 250;

    public int PositionXInCompleteRoom { get; set; }
    public int PositionYInCompleteRoom { get; set; }

    public string IdSquareRoom { get; set; }
    public CompleteRoom SourceRoom { get; set; }


    public int DoorLeft { get; set; }
    public int DoorRight { get; set; }
    public int DoorUp { get; set; }
    public int DoorDown { get; set; }

    /*Images to show in the map*/

    public Image MapTile { get; set; }
    public Image MapTileGrabbed { get; set; }

    public SquareRoom(CompleteRoom sourceRoom, string IdSquareRoom)
    {
        this.SourceRoom = sourceRoom;
        this.IdSquareRoom = IdSquareRoom;
    }

    public void Load()
    {
        
        string line;
        try
        { 

            /*Change this to a binary reader*/
            StreamReader file = File.OpenText("maps/" + IdSquareRoom + ".dat");
            int numrow = 0;
            int numcolumn = 0;

            do
            {
                line = file.ReadLine();
                if(line!=null)
                {
                    foreach(char roomElement in line)
                    {
                        switch(roomElement)
                        {
                            case 'B':
                                SourceRoom.BlocksList.Add(new Block(
                                        (short)((PositionXInCompleteRoom * SquareRoom.SQUAREROOM_HEIGHT) + numcolumn), 
                                        (short)((PositionYInCompleteRoom *SQUAREROOM_WIDTH) + numrow)));
                                break;
                            default:
                                break;
                        }
                    }
                    numrow++;
                    numcolumn++;
                }
            }
            while (line!=null);
            file.Close();
        }
        catch(IOException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

    }
}
