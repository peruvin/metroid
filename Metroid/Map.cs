using System.Collections.Generic;
using System.IO;
using System;

class Map
{
    public string FileNamer { get; set; }

    public Map() 
    {
        FileNamer = "dat/map.dat";
    }

    public void WriteMap()
    {
        try
        {

            /*
             A:1=0,0:2=1,0:3=0,1;
             A is the id of the CompleteRoom
             The random character that appear are separators
             The numbers in front of the equals sign are the id's of the SquareRooms that compose the CompleteRoom
             The numbers separated by commas are the Coordinates of the SquareRoom in the CompleteRoom
            */
            StreamWriter file = File.CreateText(FileNamer);

            file.WriteLine("A#1=0,0:2=1,0:3=0,1");

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
        try
        {
            StreamReader file = new StreamReader(File.Open(FileNamer, FileMode.Open));
            string line;

            string infoSquareRooms;
            string xycoordinates;

            string CompleteRoomId;
            string SquareRoomId;
            int posXInCompleteRoom;
            int posYInCompleteRoom;


            do
            {
                line = file.ReadLine();
                if(line!=null)
                {

                    CompleteRoomId = line.Split('#')[0];
                    allRooms.Add(new CompleteRoom(CompleteRoomId));
                    infoSquareRooms =line.Split('#')[1];
                    
                    foreach(string squareroominfo in infoSquareRooms.Split(':'))
                    {
                        SquareRoomId = squareroominfo.Split('=')[0];

                        xycoordinates = squareroominfo.Split('=')[1];

                        posXInCompleteRoom = Int32.Parse(xycoordinates.Split(',')[0]);
                        posYInCompleteRoom = Int32.Parse(xycoordinates.Split(',')[1]);

                        allRooms[allRooms.Count-1].AddSquareRoom( SquareRoomId, posXInCompleteRoom, posYInCompleteRoom);
                    }
                    

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

