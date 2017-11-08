using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GroupProjectC.Models
{
  // THIS CLASS HOLDS THE ENTIRE GAME world
  public static class GAMEBOARD
  {
    //This property holds all defined rooms/locales with the first index as a way of seperating
    //maps and the second index as a way of identifying the room in the identified map
    private static List<List<Locale>> _roomList; // [area][room][posX][posY]
    private static int _area;

    public static List<List<Locale>> GetWorld(){return _roomList;}                /*returns a list of locale lists*/
    public static List<Locale> GetCurentArea(){return _roomList[_area];} /*returns a locale list*/
    public static void SetCurentArea(int newArea){_area = newArea;}          /*sets the area to apply/test coordinates*/

    public static int  AddMapToWorld (List<Locale> map)
    {_roomList.Add(map); return GetWorld().IndexOf(map);}
    public static int  AddAreaToMap (Locale room, int area)
    {_roomList[area].Add(room); return _roomList[area].IndexOf(room);}
  }
}
