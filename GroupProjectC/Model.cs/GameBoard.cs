using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GroupProjectC.Models
{
  // THIS CLASS HOLDS THE CELLS AND AREA-NAME
  class Locale
  {
    private string _name;
    private List<List<Cell[]>> _cells = new List<List<Cell[]>>();

    public string GetName()
    {return this._name;}
    public void SetName(string name)
    {this._name=name;}

    public List<List<Cell[]>> GetCells()
    {return this._cells;}
    public void SetCells(List<List<Cell[]>> cells)
    {this._cells=cells;}

    public Locale (string name="[PLACEHOLDER_Rm_NAME]", List<List<Cell[]>> cells)
     {
       _name  = name;
       _cells = cells;
       //this.events = events;
    }
    //WORKS BUT BE CAREFUL OF OBJECTS ASSIGNED BY REF. RATHER THAN VAL. :: use .copyOf() if avalible
    public void cellDebug()
    {
      //If room has been defined/not empty
      if (this.GetCells().Count>0)
      {
        //this moves through the outter (x-axis) array of arrays
        foreach(List<Cell[]> x in this.GetCells())
        {
          int X_index = this.GetCells().IndexOf(x);
          //this moves through the inner (y-axis) arrays
          foreach(Cell y in x)
          {
            int Y_index = this.GetCells().IndexOf(y);
            //if cell has coordinates in name already remove them
            //set yName to sub-string yName[0] to "[" index
            if ( (y.GetName().Contains("[")) )
            { y.SetName(y.GetName().Substring(0,y.GetName().IndexOf("["))); }
            //if cell does not have coordinates in name already add them
            else
            { y.SetName(cell_Y.name + "[" + this.GetCells().IndexOf(x) + "," + this.GetCells().IndexOf(y) + "]"); }
          }
        }
      }
    }

      public addNorthRow()
      {
        //for each X position add a space to the start of the corresponding Y array
        foreach(List<Cell> cells in this.GetCells())
        {cell.Insert(0,new Cell());}
      }
      public addSouthRow() {
      //for each X position add a space to the end of the corresponding Y array
      foreach(List<Cell> cells in this.GetCells())
      {cells.Add(new Cell());}
      }
      public addWestRow() {
      //how long to make the row
      int width  = this.GetCells()[0].Count;
      //the x array grows from the left;
      this.GetCells()[0].Insert(0,new List<Cell>(width));
      foreach(Cell cell in this.GetCells()[0]){cell=undefined;});
      }
      public addEastRow() {
      //how long to make the row
      int width  = this.GetCells()[0].Count;
      var newMax = this.cells.length;
      //the x array grows from the right;
      this.GetCells().Add(new List<Cell>(width));
      this.cells[newMax].forEach(function(cell){cell=undefined;});
      }

  function Cell (name        = "[PLACEHOLDER_Cl_NAME]",
                 description = "[PLACEHOLDER_DESC]",
                 rm          = "[PLACEHOLDER_Rm_NAME]",
                 n,s,e,w,
                 items       = [])
  {
    //what's it's name?
    this.name=name;
    //room description goes bellow:
    this.description=description;
    this.rmName=rm;
    //is the direction passable? uses border object
    this.n=n;
    this.s=s;
    this.e=e;
    this.w=w;
    //does it have items?
    this.items=items;
  }
  //TESTED COPY FUNCTION
  Cell.prototype.copyOf = function(){
    var newCell = new Cell (this.name,this.description,this.rmName,
                            this.n.copyOf(),this.s.copyOf(),this.e.copyOf(),this.w.copyOf(),[]);
    return newCell;
  }
  //NEED TO TEST COPY FUNCTION
  Cell.prototype.copyOfItems = function(){
    var newCell = new Cell (this.name,this.description,this.rmName,
                            this.n.copyOf(),this.s.copyOf(),this.e.copyOf(),this.w.copyOf(),[]);
    //if old cell has items push them onto the items array of new cell
    if (this.items.length) {
      this.items.forEach(function(item){newCell.items.push(item.copyOf())});
    }
    return newCell;
  }

  function Border(edgeType) {
    this.type = edgeType;  //CAN BE: wall(0)/open(1)/door(2)
    //this.isOpen   = false; OUT OF SCOPE -- too much work
    this.isLocked = false;
    this.isExit   = false;
    this.nextRoom = [];
    this.lockID   = -1;
  }
