using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GroupProjectC.Models
{
  public class Cell
  {
    //what's it's name?
    private string _name;
    //room description goes bellow:
    private string _description;
    private string _rmName;
    //is the direction passable? uses border object
    private Border _n;
    private Border _s;
    private Border _e;
    private Border _w;
    //does it have items?
    private List<Item> _items;

    public Cell(string name        = "[PLACEHOLDER_Cl_NAME]",
                string description = "[PLACEHOLDER_DESC]",
                string rm          = "[PLACEHOLDER_Rm_NAME]",
                int n = 1,int s = 1,int e = 1,int w = 1)
                {
                  _name=name;
                  _description=description;
                  _rmName=rm;
                  _n=new Border(n);
                  _s=new Border(s);
                  _e=new Border(e);
                  _w=new Border(w);
                }
    public Cell(string name        = "[PLACEHOLDER_Cl_NAME]",
                string description = "[PLACEHOLDER_DESC]",
                string rm          = "[PLACEHOLDER_Rm_NAME]")
                {
                  _name=name;
                  _description=description;
                  _rmName=rm;
                }

    public string GetName()
    {return _name;}
    public void SetName(string name)
    {this._name=name;}
    public string GetDescription()
    {return _description;}
    public void SetDescription(string description)
    {this._description=description;}
    public string GetRoom()
    {return _rmName;}
    public void SetRoom(string roomName)
    {this._rmName=roomName;}

    public Border GetN() {return this._n;}
    public void SetN(Border n){this._n=n;}
    public Border GetS() {return this._s;}
    public void SetS(Border s){this._s=s;}
    public Border GetE() {return this._e;}
    public void SetE(Border e){this._e=e;}
    public Border GetW() {return this._w;}
    public void SetW(Border w){this._w=w;}

    public List<Item> GetItems()                  {return this._items;}
    public void SetItems(List<Item> newInventory) {this._items = newInventory;}

    //TESTED COPY FUNCTION
    public Cell CopyOf()
    {
      Cell newCell = new Cell (this.GetName(),this.GetDescription(),this.GetRoom(),
      this.GetN().CopyOf(),this.GetS().CopyOf(),this.GetE().CopyOf(),this.GetW().CopyOf());
      return newCell;
    }
    //NEED TO TEST COPY-WithItems FUNCTION
    public Cell CopyOf_AddItems()
    {
      Cell newCell = new Cell (this.GetName(),this.GetDescription(),this.GetRoom(),
      this.GetN().CopyOf(),this.GetS().CopyOf(),this.GetE().CopyOf(),this.GetW().CopyOf());
      //if old cell has items push them onto the items array of new cell
      if (this.GetItems.Count>0)
      {
        foreach(Item item in this.GetItems())
        {newCell.SetItems(this.GetItems());}
      }
      return newCell;
    }
  }
}
