using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GroupProjectC.Models
{
  // THIS CLASS HOLDS THE CELLS AND AREA-NAME
  public class Locale
  {
    private string _name;
    private int    _id=-1;
    private List<List<Cell>> _cells;

    public Locale (string name="[PLACEHOLDER_Rm_NAME]")
    { _name  = name; }
    public void AddToWorld(int area=0){_id = GAMEBOARD.AddAreaToMap(this,area);}
    public int  GetId(){return _id;}

    public void SetName(string name) {this._name=name;}
    public string GetName()          {return this._name;}

    public void SetCells(List<List<Cell>> cells) {this._cells=cells;}
    public List<List<Cell>> GetCells()           {return this._cells;}


    //WORKS BUT BE CAREFUL OF OBJECTS ASSIGNED BY REF. RATHER THAN VAL. :: use .copyOf() if avalible
    public void cellDebug()
    {
      //If room has been defined/not empty
      if (this.GetCells().Count>0)
      {
        //this moves through the outter (x-axis) array of arrays
        foreach(List<Cell> x in this.GetCells())
        {
          int X_index = this.GetCells().IndexOf(x);
          //this moves through the inner (y-axis) arrays
          foreach(Cell y in x)
          {
            int Y_index = x.IndexOf(y);
            //if cell has coordinates in name already remove them
            //set yName to sub-string yName[0] to "[" index
            if ( (y.GetName().Contains("[")) )
            { y.SetName(y.GetName().Substring(0,y.GetName().IndexOf("["))); }
            //if cell does not have coordinates in name already add them
            else
            { y.SetName(y.GetName() + "[" + this.GetCells().IndexOf(x) + "," + x.IndexOf(y) + "]"); }
          }
        }
      }
    }


    public void addNorthRow()
    {
      //for each X position add a space to the start of the corresponding Y array
      foreach(List<Cell> cells in this.GetCells())
      {cells.Insert(0,new Cell());}
    }
    
    public void addSouthRow()
    {
    //for each X position add a space to the end of the corresponding Y array
    foreach(List<Cell> cells in this.GetCells())
    {cells.Add(new Cell());}
    }

    public void addWestRow()
    {
    //how long to make the row
    int width  = this.GetCells()[0].Count;
    //the x array grows from the left;
    this.GetCells().Insert(0,new List<Cell>(width));
    }

    public void addEastRow()
    {
    //how long to make the row
    int width  = this.GetCells()[0].Count;
    //the x array grows from the right;
    this.GetCells().Add(new List<Cell>(width));
    }
  }
}
