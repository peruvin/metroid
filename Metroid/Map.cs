using System.Collections.Generic;
using System.IO;
using System;

class Map
{
    public string FileName { get; set; }

    public Map() 
    {
        FileName = "dat/map.dat";
    }

    

    public void WriteMap()
    {
        try
        {

            /*
             A#1=0,0:2=1,0:3=0,1
             A is the id of the CompleteRoom
             The random character that appear are separators
             The numbers in front of the equals sign are the ids of the SquareRooms that compose the CompleteRoom
             The numbers separated by commas are the Coordinates of the SquareRoom in the CompleteRoom
            */

            StreamWriter file = File.CreateText(FileName);

            file.WriteLine("A#1=0,0:2=1,0:3=2,0");
            file.WriteLine("B#4=0,0");

            file.Close();
        }
        catch(IOException e)
        {
            Console.WriteLine("Error: "+e.Message);
        }
    }

    /*This function will replace the CreateRooms function in GameScreen class*/

    public void LoadMap(List<CompleteRoom> allRooms)
    {
        
        string line;

        string infoSquareRooms;
        string xycoordinates;

        string CompleteRoomId;
        string SquareRoomId;
        int posXInCompleteRoom;
        int posYInCompleteRoom;
        short maxposX = 0;

        try
        {
            StreamReader file = new StreamReader(File.Open(FileName, FileMode.Open));
            do
            {
                line = file.ReadLine();
                if(line!=null)
                {

                    CompleteRoomId = line.Split('#')[0];
                    infoSquareRooms =line.Split('#')[1];
                    allRooms.Add(new CompleteRoom(CompleteRoomId));
                    maxposX = 0;
                    foreach (string squareroominfo in infoSquareRooms.Split(':'))
                    {
                        SquareRoomId = squareroominfo.Split('=')[0];

                        xycoordinates = squareroominfo.Split('=')[1];

                        posXInCompleteRoom = Int32.Parse(xycoordinates.Split(',')[0]);
                        posYInCompleteRoom = Int32.Parse(xycoordinates.Split(',')[1]);
                        
                        if(posXInCompleteRoom>maxposX)
                        {
                            maxposX = (short)posXInCompleteRoom;
                        }

                        allRooms[allRooms.Count-1].AddSquareRoom( SquareRoomId, posXInCompleteRoom, posYInCompleteRoom);
                    }
                    allRooms[allRooms.Count - 1].Width =(short)((maxposX+1)*SquareRoom.SQUAREROOM_WIDTH*16);
                    allRooms[allRooms.Count - 1].LoadCompleteRoom();

                }
            }
            while (line!=null);


            file.Close();
        }
        catch(IOException e)
        {
            Console.WriteLine("Error: "+e.Message);
        }
    }
}

