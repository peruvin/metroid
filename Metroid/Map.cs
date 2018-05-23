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
                A-1-0-0 
             
                First char("A"):The id of the CompleteRoom 
                First number("1"): The id of the SquareRoom
                Second number("0"): The x position of the SquareRoom in the CompleteRoom
                Third number("0"): The y position of the SquareRoom in the CompleteRoom
             */
            BinaryWriter file = new BinaryWriter(File.Open(FileName,FileMode.Create));
            file.Write("A");

            file.Write("1");
            file.Write(0);
            file.Write(0);
            file.Write("2");
            file.Write(1);
            file.Write(0);
            file.Write("3");
            file.Write(0);
            file.Write(1);

            file.Write(".");

            file.Write(";");
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
            BinaryReader file = new BinaryReader(File.Open(FileName, FileMode.Open));

            string CompleteRoomId;
            string SquareRoomId;
            int posXInCompleteRoom;
            int posYInCompleteRoom;

            do
            {
                CompleteRoomId = file.ReadString();

                if(CompleteRoomId != ";")
                {
                    allRooms.Add(new CompleteRoom(CompleteRoomId));
                    CompleteRoomId = file.ReadString();
                    do
                    {
                        SquareRoomId = file.ReadString();
                        if(SquareRoomId!=".")
                        {
                            posXInCompleteRoom = file.ReadInt32();
                            posYInCompleteRoom = file.ReadInt32();
                            allRooms[allRooms.Count-1].AddSquareRoom(SquareRoomId, posXInCompleteRoom, posYInCompleteRoom);
                        }
                    }
                    while (SquareRoomId != ".");
                }
            } while (CompleteRoomId != ";");

            file.Close();
        }
        catch(IOException e)
        {
            Console.WriteLine("Error: "+e.Message);
        }
    }
}

