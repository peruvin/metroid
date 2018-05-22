using System;
using System.Collections.Generic;
using System.IO;


class CompleteRoom
{

    public string Id { get; set; }


    public List<Sprite> BlocksList { get; set; }
    public List<Weapon> WeaponList { get; set; }
    public List<SquareRoom> RoomList { get; set; }


    public CompleteRoom(string id)
    {
        this.Id = id;
        RoomList = new List<SquareRoom>();
        BlocksList = new List<Sprite>();
    }

    public void AddSquareRoom(string IdSquareRoom,int posXInCompleteRoom,int posYInCompleteRoom)
    {
        RoomList.Add(new SquareRoom(this, IdSquareRoom, posXInCompleteRoom, posYInCompleteRoom));
    }

    public void LoadCompleteRoom()
    {
        foreach(SquareRoom squareroom in RoomList)
        {
            squareroom.Load();
        }
    }

}




