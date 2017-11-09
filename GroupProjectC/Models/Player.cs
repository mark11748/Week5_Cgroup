using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GroupProjectC.Models
{
  public class Player
  {
    private string     _name;

    private int        _id;

    private int        _mapId;
    private int        _roomId;

    private int        _posX;
    private int        _posY;

    private List<Item> _items = new List<Item>();

    //the setter methods for the player are as follows
    public void   SetName  (string name) {_name=name;}
    public string GetName  ()            {return _name;}

    public void   SetId (int id)   {_id=id;}
    public int    GetId ()            {return _id;}

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

    public Player(string name="UNSET", int mapId = 0 , int roomId=0 , int posX=0 , int posY=0, int id=0)
    {
      SetName(name);
      _mapId  = mapId;
      _roomId = roomId;
      _posX   = posX;
      _posY   = posY;
      _items  = new List<Item>();
      _id     = id;
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
        if (this.GetCell().GetN().GetIsExit()) //if exit
        {
          if (this.GetCell().GetN().GetExitAreaId() > -1) //if map/area exit
          { this.SetMapId( this.GetCell().GetN().GetExitAreaId() ); }
          if (this.GetCell().GetN().GetExitId() > -1) //if room exit
          { this.SetRoomId( this.GetCell().GetN().GetExitId() ); }
        }
        else { this.SetPosY(this.GetPosY()-1); }
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
        if (this.GetCell().GetN().GetIsExit()) //if exit
        {
          if (this.GetCell().GetN().GetExitAreaId() > -1) //if map/area exit
          { this.SetMapId( this.GetCell().GetN().GetExitAreaId() ); }
          if (this.GetCell().GetN().GetExitId() > -1) //if room exit
          { this.SetRoomId( this.GetCell().GetN().GetExitId() ); }
        }
        else { this.SetPosY(this.GetPosY()+1); }
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
        if (this.GetCell().GetN().GetIsExit()) //if exit
        {
          if (this.GetCell().GetN().GetExitAreaId() > -1) //if map/area exit
          { this.SetMapId( this.GetCell().GetN().GetExitAreaId() ); }
          if (this.GetCell().GetN().GetExitId() > -1) //if room exit
          { this.SetRoomId( this.GetCell().GetN().GetExitId() ); }
        }
        else { this.SetPosX(this.GetPosX()-1); }
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
        if (this.GetCell().GetN().GetIsExit()) //if exit
        {
          if (this.GetCell().GetN().GetExitAreaId() > -1) //if map/area exit
          { this.SetMapId( this.GetCell().GetN().GetExitAreaId() ); }
          if (this.GetCell().GetN().GetExitId() > -1) //if room exit
          { this.SetRoomId( this.GetCell().GetN().GetExitId() ); }
        }
        else { this.SetPosX(this.GetPosX()+1);}
      }
    }

    public List<Item> GetItems()                  {return this._items;}
    public void SetItems(List<Item> newInventory) {this._items = newInventory;}
    public void AddItem (Item newItem)            {this._items.Add(newItem);}

    public void Save()
    {
     MySqlConnection conn = DB.Connection();
     conn.Open();
     MySqlCommand cmd = conn.CreateCommand();
     cmd.CommandText = @"INSERT INTO players (name,map,room,x,y) VALUES (@name,@map,@room,@x,@y);";

     MySqlParameter name = new MySqlParameter();
     name.ParameterName = "@name";
     name.Value = this.GetName();
     cmd.Parameters.Add(name);

     MySqlParameter map = new MySqlParameter();
     map.ParameterName = "@map";
     map.Value = this.GetMapId();
     cmd.Parameters.Add(map);

     MySqlParameter room = new MySqlParameter();
     room.ParameterName = "@room";
     room.Value = this.GetRoomId();
     cmd.Parameters.Add(room);

     MySqlParameter x = new MySqlParameter();
     x.ParameterName = "@x";
     x.Value = this.GetPosX();
     cmd.Parameters.Add(x);

     MySqlParameter y = new MySqlParameter();
     y.ParameterName = "@y";
     y.Value = this.GetPosY();
     cmd.Parameters.Add(y);

     cmd.ExecuteNonQuery();
     this.SetId((int)cmd.LastInsertedId);

     conn.Close();
     if (conn != null)
     {conn.Dispose();}
    }
    public static Player Find(int id)
    {
      Player currentPlayer = new Player("ERR",-1);

      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = @"SELECT * FROM players WHERE id=@id;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@id";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      MySqlDataReader rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        string name  = rdr.GetString(1);
        int    map   = rdr.GetInt32(2);
        int    room  = rdr.GetInt32(3);
        int    x     = rdr.GetInt32(4);
        int    y     = rdr.GetInt32(5);

        currentPlayer = new Player(name,map,room,x,y);
      }
      conn.Close();
      if (conn != null)
      {conn.Dispose();}

      return currentPlayer;
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = @"DELETE FROM players;ALTER TABLE players AUTO_INCREMENT = 1;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {conn.Dispose();}
    }

  }
}
