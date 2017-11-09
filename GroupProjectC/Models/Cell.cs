using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GroupProjectC.Models
{
  public class Cell
  {
    private string _name;        //what's it's name?
    private string _description; //room description
    //is the direction passable? uses border object
    private Border _n;
    private Border _s;
    private Border _e;
    private Border _w;

    private bool _accessable=true;  //Is it useable? (DEFAULT=true)
    public bool IsAccessable    () {return _accessable;}
    public void ToggleAccessable() {_accessable = !_accessable;}
    private List<Item> _items;    //does it have items?

    public Cell()
    {
      this.SetName("[PLACEHOLDER_Cl_NAME]");
      this.SetDescription("[PLACEHOLDER_DESC]");
      this.SetN(new Border(1));
      this.SetS(new Border(1));
      this.SetE(new Border(1));
      this.SetW(new Border(1));
    }
    public Cell(string name)
    {
      this.SetName(name);
      this.SetDescription("[PLACEHOLDER_DESC]");
      this.SetN(new Border(1));
      this.SetS(new Border(1));
      this.SetE(new Border(1));
      this.SetW(new Border(1));
    }

    public Cell(string name,
                string description,
                Border n,Border s,
                Border e, Border w)
    {
      this._name=name;
      this._description=description;
      this._n=n.CopyOf();
      this._s=s.CopyOf();
      this._e=e.CopyOf();
      this._w=w.CopyOf();
    }

    public string GetName()
    {return _name;}
    public void SetName(string name)
    {this._name=name;}
    public string GetDescription()
    {return _description;}
    public void SetDescription(string description)
    {this._description=description;}

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
    public void AddItem (Item newItem)            {this._items.Add(newItem);}


    //TESTED COPY FUNCTION
    public Cell CopyOf()
    {
      Cell newCell = new Cell
        (this.GetName(),this.GetDescription(),
         this.GetN(),this.GetS(),this.GetE(),this.GetW() );
      return newCell;
    }
    //NEED TO TEST COPY-WithItems FUNCTION
    public Cell CopyOf_AddItems()
    {
      Cell newCell = new Cell
        (this.GetName(),this.GetDescription(),
         this.GetN(),this.GetS(),this.GetE(),this.GetW() );
      //if old cell has items push them onto the items array of new cell
      if (this.GetItems().Count>0)
      {
        foreach(Item item in this.GetItems())
        {newCell.SetItems(this.GetItems());}
      }
      return newCell;
    }
  }
}
