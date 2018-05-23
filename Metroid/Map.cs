using System.Collections.Generic;
using System.IO;
using System;

class Map
{
    public List<SquareRoom> RoomList;
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
            file.Write("A-1-0-0");
            file.Write("A-2-1-0");
            file.Write("A-3-0-1");


            file.Write(";");
            file.Close();
        }
        catch(IOException e)
        {
            Console.WriteLine("Error: "+e.Message);
        }
    }

    public void LoadMap()
    {
        try
        {
            BinaryReader file = new BinaryReader(File.Open(FileName, FileMode.Open));
            string roominfo;

            do
            {
                roominfo = file.ReadString();

                if(roominfo!=";")
                {
                    string[] infoparsed = roominfo.Split('-');
                    
                }
            } while (roominfo != ";");

            file.Close();
        }
        catch(IOException e)
        {
            Console.WriteLine("Error: "+e.Message);
        }
    }
}

