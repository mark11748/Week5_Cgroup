using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GroupProjectC.Models
{
  class Player
  {
    private string _name;
    private string _loc;
    private Cell _cell;
    private int[] _XY = int[2];
    private List<Item> _items = new List<Item>;

    //the setter methods for the player are as follows
    public void SetName(string name)
    {_name=name;}
    public void SetLocale(loc)
    {_loc=loc;}
    public void SetPosX(int posX)
    {_id[0]=posX;}
    public void SetPosY(int posY)
    {this.id[1]=posY;}

    public Player(string name="UNSET", string loc="UNSET",int posX=0,int posY=0)
    {
    _name  = name;
    _loc   = loc;
    _cell  = loc.cells[posX][posY]; //NEED CLASS Cell
    _id    = [posX,posY];
    _items = []; //NEED CLASS Item
    }
  }
}
