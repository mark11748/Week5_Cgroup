using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GroupProjectC.Models
{
  public class Player
  {
    private string _name;
    private int    _map;
    private int    _locId;
    private Locale _loc;
    private Cell   _cell;
    private int [] _XY = new int[2];
    private List<Item> _items = new List<Item>();

    //the setter methods for the player are as follows
    public string GetName()
    {return _name;}
    public void SetName(string name)
    {_name=name;}
    public Locale GetLocale()
    {return _loc;}
    public void SetLocale(Locale loc)
    {_loc=loc;}
    public void SetLocale(int map = 0, int locId = 0)
    {_loc=GAMEBOARD.GetWorld()[map][locId];}
    public int GetLocaleId()
    {return _locId;}
    public void SetLocale(int locId)
    {_locId=locId;}
    public void SetPosX(int posX)
    {_XY[0]=posX;}
    public void SetPosY(int posY)
    {_XY[1]=posY;}

    public Player(string name="UNSET" , int map = 0 , int locId=0 , int posX=0 , int posY=0)
    {
      _name  = name;
      _locId = locId;
      // _loc   = ;
      _cell  = GAMEBOARD.GetWorld()[map][locId].GetCells()[posX][posY]; //
      _XY    = new int[]  {posX,posY};//
      _items = new List<Item>();      //
    }
  }
}
