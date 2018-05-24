using System;
using System.IO;



class SquareRoom
{
    /*TODO: Increase the SQUAREROOM_HEIGHT and SQUAREROOM_WIDTH and draw bigger SquareRooms in the .dat files*/

    public const short SQUAREROOM_HEIGHT = 10;
    public const short SQUAREROOM_WIDTH = 10;

    public int PositionXInCompleteRoom { get; set; }
    public int PositionYInCompleteRoom { get; set; }

    public string IdSquareRoom { get; set; }
    public CompleteRoom SourceRoom { get; set; }

    /*Images to show in the map*/

    public Image MapTile { get; set; }
    public Image MapTileGrabbed { get; set; }

    public SquareRoom(CompleteRoom SourceRoom, string IdSquareRoom, int PositionXInCompleteRoom, int PositionYInCompleteRoom)
    {
        this.SourceRoom = SourceRoom;
        this.IdSquareRoom = IdSquareRoom;
        this.PositionXInCompleteRoom= PositionXInCompleteRoom;
        this.PositionYInCompleteRoom =PositionYInCompleteRoom;
    }

    

    public void Load()
    {
        
        string line;
        try
        {
            StreamReader file = File.OpenText("maps/" + IdSquareRoom + ".dat");
            int numrow = 0;
            int numcolumn = 0;

            do
            {
                line = file.ReadLine();
                if(line!=null)
                {
                    numcolumn = 0;
                    foreach(char roomElement in line)
                    {
                        switch(roomElement)
                        {
                            case 'B':
                                SourceRoom.BlocksList.Add(new Block(
                                        (short)((16 * PositionXInCompleteRoom * SQUAREROOM_HEIGHT) + (numcolumn*16)), 
                                        (short)((16 * PositionYInCompleteRoom * SQUAREROOM_WIDTH) + (numrow*16))));
                                break;
                            default:
                                break;
                        }
                        numcolumn++;
                    }
                    numrow++;
                    
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
