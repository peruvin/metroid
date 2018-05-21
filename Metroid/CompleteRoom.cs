using System;
using System.Collections.Generic;
using System.IO;


class CompleteRoom
{

    public string Id { get; set; }


    public List<Block> BlocksList { get; set; }
    public List<Weapon> WeaponList { get; set; }
    public List<SquareRoom> RoomList { get; set; }


    public CompleteRoom(string id)
    {
        this.Id = id;
        RoomList = new List<SquareRoom>();  
    }

    public void LoadCompleteRoom()
    {
        foreach(SquareRoom squareroom in RoomList)
        {
            squareroom.Load();
        }
    }


}




