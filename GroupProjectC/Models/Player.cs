using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GroupProjectC.Models
{
  public class Player
  {
    private string     _name;
    private int        _mapId;
    private int        _roomId;
    private int        _posX;
    private int        _posY;
    private List<Item> _items = new List<Item>();

    //the setter methods for the player are as follows
    public void   SetName  (string name) {_name=name;}
    public string GetName  ()            {return _name;}

    public void   SetMapId (int mapId)   {_mapId=mapId;}
    public int    GetMapId ()            {return _mapId;}
    public void   SetRoomId(int roomId)  {_roomId=roomId;}
    public int    GetRoomId()            {return _roomId;}

    public void   SetPosX  (int posX)    {_posX=posX;}
    public void   SetPosY  (int posY)    {_posY=posY;}
    public int[]  GetPos   ()            {return new int[]{GetPosX(),GetPosY()};}
    public int    GetPosX  ()            {return _posX;}
    public int    GetPosY  ()            {return _posY;}

    public Locale GetRoom() { return GAMEBOARD.GetWorld()[this.GetMapId()][this.GetRoomId()]; }
    public Cell   GetCell() { return this.GetRoom().GetCells()[this.GetPosX()][this.GetPosY()]; }

    public Player(string name="UNSET" , int mapId = 0 , int roomId=0 , int posX=0 , int posY=0)
    {
      SetName(name);
      _mapId  = mapId;
      _roomId = roomId;
      _posX   = posX;
      _posY   = posY;
      _items  = new List<Item>();
    }

    public void MoveN()
    {
      if  (
            (this.GetPosY()-1) >= 0                                                     && //is cell out of bounds?
             this.GetRoom().GetCells()[this.GetPosX()][this.GetPosY()-1].IsAccessable() && //is cell useable?
             this.GetCell().GetN().GetEdgeType() >0                                     && //is there a wall in the way?
            !this.GetCell().GetN().GetIsLocked()                                           //is cell currently unlocked?
          )
      {
        this.SetPosY(this.GetPosY()-1);
      }
    }
    public void MoveS()
    {
      if  (
            (this.GetPosY()+1) < this.GetRoom().GetCells()[this.GetPosX()].Count                   && //is cell out of bounds?
             this.GetRoom().GetCells()[this.GetPosX()][this.GetPosY()+1].IsAccessable() && //is cell useable?
             this.GetCell().GetS().GetEdgeType() >0                                     && //is there a wall in the way?
            !this.GetCell().GetS().GetIsLocked()                                           //is cell currently unlocked?
          )
      {
        this.SetPosY(this.GetPosY()+1);
      }
    }
    public void MoveW()
    {
      if  (
            (this.GetPosX()-1) >= 0                                                     && //is cell out of bounds?
             this.GetRoom().GetCells()[this.GetPosX()-1][this.GetPosY()].IsAccessable() && //is cell useable?
             this.GetCell().GetW().GetEdgeType() >0                                     && //is there a wall in the way?
            !this.GetCell().GetW().GetIsLocked()                                           //is cell currently unlocked?
          )
      {
        this.SetPosX(this.GetPosX()-1);
      }
    }
    public void MoveE()
    {
      if  (
            (this.GetPosX()+1) < this.GetRoom().GetCells().Count                        && //is cell out of bounds?
             this.GetRoom().GetCells()[this.GetPosX()+1][this.GetPosY()].IsAccessable() && //is cell useable?
             this.GetCell().GetW().GetEdgeType() >0                                     && //is there a wall in the way?
            !this.GetCell().GetW().GetIsLocked()                                           //is cell currently unlocked?
          )
      {
        this.SetPosX(this.GetPosX()+1);
      }
    }
  }
}
