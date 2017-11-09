using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GroupProjectC.Models
{
  public class Item
  {
    protected string _name;
    protected string _description;
    protected int    _posX;
    protected int    _posY;
    protected int    _ownedBy; //0=none, 1=player, 2=cell
    protected object _owner;   //this is either the cell it is in or a reference to the player atm

    // private int?   _lockId;     //optional property
    // private bool   _hidden;
    //For defining specific items <-- may be redundant since cell constructor already has items property, which is an empty array
    //item types:0=key item, 1=sensor

    public Item (string name = "UNSET", string description = "PLACEHOLDER_ITEM_DESC", int posX = 0, int posY = 0)
    {
      this.SetName     (name);
      this.SetDescript (description);
      this.SetX     (posX);
      this.SetY     (posY);
      this._ownedBy = 0;
    }
    public string GetName()            {return this._name;}
    public void   SetName(string name) {this._name=name;}
    public string GetDescript()                {return this._description;}
    public void   SetDescript(string description) {this._description=description;}
    public void   SetX(int x)   {this._posX=x;}
    public void   SetY(int y)   {this._posY=y;}
    public int    GetX()   {return this._posX;}
    public int    GetY()   {return this._posY;}
    public int[]  GetPos() {return new int [] {this.GetX(),this.GetY()};}

    public object GetOwner()
    {
      if (this._owner is Cell) {return (Cell)this._owner;}
      if (this._owner is Player) {return (Player)this._owner;}
      else {return null;}
    }
    void SetOwner(object owner)
    {
      if (owner is Cell)
      {
        this._ownedBy=2;
        this._owner=owner;
        ((Cell)this._owner).AddItem(this);
      }
      if (owner is Player)
      {
        this._ownedBy=1;
        this._owner=owner;
        ((Player)this._owner).AddItem(this);
      }
    }

    // public void SetAsKeyItem (string name,string description)
    // {
    //   this.info  = new Item (name,description);
    //   this.lockID = -1;
    // }
    // KeyItem.prototype.setLockID = function(id=-1) {
    //   if (Number.isInteger(id)){this.lockID=id;}
    //   else {alert("Invalid key id, enter a number");}
    // }

    // KeyItem.prototype.setToOwner = function(owner=this.info.owner,x=this.info.posX,y=this.info.posY) {
    //   if (owner instanceof Locale) {
    //     if (this.info.owner.cells[x][y]!==undefined && this.info.owner.cells[x][y] instanceof Cell){
    //     this.info.owner.cells[x][y].items.push(this);
    //     }
    //   if (owner instanceof Player) {
    //     this.info.owner.items.push(this);
    //     this.info.owner.checkInventory();
    //   }
    //   if (!(owner instanceof Locale) && !(owner instanceof Player)) {alert("ERROR: THERE WAS AN ISSUE PLACING: "+this.info.name);}
    //   }
    // }
    // KeyItem.prototype.useKey = function ()
    // {
    //   $("div.well p#actionInfo").empty();
    //   if(this.lockID !== -1){
    //     if (this.info.owner.cell.n.isLocked===false &&
    //         this.info.owner.cell.s.isLocked===false &&
    //         this.info.owner.cell.e.isLocked===false &&
    //         this.info.owner.cell.w.isLocked===false) {
    //       $("p#actionInfo").append("You can't use that here.");
    //       return 0;
    //     }
    //     if (this.info.owner.cell.n.isLocked && this.info.owner.cell.n.lockID === this.lockID){
    //       this.info.owner.cell.n.isLocked=false;
    //       $("p#actionInfo").append("You unlocked the door to your north.");
    //     }
    //     if (this.info.owner.cell.s.isLocked && this.cell.s.lockID === this.lockID){
    //       this.info.owner.cell.s.isLocked=false;
    //       $("p#actionInfo").append("You unlocked the door to your south.");
    //     }
    //     if (this.info.owner.cell.e.isLocked && this.cell.e.lockID === this.lockID){
    //       this.info.owner.cell.e.isLocked=false;
    //       $("p#actionInfo").append("You unlocked the door to your east.");
    //     }
    //     if (this.info.owner.cell.w.isLocked && this.cell.w.lockID === this.lockID){
    //       this.info.owner.cell.w.isLocked=false;
    //       $("p#actionInfo").append("You unlocked the door to your west.");
    //     }
    //   }
    //   else {
    //     $("p#actionInfo").append("You can't use that here.");
    //     return 0;
    //   }
    // }
  }
}
